using Desafio.Application.Interfaces;
using Desafio.Application.Services;
using Desafio.Domain.Repository;
using Desafio.Infra.Crosscutting.IOC;
using Desafio.Infra.CrossCutting.Security;
using Desafio.Infra.Data.Repository;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.Service.Providers
{
    /// <summary>
    /// Custom provider OAuth
    /// </summary>
    internal class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
       
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            context.AdditionalResponseParameters.Add("Username", context.Identity.Name);
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var userAppService = new UserRepository();
            var user = userAppService.Authenticate(context.UserName, Md5Cryptography.GetMd5Hash(context.Password));
            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos");
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Login));
            identity.AddClaim(new Claim("profile", "admin"));
            identity.AddClaim(new Claim("uid", user.Id.ToString()));
            identity.AddClaim(new Claim("umail", user.Email));
            identity.AddClaim(new Claim("ufnm", user.FirstName));
            identity.AddClaim(new Claim("ulnm", user.LastName));
            identity.AddClaim(new Claim("ucdt", user.CreatedAt.ToString()));
            var claims = new ProfileRepository().FindProfileRoleById(user.ProfileId);
            foreach (var claim in claims)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, claim));
            }

     
            GenericPrincipal principal = new GenericPrincipal(identity, new ProfileRepository().FindAllProfileRole());
            Thread.CurrentPrincipal = principal;

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "audience", context.ClientId ??string.Empty
                    }
                });
            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }




    }
}
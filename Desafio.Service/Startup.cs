using Desafio.Application.Interfaces;
using Desafio.Service.App_Start;
using Desafio.Service.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector.Lifestyles;
using Swashbuckle.Application;
using System;
using System.Configuration;
using System.Web.Http;

[assembly: OwinStartup(typeof(Desafio.Service.Startup))]

namespace Desafio.Service
{
    public class Startup
    {
        private readonly string issuer = ConfigurationManager.AppSettings["issuer"];
        private readonly byte[] secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["secret"]);


        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            app.Use(async (context, next) => {
                using (AsyncScopedLifestyle.BeginScope
                (SimpleInjectorWebApiInitializer.Initialize(config)))
                {
                    await next();
                }
            });

            SwaggerConfig.Register(config);
            ConfigureOAuth(app);
            WebApiConfig.Register(config);                  
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions authServerOptions = new OAuthAuthorizationServerOptions()
            {

                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat(issuer)
            };
            app.UseOAuthAuthorizationServer(authServerOptions);

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { "Any" },
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                }
            });
        }
    }
}

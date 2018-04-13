using Desafio.Application.Interfaces;
using Desafio.Application.ViewModels;
using Desafio.Service.Validations;
using System;
using System.Net;
using System.Web.Http;

namespace Desafio.Service.Controllers
{
    [RoutePrefix("api/v1")]
    //[Authorize]
    public class UsersController : ApiController
    {
        private readonly IUserAppService _userService;

        public UsersController(IUserAppService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("users")]
        [Authorize(Roles = "user-created")]
        public IHttpActionResult CreateUser(UserRegisterViewModel model)
        {
            try
            {
                var results = new UserRegisterValidador(_userService).Validation(model);
                if (!results.IsValid)
                    return Content(HttpStatusCode.BadRequest,
                     new HandlerMessage(results.Errors));

                _userService.Create(model);
                return Content(HttpStatusCode.Created,
                    new HandlerMessage(HttpStatusCode.Created, "Usuário criado com sucesso"));
            }
            catch (Exception)
            {
                return Content(
                     HttpStatusCode.BadRequest,
                     new HandlerMessage(HttpStatusCode.BadRequest, "Erro ao criar Usuário"));
            }
        }

        [HttpPut]
        [Route("users")]
        [Authorize(Roles = "user-edit")]
        public IHttpActionResult UpdateUser(UserUpdateViewModel model)
        {
            try
            {
                var results = new UserUpdateValidador(_userService).Validation(model);
                if (!results.IsValid)
                    return Content(HttpStatusCode.BadRequest,
                     new HandlerMessage(results.Errors));

                _userService.Update(model);
                return Content(HttpStatusCode.Created,
                    new HandlerMessage(HttpStatusCode.Created, "Usuário atualizado com sucesso"));
            }
            catch (Exception)
            {
                return Content(
                     HttpStatusCode.BadRequest,
                     new HandlerMessage(HttpStatusCode.BadRequest, "Erro ao atualizar Usuário"));
            }
        }

        [HttpGet]
        [Route("users")]
        [Authorize(Roles = "user-view")]
        public IHttpActionResult GetAllUser()
        {
            return Content(
                 HttpStatusCode.OK,
                 new HandlerMessage(HttpStatusCode.OK, null, _userService.GetAllUserProfile()));
        }

        [HttpDelete]
        [Route("users")]
        [Authorize(Roles = "GOD")]
        [Authorize(Roles = "user-deleted")]
        public IHttpActionResult DeleteUser(Guid id)
        {
            try
            {
                if (id == null)
                    return Content(HttpStatusCode.NotFound,
                    new HandlerMessage(HttpStatusCode.NotFound, "Usuário não encontrado"));

                _userService.Delete(id);
                return Content(
                 HttpStatusCode.OK,
                 new HandlerMessage(HttpStatusCode.OK, "usuário deletado com sucesso"));
            }
            catch (Exception)
            {
                return Content(
                  HttpStatusCode.BadRequest,
                  new HandlerMessage(HttpStatusCode.BadRequest, "erro ao deletar usuário"));
            }
        }

        [HttpGet]
        [Route("users/{id:guid}/{deletedBy:guid}/status")]
        [Authorize(Roles = "user-status")]
        public IHttpActionResult ChangeStatus(Guid id, Guid deletedBy)
        {
            try
            {
                if (id == null || deletedBy == null)
                    return NotFound();

                _userService.ChangeStatus(id, deletedBy);
                return Content(HttpStatusCode.OK,
                 new HandlerMessage(HttpStatusCode.OK, "Status alterado com sucesso"));
            }
            catch (Exception)
            {
                return Content(
                  HttpStatusCode.BadRequest,
                  new HandlerMessage(HttpStatusCode.BadRequest, "Erro ao mudar status usuario"));
            }
        }


        [HttpGet]
        [Route("users/{email}/email")]
        public IHttpActionResult HasEmailExist(string email)
        {
            return Content(
                 HttpStatusCode.OK,
                 new HandlerMessage(HttpStatusCode.OK, null, _userService.HasEmail(email)));
        }

        //[HttpGet]
        [Route("users/{id:guid}/address")]
        public IHttpActionResult GetUserAndAddressById(Guid id)
        {
            return Content(
                 HttpStatusCode.OK,
                 new HandlerMessage(HttpStatusCode.OK, null, _userService.GetUserAndAddress(id)));
        }

    }
}
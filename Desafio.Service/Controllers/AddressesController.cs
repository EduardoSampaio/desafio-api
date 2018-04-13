using Desafio.Application.Interfaces;
using Desafio.Application.ViewModels;
using Desafio.Service.Validations;
using System;
using System.Net;
using System.Web.Http;

namespace Desafio.Service.Controllers
{
    [RoutePrefix("api/v1")]
    public class AddressesController : ApiController
    {
        private readonly IAddressAppService _service;

        public AddressesController(IAddressAppService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("addresses")]
        //[Authorize(Roles = "user-edit")]
        public IHttpActionResult CreateAddress(AddressRegisterViewModel model)
        {
            try
            {
                var results = new AddressRegisterValidator().Validation(model);
                if (!results.IsValid)
                    return Content(HttpStatusCode.BadRequest,
                     new HandlerMessage(results.Errors));

                _service.Create(model);
                return Content(HttpStatusCode.Created,
                    new HandlerMessage(HttpStatusCode.Created, "Endereço criado com sucesso", model));
            }
            catch (Exception)
            {
                return Content(
                     HttpStatusCode.BadRequest,
                     new HandlerMessage(HttpStatusCode.BadRequest, "Erro ao criar Endereço"));
            }
        }

        [HttpPut]
        [Route("addresses")]
        [Authorize(Roles = "user-edit")]
        public IHttpActionResult UpdateAddress(AddressViewModel model)
        {
            try
            {
                var results = new AddressValidator().Validation(model);
                if (!results.IsValid)
                    return Content(HttpStatusCode.BadRequest,
                     new HandlerMessage(results.Errors));

                _service.Update(model);
                return Content(HttpStatusCode.Created,
                    new HandlerMessage(HttpStatusCode.Created, "Endereço atualizado com sucesso", model));
            }
            catch (Exception)
            {
                return Content(
                     HttpStatusCode.BadRequest,
                     new HandlerMessage(HttpStatusCode.BadRequest, "Erro ao atualizar Endereço"));
            }
        }

        [HttpDelete]
        [Route("addresses")]
        [Authorize(Roles = "user-edit")]
        public IHttpActionResult DeleteAddress(Guid id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                _service.Delete(id);
                return Content(
                  HttpStatusCode.OK,
                  new HandlerMessage(HttpStatusCode.OK, "excluido com sucesso"));
            }
            catch (Exception)
            {
                return Content(
                  HttpStatusCode.BadRequest,
                  new HandlerMessage(HttpStatusCode.BadRequest, "Erro ao excluir Endereço"));
            }
        }

    }   
}
using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Desafio.Application.ViewModels
{
    public class HandlerMessage
    {
        public HandlerMessage(IList<ValidationFailure> errors)
        {
            Version = "v1";
            StatusCode = HttpStatusCode.BadRequest;
            Errors = GetErroMessage(errors);
        }

        public HandlerMessage(HttpStatusCode statusCode, string message)
        {
            Version = "v1";
            StatusCode = statusCode;
            Message = message;
        }

        public HandlerMessage(HttpStatusCode statusCode, string message, object result)
        {
            Version = "v1";
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]

        public string Version { get; set; }

        [JsonProperty("statusCode", NullValueHandling = NullValueHandling.Ignore)]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public object Result { get; set; }

        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public List<ErrorProperty> Errors { get; set; }

        public List<ErrorProperty> GetErroMessage(IList<ValidationFailure> errors)
        {
            var list = new List<ErrorProperty>();
            foreach (var erro in errors)
            {
                var errorProperty = new ErrorProperty();
                errorProperty.Property = erro.PropertyName;
                errorProperty.ErroMessage = erro.ErrorMessage;
                list.Add(errorProperty);
            }

            return list;
        }
    }

    public class ErrorProperty
    {
        public string Property { get; set; }
        public string ErroMessage { get; set; }
    }

}

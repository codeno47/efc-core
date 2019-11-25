using EFC.Framework.Common.Dtos;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;

namespace EFC.Framework.Common.Utility
{
    public static class ErrorMapper
    {
        public static HttpResponseMessage ReturnError(string message, HttpStatusCode httpStatusCode)
        {
            ErrorDto errorMessage = new ErrorDto { Message = message, StatusCode = HttpStatusCode.BadRequest };
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(JsonConvert.SerializeObject(errorMessage), Encoding.UTF8, "application/json")
            };
        }
    }
}

using EFC.Framework.Common.Utility;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using System.Text;
using Unity;

namespace EFC.Framework.Core
{
    public abstract class FunctionBase
    {
        protected HttpClient HttpClient { get; set; }

        protected IUnityContainer UnityContainer { get; set; }

        protected void AddPagingHeader(HttpResponseMessage response, string dataJson)
        {
            response.Headers.Add("Paging-Headers", dataJson);
            response.Headers.Add("Access-Control-Expose-Headers", "Paging-Headers");
        }

        protected void AddContent(HttpResponseMessage response, string dataJson)
        {
            response.Content = new StringContent(dataJson, Encoding.UTF8, "application/json");
        }

        protected void AddStatus(HttpResponseMessage response, HttpStatusCode code)
        {
            response.StatusCode = code;
        }

        protected HttpResponseMessage ErrorResponse(string message, HttpStatusCode httpStatusCode)
        {
            return ErrorMapper.ReturnError(message, HttpStatusCode.BadRequest);
        }

        protected static string GetIpFromRequestHeaders(HttpRequest request)
        {
            if (request?.HttpContext?.Connection != null)
            {
                return request?.HttpContext?.Connection.RemoteIpAddress.ToString();
            }

            return "";
        }

    }
}

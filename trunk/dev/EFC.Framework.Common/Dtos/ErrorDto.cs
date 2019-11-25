using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EFC.Framework.Common.Dtos
{
    [Serializable]
    public class ErrorDto
    {
        public string Message { get; set; }
         
        public HttpStatusCode StatusCode { get; set; }
    }
}

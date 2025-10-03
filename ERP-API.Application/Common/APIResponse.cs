using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Application.Common
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } 
        public object Result { get; set; }    
        public string DisaplayMessage { get; set; } = "";

        public List<APIError> Errors { get; set; } = new();
        public List<APIWarning> Warnings { get; set; } = new();

        public void AddError(string errorMessage)
        {
            APIError error = new APIError(description: errorMessage);
            Errors.Add(error);
        }

        public void AddWarning(string warningMessage) 
        {
            APIWarning warning = new APIWarning(description: warningMessage);
            Warnings.Add(warning);
        }

    }
}

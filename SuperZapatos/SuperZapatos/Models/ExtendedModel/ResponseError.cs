using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatos.Models.ExtendedModel
{
    public class ResponseError : Response
    {
        public string error_code { get; set; }

        public string error_msg { get; set; }
    }
}
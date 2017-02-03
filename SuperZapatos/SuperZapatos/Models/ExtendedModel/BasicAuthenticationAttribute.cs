using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SuperZapatos.Models.ExtendedModel
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                //actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                this.ResponseAuthenticationError(actionContext);
            }
            else
            {
                string authenticatonToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodeAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticatonToken));
                string[] userNameAndPassword = decodeAuthenticationToken.Split(':');
                string name = userNameAndPassword[0];
                string password = userNameAndPassword[1];

                if (!Security.Login(name, password))
                {
                    this.ResponseAuthenticationError(actionContext);
                }                
            }
        }

        /// <summary>
        /// Return authentication error.
        /// </summary>
        /// <param name="actionContext">Action context</param>
        private void ResponseAuthenticationError(HttpActionContext actionContext)
        {
            CreatorResponse creator = new CreatorResponse(401);
            Response response = creator.GetResponse((int)EntityType.Error);

            actionContext.Response = actionContext.Request.CreateResponse<Response>(response);
        }
    }
}
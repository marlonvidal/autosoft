using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using AutoSoft.WebApi.Models;

namespace AutoSoft.WebApi.Infrastructure.Validation
{
    public class ValidateRequest : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var messages = new List<string>();

                foreach (var item in actionContext.ModelState)
                    foreach (var error in item.Value.Errors)
                        messages.Add(error.ErrorMessage);

                var response = new ErrorResponse(messages);

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }
    }
}
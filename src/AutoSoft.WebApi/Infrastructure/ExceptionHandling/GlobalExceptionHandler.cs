using AutoSoft.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace AutoSoft.WebApi.Infrastructure.ExceptionHandling
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;

            var httpException = exception as HttpException;
            if (httpException != null)
            {
                context.Result = new ErrorResult(context.Request, (HttpStatusCode)httpException.GetHttpCode(), httpException.Message);
                return;
            }
            if (exception is BusinessValidationException)
            {
                var businessValidationException = exception as BusinessValidationException;
                context.Result = new ErrorResult(context.Request, HttpStatusCode.BadRequest, businessValidationException.Messages);
                return;
            }

            context.Result = new ErrorResult(context.Request, HttpStatusCode.InternalServerError, exception.Message);
        }
    }
}
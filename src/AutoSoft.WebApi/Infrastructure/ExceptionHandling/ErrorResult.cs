using AutoSoft.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AutoSoft.WebApi.Infrastructure.ExceptionHandling
{
    public class ErrorResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _requestMessage;
        private readonly HttpStatusCode _statusCode;
        private readonly List<string> _errorMessages;

        public ErrorResult(HttpRequestMessage requestMessage, HttpStatusCode statusCode, string errorMessage)
            : this(requestMessage, statusCode, new List<string>() { errorMessage }) { }

        public ErrorResult(HttpRequestMessage requestMessage, HttpStatusCode statusCode, List<string> errorMessages)
        {
            _requestMessage = requestMessage;
            _statusCode = statusCode;
            _errorMessages = errorMessages;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new ErrorResponse(_errorMessages);
            return Task.FromResult(_requestMessage.CreateResponse(_statusCode, response));
        }
    }
}
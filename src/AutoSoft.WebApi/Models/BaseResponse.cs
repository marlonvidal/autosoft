using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoSoft.WebApi.Models
{
    public class SuccessResponse : BaseResponse
    {

    }

    public class ErrorResponse : BaseResponse
    {
        public ErrorResponse(List<string> messages) : base(messages) { }
    }

    public abstract class BaseResponse
    {
        public BaseResponse()
        {
            this.success = true;
        }

        public BaseResponse(List<string> messages)
        {
            this.success = false;
            this.messages = messages;
        }

        public List<string> messages { get; set; }
        public bool success { get; set; }
    }
}
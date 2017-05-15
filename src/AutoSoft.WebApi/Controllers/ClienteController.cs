using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AutoSoft.WebApi.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {        
        [Route("")]
        public IHttpActionResult Get(int? id)
        {
            return Ok();
        }

    }
}
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoSoft.WebApi.Infrastructure
{
    public class UserIdentity : IIdentity
    {
        private readonly string _name;

        public UserIdentity(HttpContextBase httpContextBase)
        {
            _name = httpContextBase == null ? "" : httpContextBase.User.Identity.Name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
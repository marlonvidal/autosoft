using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoSoft.WebApi.Models
{
    public class UsuarioViewModel
    {
        public string Login { get; set; }        
        public string Senha { get; set; }
    }
}
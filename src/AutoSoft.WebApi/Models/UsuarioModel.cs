using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoSoft.WebApi.Models
{
    public class UsuarioModel
    {
        public string Login { get; set; }        
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
    }
}
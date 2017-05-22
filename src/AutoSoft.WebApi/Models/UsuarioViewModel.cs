using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoSoft.WebApi.Models
{
    public class UsuarioViewModel
    {
        [Required]
        public string Login { get; set; }        

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
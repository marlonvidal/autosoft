using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.Model
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}

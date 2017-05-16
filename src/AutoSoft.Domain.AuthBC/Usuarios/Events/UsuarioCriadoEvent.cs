using AutoSoft.Infrastructure.Domain;
using AutoSoft.Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.AuthBC.Usuarios.Events
{
    public class UsuarioCriadoEvent : DomainEvent
    {
        public Guid UsuarioId { get; set; }
    }
}

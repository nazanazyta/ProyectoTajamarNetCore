using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProyectoTajamarNetCore.Helpers.Enumerations;

namespace ProyectoTajamarNetCore.Models
{
    public class UsuarioSession
    {
        public int Id { get; set; }

        public String UserName { get; set; }

        public Roles Rol { get; set; }
    }
}

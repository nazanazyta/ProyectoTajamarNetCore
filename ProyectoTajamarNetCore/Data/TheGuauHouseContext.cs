using Microsoft.EntityFrameworkCore;
using ProyectoTajamarNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Data
{
    public class TheGuauHouseContext: DbContext
    {
        public TheGuauHouseContext(DbContextOptions<TheGuauHouseContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

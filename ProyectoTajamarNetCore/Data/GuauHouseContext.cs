using Microsoft.EntityFrameworkCore;
using ProyectoTajamarNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Data
{
    public class GuauHouseContext: DbContext
    {
        public GuauHouseContext(DbContextOptions<GuauHouseContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

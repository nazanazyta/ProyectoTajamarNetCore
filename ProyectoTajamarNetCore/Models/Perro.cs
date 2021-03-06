﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Models
{
    [Table("perros")]
    public class Perro
    {
        [Key]
        [Column("id")]
        public int IdPerro { get; set; }
        [Column("idusu")]
        public int IdUsu { get; set; }
        [Column("nombre")]
        public String Nombre { get; set; }
        [Column("estatura")]
        public String Estatura { get; set; }
        [Column("fecha_alta")]
        [Timestamp]
        public DateTime FechaAlta { get; set; }
    }
}

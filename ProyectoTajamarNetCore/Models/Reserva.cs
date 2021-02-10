using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Models
{
    [Table("reservas")]
    public class Reserva
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idusu")]
        public int IdUsu { get; set; }
        [Column("idper")]
        public int IdPer { get; set; }
        [Column("fecha")]
        public DateTime Fecha { get; set; }
        [Column("turno")]
        public String Turno { get; set; }
        [Timestamp]
        [Column("fecha_alta")]
        public DateTime FechaAlta { get; set; }
    }
}

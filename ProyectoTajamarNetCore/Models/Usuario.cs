using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("ID")]
        public int IdUsuario { get; set; }
        [Column("USUARIO")]
        public String UserName { get; set; }
        [Column("PASS")]
        public String Password { get; set; }
        //[Column("SALT")]
        //public String Salt { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("APELLIDOS")]
        public String Apellidos { get; set; }
        [Column("DNI")]
        public String Dni { get; set; }
        [Column("EMAIL")]
        public String Email { get; set; }
        [Column("TELEFONO")]
        public String Telefono { get; set; }
        [Column("IMAGEN")]
        public String Imagen { get; set; }
        [Column("ROL")]
        public int Rol { get; set; }
        [Column("FECHA_ALTA")]
        public DateTime FechaAlta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Software.Models
{
   using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace Proyecto_Software.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string ?SegundoApellido { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public string? Compania { get; set; }
        public string? Nota { get; set; }
        public DateTime FechaDeRegistro { get; set; }= DateTime.Now;
    }
}

}
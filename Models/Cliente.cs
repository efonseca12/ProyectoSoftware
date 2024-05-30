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

        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El primer nombre no puede tener más de 50 caracteres.")]
        public string? PrimerNombre { get; set; }

        [StringLength(50, ErrorMessage = "El segundo nombre no puede tener más de 50 caracteres.")]
        public string? SegundoNombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El primer apellido no puede tener más de 50 caracteres.")]
        public string? PrimerApellido { get; set; }

        [StringLength(50, ErrorMessage = "El segundo apellido no puede tener más de 50 caracteres.")]
        public string? SegundoApellido { get; set; }

        [EmailAddress(ErrorMessage = "Correo electrónico no válido.")]
        [StringLength(100, ErrorMessage = "El correo no puede tener más de 100 caracteres.")]
        public string? Correo { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede tener más de 200 caracteres.")]
        public string? Direccion { get; set; }

        [StringLength(100, ErrorMessage = "La compañía no puede tener más de 100 caracteres.")]
        public string? Compania { get; set; }

        [StringLength(500, ErrorMessage = "La nota no puede tener más de 500 caracteres.")]
        public string? Nota { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}

}
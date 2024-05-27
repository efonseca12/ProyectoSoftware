using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Software.Models
{
     public class Empleado
    {
        public int Id { get; set; }
        public string? Cedula { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Departamento { get; set; }
        public string? Municipio { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string? Profesion { get; set; }
        public string? Puesto { get; set; }
        public decimal Salario { get; set; }
    }
}
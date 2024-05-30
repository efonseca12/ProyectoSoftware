using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Software.Models
{
     public class Empleado
    {
       public int Id { get; set; }

    [Required(ErrorMessage = "El campo Cédula es obligatorio")]
    public string? Cedula { get; set; }

    [Required(ErrorMessage = "El campo Nombres es obligatorio")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
    public string? Apellidos { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Nacimiento")]
    public DateTime FechaNacimiento { get; set; }

    [Required(ErrorMessage = "El campo Departamento es obligatorio")]
    public string? Departamento { get; set; }

    [Required(ErrorMessage = "El campo Municipio es obligatorio")]
    public string? Municipio { get; set; }

    public string? Direccion { get; set; }

    [Phone]
    public string ?Telefono { get; set; }

    [Phone]
    public string? Celular { get; set; }

    [EmailAddress]
    public string? Correo { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Ingreso")]
    public DateTime FechaIngreso { get; set; }

    public string? Profesion { get; set; }

    public string? Puesto { get; set; }

    [DataType(DataType.Currency)]
    public decimal Salario { get; set; }
    }
}
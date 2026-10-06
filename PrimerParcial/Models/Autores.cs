using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimerParcial.Models;

public class Autores
{
    [Key]
    public int IdAutor{ get; set; }

    [Required(ErrorMessage ="Este campo es Obligatorio")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string? Nacionalidad { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public int FechaNacimiento { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public double Sueldo { get; set; }

}
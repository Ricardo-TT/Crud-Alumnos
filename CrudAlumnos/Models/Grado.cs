using System.ComponentModel.DataAnnotations;

namespace CrudAlumnos.Models
{
    public class Grado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El grado es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Grado_Escolar")]
        public string Grado_Escolar { get; set; }

        public ICollection<Alumno> Alumno { get;}
    }
}

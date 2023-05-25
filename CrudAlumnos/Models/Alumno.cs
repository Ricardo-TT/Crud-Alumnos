using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudAlumnos.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El estatus es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Estatus")]
        public string Estatus { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado_Alumno { get; set; }

        public bool Eliminado { get; set; }

        [ForeignKey("GradoId")]
        public int GradoId { get; set; }

        public Grado Grado { get; set; }

        //[ForeignKey("GradoId")]
        /// <summary>
        //public int GradoId { get; set; } //Propiedad de la clave foranea
        /// </summary>

        //Propiedades de navegación
        //public Grado Grado { get; set;}
    }
}

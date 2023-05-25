using CrudAlumnos.Data;
using CrudAlumnos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAlumnos.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlumnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<AlumnoViewModel> alumnos = _context.Alumno
                .Join(_context.Grado, alumno => alumno.GradoId, grado => grado.Id, (alumno, grado) => new AlumnoViewModel
                {
                    AlumnoId = alumno.Id,
                    NombreAlumno = alumno.Nombre,
                    EstatusAlumno = alumno.Estatus,
                    EstadoAlumno = alumno.Estado_Alumno,
                    NombreGrado = grado.Grado_Escolar,
                    EliminadoAlumno = alumno.Eliminado
                })
                .Where(alumno => !alumno.EliminadoAlumno) // Filtrar registros no eliminados
                .ToList();

            return View(alumnos);
        }


        [HttpPost]
        public IActionResult Buscar(bool? estado, string busqueda)
        {
            IQueryable<AlumnoViewModel> consultaAlumnos = _context.Alumno
                .Join(_context.Grado, alumno => alumno.GradoId, grado => grado.Id, (alumno, grado) => new AlumnoViewModel
                {
                    AlumnoId = alumno.Id,
                    NombreAlumno = alumno.Nombre,
                    EstatusAlumno = alumno.Estatus,
                    EstadoAlumno = alumno.Estado_Alumno,
                    NombreGrado = grado.Grado_Escolar,
                    EliminadoAlumno = alumno.Eliminado
                });

            if (estado.HasValue)
            {
                consultaAlumnos = consultaAlumnos.Where(a => a.EstadoAlumno == estado.Value);
            }

            if (!string.IsNullOrEmpty(busqueda))
            {
                consultaAlumnos = consultaAlumnos.Where(a => a.NombreAlumno.Contains(busqueda)); //<----------  FILTRO DE NOMBRE  ----------->
            }

            List<AlumnoViewModel> alumnos = consultaAlumnos.ToList();

            return PartialView("_AlumnosPartial", alumnos);
        }


        //Http Get Create
        public IActionResult Create()
        {

            return View();
        }


        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Alumno alumno)
        {

                _context.Alumno.Add(alumno);
                _context.SaveChanges();

                TempData["mensaje"] = "El alumno se ha añadido correctamente";
                return RedirectToAction("Index");

        }

        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener alumno
            var alumno = _context.Alumno.Find(id);

            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Alumno alumno)
        {
                _context.Alumno.Update(alumno);
                _context.SaveChanges();

                TempData["mensaje"] = "El alumno se ha actualizado correctamente";
                return RedirectToAction("Index");
        }

        //Http Get Eliminar
        public IActionResult Eliminar(int id)
        {
            var alumno = _context.Alumno.FirstOrDefault(a => a.Id == id);
            if (alumno != null)
            {
                alumno.Eliminado = true; // Marcar como eliminado
                _context.SaveChanges();
            }

            TempData["mensaje"] = "El alumno se ha eliminado correctamente";
            return RedirectToAction("Index");
        }


        // ACTUALIZAR ESTADO DEL ALUMNO

        public IActionResult ActualizarEstado(int alumnoId, bool nuevoEstado)
        {
            var alumno = _context.Alumno.Find(alumnoId);
            if (alumno == null)
            {
                return NotFound();
            }

            alumno.Estado_Alumno = nuevoEstado;
            _context.SaveChanges();

            return Ok();
        }


    }
}

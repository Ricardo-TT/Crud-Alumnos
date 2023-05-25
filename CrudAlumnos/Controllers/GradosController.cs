using CrudAlumnos.Data;
using CrudAlumnos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAlumnos.Controllers
{
    public class GradosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GradosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Grado> listGrados = _context.Grado;
            return View(listGrados);
        }

        //Http Get Create
        public IActionResult Create()
        {

            return View();
        }


        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Grado grado)
        {
            
                _context.Grado.Add(grado);
                _context.SaveChanges();

                TempData["mensaje"] = "El grado se ha añadido correctamente";
                return RedirectToAction("Index");

        }

        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener grado
            var grado = _context.Grado.Find(id);

            if (grado == null)
            {
                return NotFound();
            }

            return View(grado);
        }

        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Grado grado)
        {
            if (ModelState.IsValid)
            {
                _context.Grado.Update(grado);
                _context.SaveChanges();

                TempData["mensaje"] = "El grado se ha actualizado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener grado
            var grado = _context.Grado.Find(id);

            if (grado == null)
            {
                return NotFound();
            }

            return View(grado);
        }

        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteGrado(int? id)
        {

            //Obtener el grado por id

            var grado = _context.Grado.Find(id);

            if (grado == null)
            {
                return NotFound();
            }

            _context.Grado.Remove(grado);
            _context.SaveChanges();

            TempData["mensaje"] = "El grado se ha eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}

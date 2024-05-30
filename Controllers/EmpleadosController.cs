using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Software.Data;
using Proyecto_Software.Models;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Proyecto_Software.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly Proyecto_Software.Data.ClientesContext _context;

        public EmpleadosController(Proyecto_Software.Data.ClientesContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleado.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cedula,Nombres,Apellidos,FechaNacimiento,Departamento,Municipio,Direccion,Telefono,Celular,Correo,FechaIngreso,Profesion,Puesto,Salario")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cedula,Nombres,Apellidos,FechaNacimiento,Departamento,Municipio,Direccion,Telefono,Celular,Correo,FechaIngreso,Profesion,Puesto,Salario")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
}
        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            IQueryable<Empleado> empleadosIQ = from e in _context.Empleado
                                               select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                empleadosIQ = empleadosIQ.Where(e =>
                    e.Nombres.Contains(searchString) ||
                    e.Apellidos.Contains(searchString) ||
                    e.Correo.Contains(searchString));
            }

            int pageSize = 10;
            pageNumber = pageNumber ?? 1;
            var empleados = await empleadosIQ.ToPagedListAsync(pageNumber.Value, pageSize);

            return View(empleados);
        }

       
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Software.Data;
using Proyecto_Software.Models;

namespace Proyecto_Software.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly ClientesContext _context;

        public IndexModel(ClientesContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleados { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            IQueryable<Empleado> empleadosIQ = from e in _context.Empleado
                                               select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                empleadosIQ = empleadosIQ.Where(e => e.Nombres.Contains(searchString)
                                            || e.Apellidos.Contains(searchString));
            }

            Empleados = await empleadosIQ.ToListAsync();
        }
    }
}

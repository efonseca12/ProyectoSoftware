using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Software.Data;
using Proyecto_Software.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Proyecto_Software.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly ClientesContext _context;

        public IndexModel(ClientesContext context)
        {
            _context = context;
        }

        public IPagedList<Empleado> Empleados { get; set; }
        public string CurrentFilter { get; set; }
        public int? PageNumber { get; set; }

        public async Task OnGetAsync(string searchString, int? pageNumber)
        {
            CurrentFilter = searchString;

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
            PageNumber = pageNumber ?? 1;
            Empleados = await empleadosIQ.ToPagedListAsync(PageNumber ?? 1, pageSize);
        }
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Software.Data;
using Proyecto_Software.Models;
using Proyecto_Software.Models.Proyecto_Software.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Proyecto_Software.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ClientesContext _context;

        public IndexModel(ClientesContext context)
        {
            _context = context;
        }

        public IPagedList<Cliente> Clientes { get; set; }
        public string CurrentFilter { get; set; }
        public int? PageNumber { get; set; }

        public async Task OnGetAsync(string searchString, int? pageNumber)
        {
            CurrentFilter = searchString;

            IQueryable<Cliente> clientesIQ = from c in _context.Clientes
                                             select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                clientesIQ = clientesIQ.Where(c =>
                    c.PrimerNombre.Contains(searchString) ||
                    c.PrimerApellido.Contains(searchString) ||
                    c.Correo.Contains(searchString));
            }

            int pageSize = 10;
            PageNumber = pageNumber ?? 1;
            Clientes = await clientesIQ.ToPagedListAsync(PageNumber ?? 1, pageSize);
        }
    }
}

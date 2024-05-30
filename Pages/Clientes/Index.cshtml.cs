using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Software.Data;
using Proyecto_Software.Models;
using Proyecto_Software.Models.Proyecto_Software.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Software.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ClientesContext _context;

        public IndexModel(ClientesContext context)
        {
            _context = context;
            Clientes = new List<Cliente>();  // Inicializa la propiedad Clientes
        }

        public IList<Cliente> Clientes { get; set; }

       
        public async Task OnGetAsync(string searchString)
{
    IQueryable<Cliente> clientesIQ = _context.Clientes;

    if (!string.IsNullOrEmpty(searchString))
    {
        clientesIQ = clientesIQ.Where(c =>
            c.PrimerNombre.Contains(searchString) ||
            c.PrimerApellido.Contains(searchString) ||
            c.Correo.Contains(searchString));
    }

    Clientes = await clientesIQ.ToListAsync();
}

    }
}

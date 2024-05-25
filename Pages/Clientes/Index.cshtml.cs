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

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes.ToListAsync();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Software.Data;
using Proyecto_Software.Models;
using Proyecto_Software.Models.Proyecto_Software.Models;
using System.Threading.Tasks;

namespace Proyecto_Software.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly Proyecto_Software.Data.ClientesContext _context;

        public DeleteModel(Proyecto_Software.Data.ClientesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Cliente = await _context.Clientes.FindAsync(id);

            if (Cliente == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Cliente = await _context.Clientes.FindAsync(id);

            if (Cliente != null)
            {
                _context.Clientes.Remove(Cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

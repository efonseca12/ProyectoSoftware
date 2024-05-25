using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Software.Data;
using Proyecto_Software.Models;
using Proyecto_Software.Models.Proyecto_Software.Models;
using System.Threading.Tasks;

namespace Proyecto_Software.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly Proyecto_Software.Data.ClientesContext _context;

        public EditModel(Proyecto_Software.Data.ClientesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.ID == id);

            if (Cliente == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(Cliente.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.ID == id);
        }
    }
}

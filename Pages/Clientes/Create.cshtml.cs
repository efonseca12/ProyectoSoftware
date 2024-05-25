using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Software.Data;
using Proyecto_Software.Models;
using Proyecto_Software.Models.Proyecto_Software.Models;
using System.Threading.Tasks;

namespace Proyecto_Software.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly Proyecto_Software.Data.ClientesContext _context;

        public CreateModel(Proyecto_Software.Data.ClientesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
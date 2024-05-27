using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Software.Data;
using Proyecto_Software.Models;
using System.Threading.Tasks;

namespace Proyecto_Software.Pages.Empleados
{
    public class CreateModel : PageModel
    {
        private readonly ClientesContext _context;

        public CreateModel(ClientesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; }

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

            _context.Empleado.Add(Empleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

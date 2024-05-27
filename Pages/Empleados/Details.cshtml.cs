using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Software.Data;
using Proyecto_Software.Models;

namespace Proyecto_Software.Pages.Empleados
{
    public class DetailsModel : PageModel
    {
        private readonly ClientesContext _context;

        public DetailsModel(ClientesContext context)
        {
            _context = context;
        }

        public Empleado Empleado { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empleado = await _context.Empleado.FirstOrDefaultAsync(m => m.Id == id);

            if (Empleado == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Proyecto_Software.Models;
using Proyecto_Software.Models.Proyecto_Software.Models;

namespace Proyecto_Software.Data
{
    public class ClientesContext : DbContext
    {
        public ClientesContext(DbContextOptions<ClientesContext> options)
            : base(options)
        {
        }

 
        public DbSet<Cliente> Clientes { get; set; }
      public DbSet<Empleado> Empleado { get; set; }  
    }
}

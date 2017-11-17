using BusinessProcesses.Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace BusinessProcesses.Server.Migrations
{
    public class DbInitializer
    {
        private readonly BusinessProcessesContext _context;
        
        public DbInitializer(BusinessProcessesContext context)
        {
            _context = context;
        }
        
        public void Initialize()
        {
            _context.Database.Migrate();
        }
    }
}
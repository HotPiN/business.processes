using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessProcesses.Server.Domain;
using BusinessProcesses.Server.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessProcesses.Server.Services
{
    public class UserService
    {
        private readonly BusinessProcessesContext _context;

        public UserService(BusinessProcessesContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersList(int page, int perPage)
        {
            return await _context
                .Users
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToListAsync();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessProcesses.Server.Domain;
using BusinessProcesses.Server.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessProcesses.Server.Services
{
    public class JobService
    {
        private readonly BusinessProcessesContext _context;

        public JobService(BusinessProcessesContext context)
        {
            _context = context;
        }

        public async Task<List<Job>> GetJobsList(int page = 1, int perPage = 10)
        {
            return await _context
                .Jobs
                .Include(j => j.CreatedByUser)
                .Include(j => j.UpdatedByUser)
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToListAsync();
        }

        public async Task<Job> GetJobById(int id)
        {
            return await _context
                .Jobs
                .Where(j => j.Id == id)
                .Include(j => j.Properties)
                .Include(j => j.Activities)
                .ThenInclude(a => a.Next)
                .ThenInclude(a => a.Parent)
                .FirstOrDefaultAsync();
        }
    }
}
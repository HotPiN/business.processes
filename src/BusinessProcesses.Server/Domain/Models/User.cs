using System.Collections.Generic;

namespace BusinessProcesses.Server.Domain.Models
{
    public class User
    {
        public User()
        {
            CreatedJobs = new List<Job>();
            UpdatedJobs = new List<Job>();
        }
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string PasswordHash { get; set; }
        
        public ICollection<Job> CreatedJobs { get; set; }
        
        public ICollection<Job> UpdatedJobs { get; set; }
    }
}
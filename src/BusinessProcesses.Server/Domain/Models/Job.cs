using System;
using System.Collections.Generic;

namespace BusinessProcesses.Server.Domain.Models
{
    public class Job
    {
        public Job()
        {
            JobInstances = new List<JobInstance>();
            Activities = new List<Activity>();
            Properties = new List<Property>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public ICollection<JobInstance> JobInstances { get; set; }

        public ICollection<Activity> Activities { get; set; }

        public ICollection<Property> Properties { get; set; }
        
        public User CreatedByUser { get; set; }
        
        public User UpdatedByUser { get; set; }
    }
}
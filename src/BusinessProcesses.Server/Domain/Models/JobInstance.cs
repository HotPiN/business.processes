using System;

namespace BusinessProcesses.Server.Domain.Models
{
    public class JobInstance
    {
        public int Id { get; set; }

        public JobStatus Status { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime NextRunOn { get; set; }

        public int JobId { get; set; }

        public int ActivityId { get; set; }


        public Job Job { get; set; }

        public Activity Activity { get; set; }

    }
}
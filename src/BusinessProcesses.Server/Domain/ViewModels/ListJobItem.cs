using System;

namespace BusinessProcesses.Server.Domain.ViewModels
{
    public class ListJobItem
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        
        public int CountActive { get; set; }
    }
}
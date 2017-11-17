using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BusinessProcesses.Server.Domain.Models
{
    public class Activity
    {
        public Activity()
        {
            JobInstances = new List<JobInstance>();
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public int JobId { get; set; }

        public int NextId { get; set; }

        public int ParentId { get; set; }

        public string _Settings { get; set; }

        [NotMapped]
        public ISettings Settings {
            get => _Settings == null ? null : JsonConvert.DeserializeObject<ISettings>(_Settings);
            set => _Settings = JsonConvert.SerializeObject(value);
        }

        public Job Job { get; set; }

        public Activity Next { get; set; }

        public Activity Parent { get; set; }

        public ICollection<JobInstance> JobInstances { get; set; }
    }
}
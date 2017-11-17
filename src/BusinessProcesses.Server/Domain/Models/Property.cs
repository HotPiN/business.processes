using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessProcesses.Server.Domain.Models
{
    public class Property
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string _Type { get; set; }

        public int JobId { get; set; }

        [NotMapped]
        public Type Type
        {
            get => _Type == null ? null : Type.GetType(_Type);
            set => _Type = value.ToString();
        }

        public Job Job { get; set; }
    }
}
namespace BusinessProcesses.Server.Domain.Models
{
    public class JobInstanceProperty
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public int JobId { get; set; }

        public string Value { get; set; }


        public Property Property { get; set; }

        public Job Job { get; set; }
    }
}
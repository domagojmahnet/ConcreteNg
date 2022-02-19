
namespace ConcreteNg.Shared.Models
{
    public class Employer
    {
        public Guid EmployerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset StartDate { get; set; }
    }
}

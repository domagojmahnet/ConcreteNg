
namespace ConcreteNg.Shared.Models
{
    public class Employer
    {
        public int EmployerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset StartDate { get; set; }

        public Employer()
        {

        }

        public Employer(int employerId, string name, string address, string phone, DateTimeOffset startDate)
        {
            EmployerId = employerId;
            Name = name;
            Address = address;
            Phone = phone;
            StartDate = startDate;
        }
    }
}

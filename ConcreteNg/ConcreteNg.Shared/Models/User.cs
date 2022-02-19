using ConcreteNg.Shared.Enums;

namespace ConcreteNg.Shared.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset HireDate { get; set; }
        public UserTypeEnum UserType { get; set; }
        public Employer Employer { get; set; }
        public ICollection<Project>? Projects { get; set; }
    }
}

using ConcreteNg.Shared.Enums;
using System.Text.Json.Serialization;

namespace ConcreteNg.Shared.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset? HireDate { get; set; }
        public DateTimeOffset? DepartureDate { get; set; }
        public UserTypeEnum UserType { get; set; }
        [JsonIgnore]
        public Employer Employer { get; set; }
        [JsonIgnore]
        public ICollection<Project>? Projects { get; set; }

        public User()
        {
               
        }

        public User(string firstName, string lastName, string username, string password, string phone, DateTimeOffset? hireDate, DateTimeOffset? departureDate, UserTypeEnum userType, Employer employer)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Phone = phone;
            HireDate = hireDate;
            DepartureDate = departureDate;
            UserType = userType;
            Employer = employer;
        }
    }
}

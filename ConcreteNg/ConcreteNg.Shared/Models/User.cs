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
        public UserTypeEnum UserType { get; set; }
        [JsonIgnore]
        public Employer? Employer { get; set; }
        [JsonIgnore]
        public ICollection<Project>? Projects { get; set; }
        public bool IsActive { get; set; }

        public User()
        {
               
        }

        public User(string firstName, string lastName, string username, string password, string phone, DateTimeOffset? hireDate, UserTypeEnum userType, Employer employer, bool isActive)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Phone = phone;
            HireDate = hireDate;
            UserType = userType;
            Employer = employer;
            IsActive = isActive;
        }
    }
}


using ConcreteNg.Shared.Enums;

namespace ConcreteNg.Shared.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset ExpoectedStartDate { get; set; }
        public DateTimeOffset ExpectedEndDate { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public float ExpectedCost { get; set; }
        public float CurrentCost { get; set; }
        public ProjectStatusEnum ProjectStatus { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}

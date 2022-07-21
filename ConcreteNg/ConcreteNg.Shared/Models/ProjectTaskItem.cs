using ConcreteNg.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models
{
    public class ProjectTaskItem
    {
        public int ProjectTaskItemId { get; set; }
        public PricingListItem PricingListItem { get; set; }
        public ProjectStatusEnum TaskItemStatus { get; set; }
        public float? Quantity { get; set; }
        public float? Expenditure { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? FinishTime { get; set; }


        [IgnoreDataMember]
        [JsonIgnore]
        public ProjectTask? ProjectTask { get; set; }

    }
}

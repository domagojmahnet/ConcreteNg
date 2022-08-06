using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models
{
    public class CostOverview
    {
        public string TaskName { get; set; }
        public float TotalmaterialCost { get; set; }
        public float TotalLabourCost { get; set; }
        public float TotalQuantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public IEnumerable<PartnerCost> PartnerCosts { get; set; }
        public float TotalCost { get; set; }

        public CostOverview(string taskName, float totalmaterialCost, float totalLabourCost, float totalQuantity, string unitOfMeasurement, IEnumerable<PartnerCost> partnerCosts, float totalCost)
        {
            TaskName = taskName;
            TotalmaterialCost = totalmaterialCost;
            TotalLabourCost = totalLabourCost;
            TotalQuantity = totalQuantity;
            UnitOfMeasurement = unitOfMeasurement;
            PartnerCosts = partnerCosts;
            TotalCost = totalCost;
        }
    }

    public class PartnerCost
    {
        public string PartnerName { get; set; }
        public float TotalCost { get; set; }

        public PartnerCost(string partnerName, float totalCost)
        {
            PartnerName = partnerName;
            TotalCost = totalCost;
        }
    }
}

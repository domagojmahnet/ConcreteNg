using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models
{
    public class PricingListItem
    {
        public int PricingListItemId { get; set; }
        public Employer Employer { get; set; }
        public string PricingListItemName { get; set; }
        public string UnitOfMeasurement { get; set; }
        public float Price { get; set; }
    }
}

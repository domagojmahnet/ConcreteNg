using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models
{
    public class PricingListItem
    {
        public int PricingListItemId { get; set; }
        public string PricingListItemName { get; set; }
        public string UnitOfMeasurement { get; set; }
        public float Price { get; set; }
        [JsonIgnore]
        public Employer? Employer { get; set; }

        public PricingListItem(int pricingListItemId, string pricingListItemName, string unitOfMeasurement, float price, Employer? employer)
        {
            PricingListItemId = pricingListItemId;
            PricingListItemName = pricingListItemName;
            UnitOfMeasurement = unitOfMeasurement;
            Price = price;
            Employer = employer;
        }

        public PricingListItem(string pricingListItemName, string unitOfMeasurement, float price, Employer employer)
        {
            PricingListItemName = pricingListItemName;
            UnitOfMeasurement = unitOfMeasurement;
            Price = price;
            Employer = employer;
        }

        public PricingListItem()
        {

        }
    }
}

using System.Text.Json.Serialization;

namespace ConcreteNg.Shared.Models
{
    public class PricingListItem
    {
        public int PricingListItemId { get; set; }
        public string PricingListItemName { get; set; }
        public string UnitOfMeasurement { get; set; }
        public float Price { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public Employer? Employer { get; set; }

        public PricingListItem(string pricingListItemName, string unitOfMeasurement, float price, bool isActive, Employer employer)
        {
            PricingListItemName = pricingListItemName;
            UnitOfMeasurement = unitOfMeasurement;
            Price = price;
            IsActive = isActive;
            Employer = employer;
        }

        public PricingListItem()
        {

        }
    }
}

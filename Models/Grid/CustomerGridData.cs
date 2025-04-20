using System.Text.Json.Serialization;

namespace RealEstateAgencySystem.Models
{
    public class CustomerGridData : GridData
    {
        // set initial sort field in constructor
        public CustomerGridData() => SortField = nameof(Customer.Id);

        // sort flags
        // [JsonIgnore]
        // public bool IsSortByRentalPrice =>
        //     SortField.EqualsNoCase(nameof(Property.RentalPrice));
        // [JsonIgnore]
        // public bool IsSortByDepositPrice =>
        //     SortField.EqualsNoCase(nameof(Property.DepositPrice));
        // [JsonIgnore]
        // public bool IsSortByEndDate =>
        //     SortField.EqualsNoCase(nameof(Property.EndDate));
    }
}

using System.Text.Json.Serialization;

namespace RealEstateAgencySystem.Models
{
    public class PropertyGridData : GridData
    {
        // set initial sort field in constructor
        public PropertyGridData() => SortField = nameof(Property.PropertyId);

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

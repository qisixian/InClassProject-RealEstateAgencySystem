using System.Text.Json.Serialization;
using System.Linq.Expressions;
using RealEstateAgencySystem.Models;

namespace RealEstateAgencySystem.Models
{
    public class PropertyGridData : GridData
    {
        // set initial sort field in constructor
        public PropertyGridData() => SortField = nameof(Property.ListingDate);

        public PropertyFilters Filters { get; set; } = new PropertyFilters();

        // sort flags
        [JsonIgnore]
        public bool IsSortByPropertyType =>
            SortField.EqualsNoCase(nameof(Property.PropertyType));
        [JsonIgnore]
        public bool IsSortByBuildYear =>
            SortField.EqualsNoCase(nameof(Property.BuildYear));
        [JsonIgnore]
        public bool IsSortBySizeOfHouse =>
            SortField.EqualsNoCase(nameof(Property.SizeOfHouse));
        [JsonIgnore]
        public bool IsSortByBedrooms =>
            SortField.EqualsNoCase(nameof(Property.Bedrooms));
        [JsonIgnore]
        public bool IsSortByBathrooms =>
            SortField.EqualsNoCase(nameof(Property.Bathrooms));
        [JsonIgnore]
        public bool IsSortByCurrentStatus =>
            SortField.EqualsNoCase(nameof(Property.CurrentStatus));
        [JsonIgnore]
        public bool IsSortByListingDate =>
            SortField.EqualsNoCase(nameof(Property.ListingDate));
        [JsonIgnore]
        public bool IsSortByRentalPrice =>
            SortField.EqualsNoCase(nameof(Property.RentalPrice));
        [JsonIgnore]
        public bool IsSortBySellingPrice =>
            SortField.EqualsNoCase(nameof(Property.SellingPrice));
    }
}

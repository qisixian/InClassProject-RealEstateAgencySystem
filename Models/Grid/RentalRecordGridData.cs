using System.Text.Json.Serialization;

namespace RealEstateAgencySystem.Models
{
    public class RentalRecordGridData : GridData
    {
        // set initial sort field in constructor
        public RentalRecordGridData() => SortField = nameof(RentalRecord.StartDate);

        // sort flags
        [JsonIgnore]
        public bool IsSortByRentalPrice =>
            SortField.EqualsNoCase(nameof(RentalRecord.RentalPrice));
        [JsonIgnore]
        public bool IsSortByDepositPrice =>
            SortField.EqualsNoCase(nameof(RentalRecord.DepositPrice));
        [JsonIgnore]
        public bool IsSortByEndDate =>
            SortField.EqualsNoCase(nameof(RentalRecord.EndDate));
    }
}

using System.Text.Json.Serialization;

namespace RealEstateAgencySystem.Models
{
    public class RentalContractGridData : GridData
    {
        // set initial sort field in constructor
        public RentalContractGridData() => SortField = nameof(RentalContract.StartDate);

        // sort flags
        [JsonIgnore]
        public bool IsSortByRentalPrice =>
            SortField.EqualsNoCase(nameof(RentalContract.RentalPrice));
        [JsonIgnore]
        public bool IsSortByDepositPrice =>
            SortField.EqualsNoCase(nameof(RentalContract.DepositPrice));
        [JsonIgnore]
        public bool IsSortByEndDate =>
            SortField.EqualsNoCase(nameof(RentalContract.EndDate));
    }
}

using System.Text.Json.Serialization;

namespace RealEstateAgencySystem.Models
{
    public class SalesContractGridData : GridData
    {
        // set initial sort field in constructor
        public SalesContractGridData() => SortField = nameof(SalesContract.TransactionDate);

        // sort flags
        [JsonIgnore]
        public bool IsSortBySalePrice =>
            SortField.EqualsNoCase(nameof(SalesContract.SalePrice));
        // [JsonIgnore]
        // public bool IsSortByPrice =>
        //     SortField.EqualsNoCase(nameof(Book.Price));
    }
}

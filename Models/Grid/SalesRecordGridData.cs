using System.Text.Json.Serialization;

namespace RealEstateAgencySystem.Models
{
    public class SalesRecordGridData : GridData
    {
        // set initial sort field in constructor
        public SalesRecordGridData() => SortField = nameof(SalesRecord.TransactionDate);

        // sort flags
        [JsonIgnore]
        public bool IsSortBySalePrice =>
            SortField.EqualsNoCase(nameof(SalesRecord.SalePrice));
        // [JsonIgnore]
        // public bool IsSortByPrice =>
        //     SortField.EqualsNoCase(nameof(Book.Price));
    }
}

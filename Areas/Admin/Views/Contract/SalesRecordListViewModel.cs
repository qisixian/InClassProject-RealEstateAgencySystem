using RealEstateAgencySystem.Models;

namespace RealEstateAgencySystem.Areas.Admin.Views
{
    public class SalesRecordListViewModel
    {
        public IEnumerable<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();
        public SalesRecordGridData CurrentRoute { get; set; } = new SalesRecordGridData();
        public int TotalPages { get; set; }
    }
}
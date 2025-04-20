using RealEstateAgencySystem.Models;

namespace RealEstateAgencySystem.Areas.Admin.Views
{
    public class RentalRecordListViewModel
    {
        public IEnumerable<RentalRecord> RentalRecords { get; set; } = new List<RentalRecord>();
        public RentalRecordGridData CurrentRoute { get; set; } = new RentalRecordGridData();
        public int TotalPages { get; set; }
    }
}
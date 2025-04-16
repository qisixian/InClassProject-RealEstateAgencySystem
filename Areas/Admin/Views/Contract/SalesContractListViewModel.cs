using RealEstateAgencySystem.Models;

namespace RealEstateAgencySystem.Areas.Admin.Views
{
    public class SalesContractListViewModel
    {
        public IEnumerable<SalesContract> SalesContracts { get; set; } = new List<SalesContract>();
        public SalesContractGridData CurrentRoute { get; set; } = new SalesContractGridData();
        public int TotalPages { get; set; }
    }
}
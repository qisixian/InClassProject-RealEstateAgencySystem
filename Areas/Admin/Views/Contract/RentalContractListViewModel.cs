using RealEstateAgencySystem.Models;

namespace RealEstateAgencySystem.Areas.Admin.Views
{
    public class RentalContractListViewModel
    {
        public IEnumerable<RentalContract> RentalContracts { get; set; } = new List<RentalContract>();
        public RentalContractGridData CurrentRoute { get; set; } = new RentalContractGridData();
        public int TotalPages { get; set; }
    }
}
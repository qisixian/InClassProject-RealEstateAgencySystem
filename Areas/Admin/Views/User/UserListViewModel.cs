using RealEstateAgencySystem.Models;

namespace RealEstateAgencySystem.Areas.Admin.Views
{
    public class UserListViewModel
    {
        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
        public CustomerGridData CurrentRoute { get; set; } = new CustomerGridData();
        public int TotalPages { get; set; }
    }
}
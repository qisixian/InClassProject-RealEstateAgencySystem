using RealEstateAgencySystem.Models;

namespace RealEstateAgencySystem.Views
{
    public class PropertyListViewModel
    {
        public IEnumerable<Property> Properties { get; set; } = new List<Property>();
        public PropertyGridData CurrentRoute { get; set; } = new PropertyGridData();
        public int TotalPages { get; set; }
    }
}
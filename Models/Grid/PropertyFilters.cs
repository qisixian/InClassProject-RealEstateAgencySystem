using System.Linq.Expressions;
namespace RealEstateAgencySystem.Models
{
    public class PropertyFilters
    {

        public string[] countries = { "Canada" };
        public string[] provinces = { "BC" };
        public string[] cities = { "Vancouver", "North Vancouver", "West Vancouver", "Burnaby", "New Westminster", "Richmond", "Delta", "Coquitlam", "Surrey", "Langley" };
        public string[] statuses = { "For Sale", "For Rent", "Sold", "Rented" };
        public string[] propertyTypes = { "House", "Apartment", "Condo", "Townhouse", "Basement Suite", "Duplex" };
        public HashSet<string>? filteredCountries = new HashSet<string>();
        public HashSet<string>? filteredProvinces = new HashSet<string>();
        public HashSet<string>? filteredCities = new HashSet<string>();
        public HashSet<string>? filteredStatuses = new HashSet<string>();
        public HashSet<string>? filteredPropertyTypes = new HashSet<string>();

        public string? PostalCode { get; set; }
        public string? PropertyAddress { get; set; }

        public decimal? MaxRentalPrice { get; set; }
        public decimal? MinRentalPrice { get; set; }

        public decimal? MaxSellingPrice { get; set; }
        public decimal? MinSellingPrice { get; set; }

        public int? MinSize { get; set; }
        public int? MaxSize { get; set; }

        public int? MinBuildYear { get; set; }
        public int? MaxBuildYear { get; set; }

        public int? MinBedrooms { get; set; }
        public int? MaxBedrooms { get; set; }

        public int? MinBathrooms { get; set; }
        public int? MaxBathrooms { get; set; }

        public List<Expression<Func<Property, bool>>> buildFilters(){
            List<Expression<Func<Property, bool>>> filters = new List<Expression<Func<Property, bool>>>();

            if (filteredCountries != null && filteredCountries.Count > 0)
            {
                filters.Add(p => filteredCountries.Contains(p.Country));
            }
            if (filteredProvinces != null && filteredProvinces.Count > 0)
            {
                filters.Add(p => filteredProvinces.Contains(p.Province));
            }
            if (filteredCities != null && filteredCities.Count > 0)
            {
                filters.Add(p => filteredCities.Contains(p.City));
            }
            if (filteredStatuses != null && filteredStatuses.Count > 0)
            {
                filters.Add(p => filteredStatuses.Contains(p.CurrentStatus));
            }
            if (filteredPropertyTypes != null && filteredPropertyTypes.Count > 0)
            {
                filters.Add(p => filteredPropertyTypes.Contains(p.PropertyType));
            }
            if (PostalCode != null)
            {
                filters.Add(p => p.PostalCode.Contains(PostalCode));
            }
            if (PropertyAddress != null)
            {
                filters.Add(p => p.PropertyAddress.Contains(PropertyAddress));
            }
            if (MaxRentalPrice != null)
            {
                filters.Add(p => p.RentalPrice <= MaxRentalPrice);
            }
            if (MinRentalPrice != null)
            {
                filters.Add(p => p.RentalPrice >= MinRentalPrice);
            }
            if (MaxSellingPrice != null)
            {
                filters.Add(p => p.SellingPrice <= MaxSellingPrice);
            }
            if (MinSellingPrice != null)
            {
                filters.Add(p => p.SellingPrice >= MinSellingPrice);
            }
            if (MinSize != null)
            {
                filters.Add(p => p.SizeOfHouse >= MinSize);
            }
            if (MaxSize != null)
            {
                filters.Add(p => p.SizeOfHouse <= MaxSize);
            }
            if (MinBuildYear != null)
            {
                filters.Add(p => p.BuildYear >= MinBuildYear);
            }
            if (MaxBuildYear != null)
            {
                filters.Add(p => p.BuildYear <= MaxBuildYear);
            }
            if (MinBedrooms != null)
            {
                filters.Add(p => p.Bedrooms >= MinBedrooms);
            }
            if (MaxBedrooms != null)
            {
                filters.Add(p => p.Bedrooms <= MaxBedrooms);
            }
            if (MinBathrooms != null)
            {
                filters.Add(p => p.Bathrooms >= MinBathrooms);
            }
            if (MaxBathrooms != null)
            {
                filters.Add(p => p.Bathrooms <= MaxBathrooms);
            }
            return filters;
        }

        public string ToString()
        {
            return $"PropertyFilters: PostalCode: {PostalCode}, PropertyAddress: {PropertyAddress}, MaxRentalPrice: {MaxRentalPrice}, MinRentalPrice: {MinRentalPrice}, MaxSellingPrice: {MaxSellingPrice}, MinSellingPrice: {MinSellingPrice}, MinSize: {MinSize}, MaxSize: {MaxSize}, MinBuildYear: {MinBuildYear}, MaxBuildYear: {MaxBuildYear}, MinBedrooms: {MinBedrooms}, MaxBedrooms: {MaxBedrooms}, MinBathrooms: {MinBathrooms}, MaxBathrooms: {MaxBathrooms}, filteredCountries: {string.Join(", ", filteredCountries)}, filteredProvinces: {string.Join(", ", filteredProvinces)}, filteredCities: {string.Join(", ", filteredCities)}, filteredStatuses: {string.Join(", ", filteredStatuses)}, filteredPropertyTypes: {string.Join(", ", filteredPropertyTypes)}";
        }
    }
}
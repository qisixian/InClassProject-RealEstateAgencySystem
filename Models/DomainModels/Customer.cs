using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;  // for NotMapped

namespace RealEstateAgencySystem.Models
{
    public class Customer : IdentityUser
    {
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;
        
        
        [Required(ErrorMessage = "Contact address is required")]
        [StringLength(200, ErrorMessage = "Contact address cannot exceed 200 characters")]
        public string ContactAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required")]
        [StringLength(10, ErrorMessage = "Postal code cannot exceed 10 characters")]
        public string PostalCode { get; set; } = string.Empty;


        [NotMapped]
        public IList<string> RoleNames { get; set; } = null!;

        
        // Navigation property
        // Properties owned by this customer
        public ICollection<Property> OwnedProperties { get; set; } = new List<Property>();
        
        // Sales contracts where the customer is the owner/seller
        public ICollection<SalesRecord> SalesAsOwner { get; set; } = new List<SalesRecord>();
        
        // Sales contracts where the customer is the buyer
        public ICollection<SalesRecord> SalesAsBuyer { get; set; } = new List<SalesRecord>();
        
        // Rental contracts where the customer is the property owner
        public ICollection<RentalRecord> RentalsAsOwner { get; set; } = new List<RentalRecord>();
        
        // Rental contracts where the customer is the tenant
        public ICollection<RentalRecord> RentalsAsTenant { get; set; } = new List<RentalRecord>();
    }
}

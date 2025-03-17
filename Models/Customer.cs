using System.ComponentModel.DataAnnotations;

namespace RealEstateAgencySystem.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;
        
        [Phone]
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        public string Phone { get; set; } = string.Empty;
        
        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Contact address is required")]
        [StringLength(200, ErrorMessage = "Contact address cannot exceed 200 characters")]
        public string ContactAddress { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        // CreatTime & UpdateTime
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        
        // Navigation property
        // Properties owned by this customer
        public ICollection<Property> OwnedProperties { get; set; } = new List<Property>();
        
        // Sales contracts where the customer is the owner/seller
        public ICollection<SalesContract> SalesAsOwner { get; set; } = new List<SalesContract>();
        
        // Sales contracts where the customer is the buyer
        public ICollection<SalesContract> SalesAsBuyer { get; set; } = new List<SalesContract>();
        
        // Rental contracts where the customer is the property owner
        public ICollection<RentalContract> RentalsAsOwner { get; set; } = new List<RentalContract>();
        
        // Rental contracts where the customer is the tenant
        public ICollection<RentalContract> RentalsAsTenant { get; set; } = new List<RentalContract>();
        
    }
}
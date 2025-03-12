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
        
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } = string.Empty;
        
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
        
        // You might want to add navigation properties if this model relates to others
        // For example:
        // public virtual ICollection<Property> FavoriteProperties { get; set; } = new List<Property>();
    }
}
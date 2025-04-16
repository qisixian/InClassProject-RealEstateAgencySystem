using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencySystem.Models
{
    public class Property
    {
        [Key]
        public int PropertyID { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(100, ErrorMessage = "Country cannot exceed 100 characters")]
        public string Country { get; set; } = string.Empty; 

        [Required(ErrorMessage = "Province is required")]
        [StringLength(100, ErrorMessage = "Province cannot exceed 100 characters")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required")]
        [StringLength(10, ErrorMessage = "Postal code cannot exceed 10 characters")]    
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Property address is required")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string PropertyAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Property type is required")]
        [StringLength(100, ErrorMessage = "Property type cannot exceed 100 characters")]
        [Display(Name = "Property Type")]
        public string PropertyType { get; set; } = string.Empty; // e.g., "House", "Apartment", "Condo", "Townhouse"

        [Required(ErrorMessage = "Build year is required")]
        [Range(1800, 2100, ErrorMessage = "Please enter a valid build year")]
        public int BuildYear { get; set; }
        
        [Required(ErrorMessage = "Size of house is required")]
        [Range(1, 100000, ErrorMessage = "Please enter a valid size")]
        [Display(Name = "Size (sq ft)")]
        public double SizeOfHouse { get; set; }
        
        [Required(ErrorMessage = "Number of bedrooms is required")]
        [Range(1, 30, ErrorMessage = "Please enter a valid number of bedrooms")]
        [Display(Name = "Number of Bedrooms")]
        public int Bedrooms { get; set; }

        [Required(ErrorMessage = "Number of bathrooms is required")]
        [Range(1, 30, ErrorMessage = "Please enter a valid number of bathrooms")]
        [Display(Name = "Number of Bathrooms")]
        public int Bathrooms { get; set; }
        
        [Required(ErrorMessage = "Current status is required")]
        public string CurrentStatus { get; set; } = string.Empty; // e.g., "For Sale", "For Rent", "Sold", "Rented"

        
        [Required(ErrorMessage = "Listing date is required")]
        [DataType(DataType.Date)]
        public DateTime ListingDate { get; set; } = DateTime.Now;
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Rental Price")]
        public decimal? RentalPrice { get; set; }
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Selling Price")]
        public decimal? SellingPrice { get; set; }
                
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;
        
        // Optional
        public int? OwnerCustomerID { get; set; }
        
        // Navigation properties
        public ICollection<Image> Images { get; set; } = new List<Image>();

        public PropertyAmenities PropertyAmenities { get; set; }
        
        public ICollection<SalesContract> SalesContracts { get; set; } = new List<SalesContract>();
        
        public ICollection<RentalContract> RentalContracts { get; set; } = new List<RentalContract>();
        
        [ForeignKey(nameof(OwnerCustomerID))]
        public Customer Owner { get; set; }
    }
}
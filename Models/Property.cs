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
        
        [Required(ErrorMessage = "Current status is required")]
        public string CurrentStatus { get; set; } = string.Empty; // e.g., "For Sale", "For Rent", "Sold", "Rented"
        
        [Required(ErrorMessage = "Property address is required")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string PropertyAddress { get; set; } = string.Empty;
        
        [Range(1800, 2100, ErrorMessage = "Please enter a valid build year")]
        public int BuildYear { get; set; }
        
        [Required(ErrorMessage = "Size of house is required")]
        [Range(1, 100000, ErrorMessage = "Please enter a valid size")]
        [Display(Name = "Size (sq ft)")]
        public double SizeOfHouse { get; set; }
        
        [Display(Name = "Layout/Floor Plan")]
        public string LayoutFloorPlan { get; set; } = string.Empty;
        
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
        
        // Additional useful properties
        public int Bedrooms { get; set; }
        
        public int Bathrooms { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;
        
        public bool HasGarage { get; set; } = false;
        
        public bool HasGarden { get; set; } = false;
        
        // Navigation properties
        public ICollection<Image> Images { get; set; } = new List<Image>();
        
        public ICollection<SalesContract> SalesContracts { get; set; } = new List<SalesContract>();
        
        public ICollection<RentalContract> RentalContracts { get; set; } = new List<RentalContract>();
        
        // Optional - Owner reference
        public int? OwnerCustomerID { get; set; }
        
        [ForeignKey("OwnerCustomerID")]
        public Customer Owner { get; set; }
    }
}
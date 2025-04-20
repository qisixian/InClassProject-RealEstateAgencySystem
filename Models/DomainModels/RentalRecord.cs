using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencySystem.Models
{
    public class RentalRecord
    {
        [Key]
        public int RentalRecordId { get; set; }
        
        [Required(ErrorMessage = "Owner Id is required")]
        public required string OwnerCustomerId { get; set; }
        
        [Required(ErrorMessage = "Tenant Id is required")]
        public required string TenantCustomerId { get; set; }
        
        [Required(ErrorMessage = "Property Id is required")]
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "Contract terms is required")]
        [DataType(DataType.MultilineText)]
        public string ContractTerms { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Rental price is required")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RentalPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DepositPrice { get; set; }
        
        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        
        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public bool IsFinalized { get; set; } = true;
        
        // Navigation properties
        [ForeignKey(nameof(OwnerCustomerId))]
        public Customer? OwnerCustomer { get; set; }
        
        [ForeignKey(nameof(TenantCustomerId))]
        public Customer? TenantCustomer { get; set; }
        
        [ForeignKey(nameof(PropertyId))]
        public Property? Property { get; set; }

    }
}
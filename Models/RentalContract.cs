using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencySystem.Models
{
    public class RentalContract
    {
        [Key]
        public int RentalContractID { get; set; }
        
        [Required(ErrorMessage = "Owner ID is required")]
        public int OwnerCustomerID { get; set; }
        
        [Required(ErrorMessage = "Tenant ID is required")]
        public int TenantCustomerID { get; set; }
        
        [Required(ErrorMessage = "Property ID is required")]
        public int PropertyID { get; set; }
        
        [Required(ErrorMessage = "Rental price is required")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RentalPrice { get; set; }
        
        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        
        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        
        // Navigation properties
        [ForeignKey("OwnerCustomerID")]
        public Customer OwnerCustomer { get; set; }
        
        [ForeignKey("TenantCustomerID")]
        public Customer TenantCustomer { get; set; }
        
        [ForeignKey("PropertyID")]
        public Property Property { get; set; }
        
        // Additional useful properties
        public string ContractNumber { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string ContractTerms { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Property to check if contract is current
        [NotMapped]
        public bool IsCurrent => DateTime.Now >= StartDate && DateTime.Now <= EndDate;
        
        // Deposit information
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SecurityDeposit { get; set; }
        
        public bool IsDepositReturned { get; set; } = false;
    }
}
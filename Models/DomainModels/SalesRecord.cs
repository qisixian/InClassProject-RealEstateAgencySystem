using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencySystem.Models
{
    public class SalesRecord
    {
        [Key]
        public int SalesRecordId { get; set; }
        
        [Required(ErrorMessage = "Owner/Party A Customer Id is required")]
        public string OwnerCustomerId { get; set; }
        
        [Required(ErrorMessage = "Buyer/Party B Customer Id is required")]
        public string BuyerCustomerId { get; set; }
        
        [Required(ErrorMessage = "Property Id is required")]
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "Contract terms is required")]
        [DataType(DataType.MultilineText)]
        public string ContractTerms { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Sale price is required")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SalePrice { get; set; }
        
        [Required(ErrorMessage = "Transaction date is required")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        
        public bool IsFinalized { get; set; } = false;
        
        // Navigation properties
        [ForeignKey(nameof(OwnerCustomerId))]
        public Customer? OwnerCustomer { get; set; }
        
        [ForeignKey(nameof(BuyerCustomerId))]
        public Customer? BuyerCustomer { get; set; }
        
        [ForeignKey(nameof(PropertyId))]
        public Property? Property { get; set; }
    }
}
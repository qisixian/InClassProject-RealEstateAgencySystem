using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencySystem.Models
{
    public class SalesContract
    {
        [Key]
        public int SalesContractID { get; set; }
        
        [Required(ErrorMessage = "Owner/Party A Customer ID is required")]
        public int OwnerCustomerID { get; set; }
        
        [Required(ErrorMessage = "Buyer/Party B Customer ID is required")]
        public int BuyerCustomerID { get; set; }
        
        [Required(ErrorMessage = "Property ID is required")]
        public int PropertyID { get; set; }

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

        // CreatTime & LastModifiedTime
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        // Navigation properties
        [ForeignKey(nameof(OwnerCustomerID))]
        public Customer OwnerCustomer { get; set; }
        
        [ForeignKey(nameof(BuyerCustomerID))]
        public Customer BuyerCustomer { get; set; }
        
        [ForeignKey(nameof(PropertyID))]
        public Property Property { get; set; }
    }
}
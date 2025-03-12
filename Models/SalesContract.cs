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
        
        [Required(ErrorMessage = "Sale price is required")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SalePrice { get; set; }
        
        [Required(ErrorMessage = "Transaction date is required")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        
        // Navigation properties
        [ForeignKey("OwnerCustomerID")]
        public Customer OwnerCustomer { get; set; }
        
        [ForeignKey("BuyerCustomerID")]
        public Customer BuyerCustomer { get; set; }
        
        [ForeignKey("PropertyID")]
        public Property Property { get; set; }
        
        // Optional additional properties
        public string ContractNumber { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string ContractTerms { get; set; }
        
        public bool IsFinalized { get; set; } = false;
    }
}
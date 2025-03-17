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

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DepositPrice { get; set; }
        
        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        
        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public bool IsFinalized { get; set; } = true;

        // CreatTime & UpdateTime
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        
        // Navigation properties
        [ForeignKey(nameof(OwnerCustomerID))]
        public Customer OwnerCustomer { get; set; }
        
        [ForeignKey(nameof(TenantCustomerID))]
        public Customer TenantCustomer { get; set; }
        
        [ForeignKey(nameof(PropertyID))]
        public Property Property { get; set; }

    }
}
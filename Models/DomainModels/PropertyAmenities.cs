using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencySystem.Models
{
    public class PropertyAmenities
    {   
        [Key]
        public int PropertyAmenitiesId { get; set; }

        [Required]
        public int PropertyId { get; set; }
        
        public bool Elevator { get; set; } = false;
        
        public bool Refrigerator { get; set; } = false;
        
        public bool Cooktop { get; set; } = false;
        
        public bool Microwave { get; set; } = false;
        
        public bool Dishwasher { get; set; } = false;
        
        [Display(Name = "Fire Sprinkler System")]
        public bool FireSprinklerSystem { get; set; } = false;
        
        public bool Washer { get; set; } = false;
        
        public bool Dryer { get; set; } = false;
        
        public bool Heating { get; set; } = false;

        [Display(Name = "Air Conditioning")]
        public bool AirConditioning { get; set; } = false;
        
        [Display(Name = "Security System")]
        public bool SecuritySystem { get; set; } = false;
        
        [Display(Name = "Pet Friendly")]
        public bool PetFriendly { get; set; } = false;
        
        [Display(Name = "Fitness Room")]
        public bool FitnessRoom { get; set; } = false;
        
        [Display(Name = "Swimming Pool")]
        public bool SwimmingPool { get; set; } = false;
        
        [Display(Name = "Parking Lot")]
        public bool ParkingLot { get; set; } = false;
        
        public bool Locker { get; set; } = false;
        
        [DataType(DataType.MultilineText)]
        [Display(Name = "Other Amenities")]
        public string? OtherAmenities { get; set; } = string.Empty;
        
        // Navigation property
        [ForeignKey(nameof(PropertyId))]
        public Property? Property { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDto
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name must be min 2 character length", MinimumLength = 2)]
        public string Name { get; set; } = default!;
        [Required]
        public string? Description { get; set; }
        public string? About { get; set; }

        [StringLength(12, MinimumLength = 8)]
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }

        public string? EncodedName { get; set; }
    }
}

using Application.Addresses.Create;
using System.ComponentModel.DataAnnotations;

namespace Application.Properties.Create
{
    public class PropertyDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string CodeInternal { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int IdOwner { get; set; }
        [Required]
        public AddressDto Addresses { get; set; }
    }
}

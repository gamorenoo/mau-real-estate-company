using Application.Common.Mappings;
using Domain.Addresses;
using System.ComponentModel.DataAnnotations;

namespace Application.Addresses.Create
{
    public class AddressDto : IMapFrom<Address>
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}

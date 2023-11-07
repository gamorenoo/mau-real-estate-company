using Application.Addresses.Create;
using Application.Common.Mappings;
using Application.Owners.Create;
using Application.PropertyImages.Create;
using Domain.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Properties.Create
{
    public class PropertyOutDto : IMapFrom<Property>
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
        public AddressDto Address { get; set; }
        public OwnerDto Owner { get; set; }
        public List<PropertyImageOutDto> Images { get; set; } 

        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public Guid RowVersion { get; set; }

    }
}

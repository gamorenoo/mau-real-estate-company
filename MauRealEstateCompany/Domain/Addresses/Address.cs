using Domain.Owners;
using Domain.Properties;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Addresses
{
    public class Address
    {
        public int IdAddres { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        [ForeignKey(nameof(IdProperty))]
        public int? IdProperty { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public int? OwnerId { get; set; }

        public virtual Property Property { get; set; }
        public virtual Owner Owner { get; set; }
    }
}

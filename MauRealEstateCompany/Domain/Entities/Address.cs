using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address
    {
        public int IdAddres { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public String ZipCode { get; set; }
        [ForeignKey(nameof(IdProperty))]
        public int? IdProperty { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public int? OwnerId { get; set; }

        public virtual Property Property { get; set; }
        public virtual Owner Owner { get; set; }
    }
}

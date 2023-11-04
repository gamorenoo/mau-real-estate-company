using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PropertyImage: AuditableEntity
    {
        public int IdPropertyImage { get; set; }
        [ForeignKey(nameof(IdProperty))]
        public int IdProperty { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
        public virtual Property Property { get; set; }
    }
}

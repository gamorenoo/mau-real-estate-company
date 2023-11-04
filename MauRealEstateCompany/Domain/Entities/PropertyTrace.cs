using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PropertyTrace: AuditableEntity
    {
        public int IdPropertyTrace { get; set; }
        [ForeignKey(nameof(IdProperty))]
        public int IdProperty { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public virtual Property Property { get; set; }
    }
}

using Domain.Common;
using Domain.Properties;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.PropertyTraces
{
    public class PropertyTrace : AuditableEntity
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

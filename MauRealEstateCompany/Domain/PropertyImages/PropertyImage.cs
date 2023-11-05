using Domain.Common;
using Domain.Properties;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.PropertyImages
{
    public class PropertyImage : AuditableEntity
    {
        public int IdPropertyImage { get; set; }
        [ForeignKey(nameof(IdProperty))]
        public int IdProperty { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
        public virtual Property Property { get; set; }
    }
}

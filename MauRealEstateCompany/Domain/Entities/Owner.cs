using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Owner: AuditableEntity
    {
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}

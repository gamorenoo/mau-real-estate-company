﻿using Domain.Addresses;
using Domain.Common;
using Domain.Owners;
using Domain.PropertyImages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Properties
{
    public class Property : AuditableEntity
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        [ForeignKey(nameof(IdOwner))]
        public int IdOwner { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<PropertyImage> Images { get; set; }
    }
}

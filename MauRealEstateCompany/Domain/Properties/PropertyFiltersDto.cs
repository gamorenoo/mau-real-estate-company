using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Properties
{
    public class PropertyFiltersDto
    {
        public int? IdProperty { get; set; }
        public int? IdOwner { get; set; }
        public string? NameOwner { get; set; }
        public string? NameProperty { get; set; }
        public decimal? Price { get; set; }
        public string? CodeInternal { get; set; }
        public int? Year { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Properties.ChangePrice
{
    public class PropertyPriceDto
    {
        [Required]
        public int IdProperty { get; set; }
        [Required]
        public decimal NewPrice { get; set; }
    }
}

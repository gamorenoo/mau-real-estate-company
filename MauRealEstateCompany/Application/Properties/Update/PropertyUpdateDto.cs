using Application.Properties.Create;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Properties.Update
{
    public class PropertyUpdateDto: PropertyDto
    {
        [Required]
        public int IdProperty { get; set; }

    }
}

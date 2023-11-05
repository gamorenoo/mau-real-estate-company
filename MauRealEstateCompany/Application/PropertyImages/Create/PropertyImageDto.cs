using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.PropertyImages.Create
{
    public class PropertyImageDto
    {
        [Required]
        public int IdProperty { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}

using Application.Common.Mappings;
using Domain.PropertyImages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PropertyImages.Create
{
    public  class PropertyImageOutDto: IMapFrom<PropertyImage>
    {
        public int IdPropertyImage { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
    }
}

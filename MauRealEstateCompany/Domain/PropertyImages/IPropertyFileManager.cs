using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PropertyImages
{
    public interface IPropertyFileManager
    {
        /// <summary>
        /// Upload Image on Sevrer File Manager To Property
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="path"></param>
        /// <param name="IdProperty"></param>
        /// <returns></returns>
        string SaveImageInServer(IFormFile formFile, string path, int IdProperty);
    }
}

using Domain.PropertyImages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FileManager
{
    public class PropertyFileManager : IPropertyFileManager
    {
        public PropertyFileManager()
        { 

        }

        /// <inheritdoc/>
        public string SaveImageInServer(IFormFile formFile, string path, int IdProperty)
        {
            string pathImage = Path.Combine(path, IdProperty.ToString());

            if (!Directory.Exists(pathImage))
            {
                Directory.CreateDirectory(pathImage);
            }

            pathImage = Path.Combine(pathImage, formFile.FileName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var stream = new FileStream(pathImage, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }

            return pathImage;
        }
    }
}

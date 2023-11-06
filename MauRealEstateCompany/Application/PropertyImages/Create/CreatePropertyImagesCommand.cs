using Application.Addresses.Create;
using AutoMapper.Configuration.Annotations;
using Domain.Addresses;
using Domain.PropertyImages;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.PropertyImages.Create
{
    public class CreatePropertyImagesCommand : IRequest<PropertyImage>
    {
        public PropertyImageDto PropertyImage { get; set; }
        [Ignore]
        public string PathToSaveImage{ get; set; }
    }

    public class CreatePropertyImagesCommandHandler : IRequestHandler<CreatePropertyImagesCommand, PropertyImage>
    {
        private readonly IPropertyImageCommandRepository _propertyImageCommandRepository;

        public CreatePropertyImagesCommandHandler(IPropertyImageCommandRepository propertyImageCommandRepository)
        {
            _propertyImageCommandRepository = propertyImageCommandRepository;
        }

        public async Task<PropertyImage> Handle(CreatePropertyImagesCommand request, CancellationToken cancellationToken)
        {
            string imagePath = SaveImageInServer(request.PropertyImage.ImageFile, request.PathToSaveImage, request.PropertyImage.IdProperty);
            PropertyImage propertyImage = new PropertyImage()
            {
                IdProperty = request.PropertyImage.IdProperty,
                File = imagePath,
                Enabled = true,
            };

            return await _propertyImageCommandRepository.CreateAsync(propertyImage);
        }

        private string SaveImageInServer(IFormFile formFile, string path, int IdProperty) {
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

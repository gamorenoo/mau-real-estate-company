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
        private readonly IPropertyFileManager _propertyFileManager;

        public CreatePropertyImagesCommandHandler(IPropertyImageCommandRepository propertyImageCommandRepository, IPropertyFileManager propertyFileManager)
        {
            _propertyImageCommandRepository = propertyImageCommandRepository;
            _propertyFileManager = propertyFileManager;
        }

        public async Task<PropertyImage> Handle(CreatePropertyImagesCommand request, CancellationToken cancellationToken)
        {
            string imagePath = _propertyFileManager.SaveImageInServer(request.PropertyImage.ImageFile, request.PathToSaveImage, request.PropertyImage.IdProperty);
            PropertyImage propertyImage = new PropertyImage()
            {
                IdProperty = request.PropertyImage.IdProperty,
                File = imagePath,
                Enabled = true,
            };

            return await _propertyImageCommandRepository.CreateAsync(propertyImage);
        }
    }
}

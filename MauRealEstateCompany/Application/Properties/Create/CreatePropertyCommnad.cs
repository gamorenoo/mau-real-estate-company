using Application.Addresses.Create;
using Domain.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Properties.Create
{
    public class CreatePropertyCommnad: IRequest<Property>
    {
        public PropertyDto Property { get; set; }
    }


    public class CreatePropertyCommnadHandler : IRequestHandler<CreatePropertyCommnad, Property>
    {
        private readonly IPropertyCommandRepository _propertyRepository;
        private readonly MediatR.ISender _sender;

        public CreatePropertyCommnadHandler(IPropertyCommandRepository propertyRepository, MediatR.ISender sender)
        {
            _sender = sender;
            _propertyRepository = propertyRepository;
        }

        public async Task<Property> Handle(CreatePropertyCommnad request, CancellationToken cancellationToken)
        {
            Property Property = new Property() { 
                Name = request.Property.Name,
                CodeInternal = request.Property.CodeInternal,
                Year = request.Property.Year,
                IdOwner = request.Property.IdOwner,
                Price = request.Property.Price,
            };

            var property = await _propertyRepository.CreateAsync(Property);

            CreateAddressCommand commandAddres = new CreateAddressCommand() { 
                Address = request.Property.Addresses,
                IdProperty = property.IdProperty
            };

            await _sender.Send(commandAddres);

            return property;
        }
    }
}

using Application.Addresses.Create;
using Application.Common.Exceptions;
using AutoMapper;
using Domain.Owners;
using Domain.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Properties.Create
{
    public class CreatePropertyCommnad: IRequest<PropertyOutDto>
    {
        public PropertyDto Property { get; set; }
    }


    public class CreatePropertyCommnadHandler : IRequestHandler<CreatePropertyCommnad, PropertyOutDto>
    {
        private readonly IPropertyCommandRepository _propertyRepository;
        private readonly IOwnerQueryRepository _ownerQueryRepository;
        private readonly MediatR.ISender _sender;
        private readonly IMapper _mapper;


        public CreatePropertyCommnadHandler(MediatR.ISender sender
            , IPropertyCommandRepository propertyRepository
            , IOwnerQueryRepository ownerQueryRepository
            , IMapper mapper)
        {
            _mapper = mapper;
            _sender = sender;
            _propertyRepository = propertyRepository;
            _ownerQueryRepository = ownerQueryRepository;
        }

        public async Task<PropertyOutDto> Handle(CreatePropertyCommnad request, CancellationToken cancellationToken)
        {
            var owner = await _ownerQueryRepository.GetByIdAsync(request.Property.IdOwner);
            if (owner == null)
            {
                throw new NotFoundException(nameof(Owner), request.Property.IdOwner);
            }

            Property Property = new Property() { 
                Name = request.Property.Name,
                CodeInternal = request.Property.CodeInternal,
                Year = request.Property.Year,
                IdOwner = request.Property.IdOwner,
                Price = request.Property.Price,
            };

            var property = await _propertyRepository.CreateAsync(Property);

            // Insert Address to Property
            CreateAddressCommand commandAddres = new CreateAddressCommand() { 
                Address = request.Property.Addresses,
                IdProperty = property.IdProperty
            };

            await _sender.Send(commandAddres);

            return _mapper.Map<PropertyOutDto>(property);
        }
    }
}

using Application.Addresses.Create;
using Application.Addresses.Delete;
using Application.Common.Exceptions;
using Application.Properties.Create;
using AutoMapper;
using Domain.Owners;
using Domain.Properties;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Properties.Update
{
    public class UpdatePropertyCommnad : IRequest<PropertyOutDto>
    {
        public PropertyUpdateDto Property { get; set; }

        public class UpdatePropertyCommnadCommnadHandler : IRequestHandler<UpdatePropertyCommnad, PropertyOutDto>
        {
            private readonly IPropertyCommandRepository _propertyCommandRepository;
            private readonly IPropertyQueryRepository _propertyQueryRepository;
            private readonly IOwnerQueryRepository _ownerQueryRepository;
            private readonly MediatR.ISender _sender;
            private readonly IMapper _mapper;

            public UpdatePropertyCommnadCommnadHandler(ISender sender
                , IPropertyQueryRepository propertyQueryRepository
                , IPropertyCommandRepository propertyCommandRepository
                , IOwnerQueryRepository ownerQueryRepository
                , IMapper mapper)
            {
                _mapper = mapper;
                _sender = sender;
                _propertyQueryRepository = propertyQueryRepository;
                _propertyCommandRepository = propertyCommandRepository;
                _ownerQueryRepository = ownerQueryRepository;
            }

            public async Task<PropertyOutDto> Handle(UpdatePropertyCommnad request, CancellationToken cancellationToken)
            {
                Domain.Properties.Property? property = await _propertyQueryRepository.GetByIdAsync(request.Property.IdProperty);

                if(property == null) {
                    throw new NotFoundException(nameof(Property), request.Property.IdProperty);
                }

                var owner = await _ownerQueryRepository.GetByIdAsync(request.Property.IdOwner);
                if (owner == null)
                {
                    throw new NotFoundException(nameof(Owner), request.Property.IdOwner);
                }

                property.Name = request.Property.Name;
                property.CodeInternal = request.Property.CodeInternal;
                property.Year = request.Property.Year;
                property.IdOwner = request.Property.IdOwner;
                property.Price = request.Property.Price;

                property = await _propertyCommandRepository.UpdateAsync(property);

                // Delete actual Address to property
                DeleteAddressByPropertyCommand deleteAddressByPropertyCommand = new DeleteAddressByPropertyCommand()
                { 
                    IdProperty = property.IdProperty
                };
                await _sender.Send(deleteAddressByPropertyCommand);

                // Insert new Address to property
                CreateAddressCommand commandAddAddres = new CreateAddressCommand()
                {
                    Address = request.Property.Addresses,
                    IdProperty = property.IdProperty
                };

                await _sender.Send(commandAddAddres);

                return _mapper.Map<PropertyOutDto>(property);
            }


        }

    }
}

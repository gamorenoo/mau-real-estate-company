using Application.Addresses.Create;
using Application.Addresses.Delete;
using Application.Properties.Create;
using Domain.Properties;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Properties.Update
{
    public class UpdatePropertyCommnad : IRequest<Domain.Properties.Property>
    {
        public PropertyUpdateDto Property { get; set; }

        public class UpdatePropertyCommnadCommnadHandler : IRequestHandler<UpdatePropertyCommnad, Domain.Properties.Property>
        {
            private readonly IPropertyCommandRepository _propertyCommandRepository;
            private readonly IPropertyQueryRepository _propertyQueryRepository;
            private readonly MediatR.ISender _sender;
            public UpdatePropertyCommnadCommnadHandler(ISender sender
                , IPropertyQueryRepository propertyQueryRepository
                , IPropertyCommandRepository propertyCommandRepository)
            {
                _sender = sender;
                _propertyQueryRepository = propertyQueryRepository;
                _propertyCommandRepository = propertyCommandRepository;
            }

            public async Task<Domain.Properties.Property> Handle(UpdatePropertyCommnad request, CancellationToken cancellationToken)
            {
                Domain.Properties.Property? property = await _propertyQueryRepository.GetByIdAsync(request.Property.IdProperty);

                if(property == null) {
                    throw new Exception($"The Property with Id: {request.Property.IdProperty} No found");
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

                return property;
            }


        }

    }
}

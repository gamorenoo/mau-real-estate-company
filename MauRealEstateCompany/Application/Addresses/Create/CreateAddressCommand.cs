using Application.Common.Exceptions;
using Application.Properties.Create;
using Domain.Addresses;
using Domain.Owners;
using Domain.Properties;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Addresses.Create
{
    public class CreateAddressCommand : IRequest<Address>
    {
        public AddressDto Address { get; set; }
        public int? IdProperty { get; set; }
        public int? IdOwner { get; set; }
    }

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Address>
    {
        private readonly IAddressCommandRepository _addressCommandRepository;
        private readonly IPropertyQueryRepository _propertyQueryRepository;
        private readonly IOwnerQueryRepository _ownerQueryRepository;

        public CreateAddressCommandHandler(IAddressCommandRepository addressCommandRepository
                , IPropertyQueryRepository propertyQueryRepository
                , IOwnerQueryRepository ownerQueryRepository)
        {
            _addressCommandRepository = addressCommandRepository;
            _ownerQueryRepository = ownerQueryRepository;
            _propertyQueryRepository = propertyQueryRepository;
        }

        public async Task<Address> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            if (request.IdOwner != null) await ValidateOwner(request.IdOwner.Value);

            if (request.IdProperty != null) await ValidateProperty(request.IdProperty.Value);

            Address address = new Address()
            {
                Street = request.Address.Street,
                City = request.Address.City,
                State = request.Address.State,
                Country = request.Address.Country,
                ZipCode = request.Address.ZipCode,
                IdProperty = request.IdProperty,
                OwnerId = request.IdOwner
            };

            return await _addressCommandRepository.CreateAsync(address);
        }

        private async Task ValidateProperty(int idPrperty)
        {
            var property = await _propertyQueryRepository.GetByIdAsync(idPrperty);
            if (property == null)
            {
                throw new NotFoundException(nameof(Property), idPrperty);
            }
        }

        private async Task ValidateOwner(int idOwner)
        {
            var owner = await _ownerQueryRepository.GetByIdAsync(idOwner);
            if (owner == null)
            {
                throw new NotFoundException(nameof(Owner), idOwner);
            }
        }
    }
}

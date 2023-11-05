using Application.Properties.Create;
using Domain.Addresses;
using MediatR;
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

        public CreateAddressCommandHandler(IAddressCommandRepository addressCommandRepository)
        {
            _addressCommandRepository = addressCommandRepository;
        }

        public async Task<Address> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
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
    }
}

using Application.Addresses.Create;
using Domain.Addresses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Addresses.Delete
{
    public class DeleteAddressByPropertyCommand : IRequest<int>
    {
        public int IdProperty { get; set; }
    }

    public class DeleteAddressByPropertyCommandHandler : IRequestHandler<DeleteAddressByPropertyCommand, int>
    {
        private readonly IAddressCommandRepository _addressCommandRepository;
        private readonly IAddressQueryRepository _addressQueryRepository;

        public DeleteAddressByPropertyCommandHandler(IAddressCommandRepository addressCommandRepository, IAddressQueryRepository addressQueryRepository)
        {
            _addressCommandRepository = addressCommandRepository;
            _addressQueryRepository = addressQueryRepository;
        }

        public async Task<int> Handle(DeleteAddressByPropertyCommand request, CancellationToken cancellationToken)
        {
            Address? address = await _addressQueryRepository.GetByIdProperty(request.IdProperty);

            if (address == null) return 0;

            return await _addressCommandRepository.DeleteAasync(address);
        }
    }
}

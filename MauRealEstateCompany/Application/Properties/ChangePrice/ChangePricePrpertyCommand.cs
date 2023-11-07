using Application.Common.Exceptions;
using Application.Properties.Create;
using AutoMapper;
using Domain.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Properties.ChangePrice
{
    public class ChangePricePrpertyCommand : IRequest<PropertyOutDto>
    {
        public PropertyPriceDto PropertyPrice { get; set; }
    }

    public class ChangePricePrpertyCommandHandler : IRequestHandler<ChangePricePrpertyCommand, PropertyOutDto>
    {
        private readonly IPropertyCommandRepository _propertyCommandRepository;
        private readonly IPropertyQueryRepository _propertyQueryRepository;
        private readonly IMapper _mapper;

        public ChangePricePrpertyCommandHandler(IPropertyCommandRepository propertyCommandRepository
            , IPropertyQueryRepository propertyQueryRepository
            , IMapper mapper)
        {
            _mapper = mapper;
            _propertyCommandRepository = propertyCommandRepository;
            _propertyQueryRepository = propertyQueryRepository;
        }

        public async Task<PropertyOutDto> Handle(ChangePricePrpertyCommand request, CancellationToken cancellationToken)
        {
            Property? property = await _propertyQueryRepository.GetByIdAsync(request.PropertyPrice.IdProperty);

            if (property == null)
            {
                throw new NotFoundException(nameof(Property), request.PropertyPrice.IdProperty);
            }

            property.Price = request.PropertyPrice.NewPrice;

            property = await _propertyCommandRepository.UpdateAsync(property);

            return _mapper.Map<PropertyOutDto>(property);
        }
    }

}

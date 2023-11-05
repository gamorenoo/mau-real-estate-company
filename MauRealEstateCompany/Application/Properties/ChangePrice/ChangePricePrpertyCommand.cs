using Application.Properties.Create;
using Domain.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Properties.ChangePrice
{
    public class ChangePricePrpertyCommand : IRequest<Property>
    {
        public PropertyPriceDto PropertyPrice { get; set; }
    }

    public class ChangePricePrpertyCommandHandler : IRequestHandler<ChangePricePrpertyCommand, Property>
    {
        private readonly IPropertyCommandRepository _propertyCommandRepository;
        private readonly IPropertyQueryRepository _propertyQueryRepository;

        public ChangePricePrpertyCommandHandler(IPropertyCommandRepository propertyCommandRepository
            , IPropertyQueryRepository propertyQueryRepository)
        {
            _propertyCommandRepository = propertyCommandRepository;
            _propertyQueryRepository = propertyQueryRepository;
        }

        public async Task<Property> Handle(ChangePricePrpertyCommand request, CancellationToken cancellationToken)
        {
            Property? property = await _propertyQueryRepository.GetByIdAsync(request.PropertyPrice.IdProperty);

            if (property == null)
            {
                throw new Exception($"The Property with Id: {request.PropertyPrice.IdProperty} No found");
            }

            property.Price = request.PropertyPrice.NewPrice;

            property = await _propertyCommandRepository.UpdateAsync(property);

            return property;
        }
    }

}

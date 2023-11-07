using Application.Properties.Create;
using AutoMapper;
using Domain.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Properties.ListWithFilters
{
    public class ListWithFiltersQuery : IRequest<IEnumerable<PropertyOutDto>>
    {
        public PropertyFiltersDto PropertyFilters { get; set; }
    }

    public class ListWithFiltersQueryHandler : IRequestHandler<ListWithFiltersQuery, IEnumerable<PropertyOutDto>>
    {
        private IPropertyQueryRepository _propertyQueryRepository;
        private readonly IMapper _mapper;

        public ListWithFiltersQueryHandler(IPropertyQueryRepository propertyQueryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _propertyQueryRepository = propertyQueryRepository;
        }

        public async Task<IEnumerable<PropertyOutDto>> Handle(ListWithFiltersQuery request, CancellationToken cancellationToken)
        {
            var properties = await _propertyQueryRepository.GetPropertiesWithFilterAsync(request.PropertyFilters);

            return _mapper.Map<IEnumerable<PropertyOutDto>>(properties);
        }
    }
}

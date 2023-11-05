using Domain.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Properties.ListWithFilters
{
    public class ListWithFiltersQuery : IRequest<IEnumerable<Property>>
    {
        public PropertyFiltersDto PropertyFilters { get; set; }
    }

    public class ListWithFiltersQueryHandler : IRequestHandler<ListWithFiltersQuery, IEnumerable<Property>>
    {
        private IPropertyQueryRepository _propertyQueryRepository;

        public ListWithFiltersQueryHandler(IPropertyQueryRepository propertyQueryRepository)
        {
            _propertyQueryRepository = propertyQueryRepository;
        }

        public async Task<IEnumerable<Property>> Handle(ListWithFiltersQuery request, CancellationToken cancellationToken)
        {
            return await _propertyQueryRepository.GetPropertiesWithFilterAsync(request.PropertyFilters);
        }
    }
}

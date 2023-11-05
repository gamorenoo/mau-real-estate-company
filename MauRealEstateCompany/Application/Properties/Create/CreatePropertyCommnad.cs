using Domain.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Properties.Create
{
    public class CreatePropertyCommnad: IRequest<Property>
    {
        public PropertyDto Property { get; set; }
    }


    public class CreatePropertyCommnadHandler : IRequestHandler<CreatePropertyCommnad, Property>
    {
        private readonly IPropertyRepository _propertyRepository;

        public CreatePropertyCommnadHandler(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Property> Handle(CreatePropertyCommnad request, CancellationToken cancellationToken)
        {
            Property Property = new Property() { 
                Name = request.Property.Name,
                CodeInternal = request.Property.CodeInternal,
                Year = request.Property.Year,
                IdOwner = request.Property.IdOwner,
                Price = request.Property.Price,
                //Created = DateTime.UtcNow,
                //CreatedBy = "gustavoamoreno@outlook.com",
                //RowVersion = Guid.NewGuid()
            };

            return await _propertyRepository.CreateAsync(Property);
        }
    }
}

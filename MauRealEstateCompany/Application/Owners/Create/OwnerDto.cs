using Application.Common.Mappings;
using Domain.Owners;

namespace Application.Owners.Create
{
    public class OwnerDto : IMapFrom<Owner>
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}

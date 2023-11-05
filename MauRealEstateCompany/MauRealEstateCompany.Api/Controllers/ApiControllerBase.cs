using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MauRealEstateCompany.Api.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}

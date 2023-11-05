using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MauRealEstateCompany.Api.Controllers
{
    /// <summary>
    /// Api Controller Base
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;
        /// <summary>
        /// 
        /// </summary>
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}

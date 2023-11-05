using Application.Properties.Create;
using Domain.Properties;
using MauRealEstateCompany.Api.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MauRealEstateCompany.Api.Controllers
{
    [Authorize]
    public class PropertyController : ApiControllerBase
    {
        private readonly ILogger<PropertyController> _logger;
        public PropertyController(ILogger<PropertyController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Create new property
        /// </summary>
        /// <remarks>
        ///    POST /Property
        ///    {
        ///      "name": "string",
        ///    "price": 0,
        ///    "codeInternal": "PP101",
        ///      "year": 0,
        ///      "idOwner": 1,
        ///    }
        /// </remarks>
        /// <param name="command">Property to create</param>
        /// <returns>Property createed</returns>
        /// <response code="200">Success</response>
        /// <response code="501">Error</response>
        [HttpPost("property", Name = "property")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Property>> Create([FromForm] CreatePropertyCommnad command)
        {
            return await Mediator.Send(command);
        }
    }
}

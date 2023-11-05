using Application.Properties.ChangePrice;
using Application.Properties.Create;
using Application.Properties.ListWithFilters;
using Application.Properties.Update;
using Domain.Properties;
using MauRealEstateCompany.Api.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MauRealEstateCompany.Api.Controllers
{
    // [Authorize]
    /// <summary>
    /// Property Controller
    /// </summary>
    [Route("api/")]
    public class PropertyController : ApiControllerBase
    {
        private readonly ILogger<PropertyController> _logger;

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="logger"></param>
        public PropertyController(ILogger<PropertyController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Create new Property
        /// </summary>
        /// <remarks>
        ///    POST /Property \
        ///    -F 'Property.CodeInternal=PP101' \
        ///    -F 'Property.Name=Propiedad de prueba 1' \
        ///    -F 'Property.Addresses.Street=Street 25' \
        ///    -F 'Property.Addresses.ZipCode=10010' \
        ///    -F 'Property.Addresses.State=New York' \
        ///    -F 'Property.Addresses.City=New York' \
        ///    -F 'Property.Price=350000.00' \
        ///    -F 'Property.Addresses.Country=USA' \
        ///    -F 'Property.Year=2020' \
        ///    -F 'Property.IdOwner=1
        /// </remarks>
        /// <param name="createPropertyCommnad">Property to create</param>
        /// <returns>Property createed</returns>
        /// <response code="200">Success</response>
        /// <response code="501">Error</response>
        [HttpPost("property", Name = "create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Property>> Create([FromForm] CreatePropertyCommnad createPropertyCommnad)
        {
            return await Mediator.Send(createPropertyCommnad);
        }


        /// <summary>
        /// Update existing Property
        /// </summary>
        /// <remarks>
        ///    PUT /Property \
        ///    -F 'Property.CodeInternal=PP101' \
        ///    -F 'Property.Name=Propiedad de prueba 1' \
        ///    -F 'Property.Addresses.Street=Street 25' \
        ///    -F 'Property.IdProperty=1' \
        ///    -F 'Property.Addresses.ZipCode=10010' \
        ///    -F 'Property.Addresses.State=New York' \
        ///    -F 'Property.Addresses.City=New York' \
        ///    -F 'Property.Price=350000.00' \
        ///    -F 'Property.Addresses.Country=USA' \
        ///    -F 'Property.Year=2020' \
        ///    -F 'Property.IdOwner=2'
        /// </remarks>
        /// <param name="updatePropertyCommnad">Property to create</param>
        /// <returns>Property updated</returns>
        /// <response code="200">Success</response>
        /// <response code="501">Error</response>
        [HttpPut("property", Name = "update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Property>> Update([FromForm] UpdatePropertyCommnad updatePropertyCommnad)
        {
            return await Mediator.Send(updatePropertyCommnad);
        }

        /// <summary>
        /// Change Price of Prperty
        /// </summary>
        /// <remarks>
        ///    PATCH /Property \
        ///    -F 'IdProperty=1' \
        ///    -F 'PropertyPrice=350000.00'
        /// </remarks>
        /// <param name="changePricePrpertyCommand">Id and Price Property</param>
        /// <returns>Property updated</returns>
        /// <response code="200">Success</response>
        /// <response code="501">Error</response>

        [HttpPatch("property", Name = "patch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Property>> Patch([FromForm] ChangePricePrpertyCommand changePricePrpertyCommand)
        {
            return await Mediator.Send(changePricePrpertyCommand);
        }

        /// <summary>
        /// Get Property with filters
        /// </summary>
        /// <remarks>
        ///    PUT /Property \
        ///    -F 'Property.CodeInternal=PP101' \
        ///    -F 'Property.Name=Propiedad de prueba 1' \
        ///    -F 'Property.Addresses.Street=Street 25' \
        ///    -F 'Property.IdProperty=1' \
        ///    -F 'Property.Addresses.ZipCode=10010' \
        ///    -F 'Property.Addresses.State=New York' \
        ///    -F 'Property.Addresses.City=New York' \
        ///    -F 'Property.Price=350000.00' \
        ///    -F 'Property.Addresses.Country=USA' \
        ///    -F 'Property.Year=2020' \
        ///    -F 'Property.IdOwner=2'
        /// </remarks>
        /// <param name="listWithFiltersQuery">Property filters</param>
        /// <returns>Property updated</returns>
        /// <response code="200">Success</response>
        /// <response code="501">Error</response>
        [HttpPost("property/filters", Name = "getWithFilters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<Property>>> GetWithFilters([FromForm] ListWithFiltersQuery listWithFiltersQuery)
        {
            var properties = await Mediator.Send(listWithFiltersQuery);

            return Ok(properties);
        }
    }
}

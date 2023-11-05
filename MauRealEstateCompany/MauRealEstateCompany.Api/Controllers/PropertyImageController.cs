using Application.Properties.Create;
using Application.PropertyImages.Create;
using Domain.PropertyImages;
using Microsoft.AspNetCore.Mvc;

namespace MauRealEstateCompany.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertyImageController : ApiControllerBase
    {
        private readonly ILogger<PropertyImageController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="webHostEnvironment"></param>
        public PropertyImageController(ILogger<PropertyImageController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Create new Property
        /// </summary>
        /// <remarks>
        ///    POST /Property \
        ///    -F 'IdProperty=1' \
        ///    -F 'ImageFile=contentFile'
        /// </remarks>
        /// <param name="propertyImage">Property Image to create</param>
        /// <returns>Property createed</returns>
        /// <response code="200">Success</response>
        /// <response code="501">Error</response>
        [HttpPost("propertyImage", Name = "upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PropertyImage>> Create([FromForm] PropertyImageDto propertyImage)
        {
            var path = Path.Combine(_webHostEnvironment.ContentRootPath, "PropertyFiles");

            CreatePropertyImagesCommand createPropertyImagesCommand = new CreatePropertyImagesCommand() {
                PathToSaveImage = path,
                PropertyImage = propertyImage
            };

            return await Mediator.Send(createPropertyImagesCommand);
        }
    }
}

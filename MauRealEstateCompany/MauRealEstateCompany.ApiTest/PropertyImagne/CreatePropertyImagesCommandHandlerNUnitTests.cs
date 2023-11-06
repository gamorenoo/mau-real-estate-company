using Application.Properties.Create;
using Application.PropertyImages.Create;
using Domain.PropertyImages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauRealEstateCompany.ApplicationTest.PropertyImagne
{
    [TestFixture]
    [Category("UnitTest")]
    public class CreatePropertyImagesCommandHandlerNUnitTests : BaseTest
    {
        private CreatePropertyImagesCommandHandler _createPropertyImagesCommandHandler;
        private Mock<IPropertyFileManager> _propertyFileManagerKock;


        [SetUp]
        public void Setup()
        {
            InitDataSql("Owner");
            InitDataSql("Property");
            _propertyFileManagerKock = new Mock<IPropertyFileManager>();
            string pacthImage = "C:\\Gustavo\\Repos\\github\\mau-real-estate-company\\MauRealEstateCompany\\MauRealEstateCompany.Api\\PropertyFiles\\1\\company.jpg";
            _propertyFileManagerKock.Setup(a => a.SaveImageInServer(It.IsAny<IFormFile>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns( Task.FromResult(pacthImage).Result);

            servicesCollection.AddSingleton(_propertyFileManagerKock.Object);
            serviceProvider = servicesCollection.BuildServiceProvider();

            _createPropertyImagesCommandHandler = ActivatorUtilities.CreateInstance<CreatePropertyImagesCommandHandler>(serviceProvider);

        }

        [Test]
        public async Task CreatePropertyImagesCommandHandler_Test_Seucces()
        {
            CreatePropertyImagesCommand createPropertyImagesCommand = new CreatePropertyImagesCommand() { 
                PathToSaveImage = "Path",
                PropertyImage = new PropertyImageDto()
                {
                    IdProperty = 1
                }
            };

            var result = await _createPropertyImagesCommandHandler.Handle(createPropertyImagesCommand, CancellationToken.None);
            
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task CreatePropertyImagesCommandHandler_Test_Fail()
        {
            CreatePropertyImagesCommand createPropertyImagesCommand = new CreatePropertyImagesCommand() { 
                PathToSaveImage = "Path",
                PropertyImage = new PropertyImageDto()
                {
                    IdProperty = 11
                }
            };

            try
            {
                var result = await _createPropertyImagesCommandHandler.Handle(createPropertyImagesCommand, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
                Assert.That(ex.Message, Is.EqualTo($"Entity \"Property\" ({createPropertyImagesCommand.PropertyImage.IdProperty}) was not found."));
            }
        }
    }
}

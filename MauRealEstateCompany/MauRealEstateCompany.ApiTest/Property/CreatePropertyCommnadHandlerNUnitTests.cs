using Application.Properties.ChangePrice;
using Application.Properties.Create;
using AutoFixture;
using Domain.Properties;
using Infrastructure.Repositories.PropertyRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauRealEstateCompany.ApplicationTest.Property
{
    [TestFixture]
    [Category("UnitTest")]
    public class CreatePropertyCommnadHandlerNUnitTest : BaseTest
    {
        private IFixture _fixture;
        private IPropertyQueryRepository _propertyQueryRepository;
        private CreatePropertyCommnadHandler _createPropertyCommnadHandler;

        [SetUp]
        public void Setup()
        {
            InitDataSql("Owner");
            _fixture = new Fixture();
            _propertyQueryRepository = serviceProvider.GetRequiredService<IPropertyQueryRepository>();
            _createPropertyCommnadHandler = ActivatorUtilities.CreateInstance<CreatePropertyCommnadHandler>(serviceProvider);
        }

        [Test]
        public async Task CreatePropertyCommnadHandler_Test_Success()
        {
            var properties =  await _propertyQueryRepository.GetAllPropertiesAsync();
            var propertiesCurrentCount = properties.Count();

            CreatePropertyCommnad createPropertyCommnad = getDataCreatePropertyCommnad();
            createPropertyCommnad.Property.IdOwner = 1;

            var property = await _createPropertyCommnadHandler.Handle(createPropertyCommnad, CancellationToken.None);
            Assert.IsNotNull(property);

            properties = await _propertyQueryRepository.GetAllPropertiesAsync();
            var propertiesAfterCount = properties.Count();

            Assert.IsTrue(propertiesAfterCount > propertiesCurrentCount);
        }

        [Test]
        public async Task CreatePropertyCommnadHandler_Test_Fail()
        {
            CreatePropertyCommnad createPropertyCommnad = getDataCreatePropertyCommnad();
            createPropertyCommnad.Property.IdOwner = 10;
            try
            {
                var property = await _createPropertyCommnadHandler.Handle(createPropertyCommnad, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
                Assert.That(ex.Message, Is.EqualTo("Entity \"Owner\" (10) was not found."));
            }
            
        }

        private CreatePropertyCommnad getDataCreatePropertyCommnad()
        { 
            return new CreatePropertyCommnad()
            {
                Property = _fixture.Create<PropertyDto>()
            };
        }
    }
}

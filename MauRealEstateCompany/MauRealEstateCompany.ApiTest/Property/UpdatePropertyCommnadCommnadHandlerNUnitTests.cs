using Application.Properties.Create;
using Application.Properties.Update;
using AutoFixture;
using Domain.Properties;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Properties.Update.UpdatePropertyCommnad;

namespace MauRealEstateCompany.ApplicationTest.Property
{
    [TestFixture]
    [Category("UnitTest")]
    public class UpdatePropertyCommnadCommnadHandlerNUnitTests : BaseTest
    {
        private IFixture _fixture;
        private IPropertyQueryRepository _propertyQueryRepository;
        private UpdatePropertyCommnadCommnadHandler _updatePropertyCommnadCommnadHandler;
        
        
        [SetUp]
        public void Setup()
        {
            InitDataSql("Owner");
            InitDataSql("Property");
            _fixture = new Fixture();
            _propertyQueryRepository = serviceProvider.GetRequiredService<IPropertyQueryRepository>();
            _updatePropertyCommnadCommnadHandler = ActivatorUtilities.CreateInstance<UpdatePropertyCommnadCommnadHandler>(serviceProvider);
        }

        [Test]
        public async Task UpdatePropertyCommnadCommnadHandler_Test_Seccess()
        {

            var properties = await _propertyQueryRepository.GetByIdAsync(1);
            var propertiesCurrentName = properties?.Name;

            UpdatePropertyCommnad updatePropertyCommnad = getDataUpdatePropertyCommnad();

            updatePropertyCommnad.Property.IdProperty = 1;
            updatePropertyCommnad.Property.IdOwner = 1;

            var result = await _updatePropertyCommnadCommnadHandler.Handle(updatePropertyCommnad, CancellationToken.None);

            Assert.IsNotNull(result);

            Assert.That(propertiesCurrentName, Is.Not.EqualTo(result.Name));
        }

        [Test]
        public async Task UpdatePropertyCommnadCommnadHandler_Test_Fail_ByIdProperty()
        {
            UpdatePropertyCommnad updatePropertyCommnad = getDataUpdatePropertyCommnad();

            updatePropertyCommnad.Property.IdProperty = 10;
            updatePropertyCommnad.Property.IdOwner = 1;

            try
            {
                var result = await _updatePropertyCommnadCommnadHandler.Handle(updatePropertyCommnad, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
                Assert.That(ex.Message, Is.EqualTo("Entity \"Property\" (10) was not found."));
            }
        }

        [Test]
        public async Task UpdatePropertyCommnadCommnadHandler_Test_Fail_ByIdOwner()
        {
            UpdatePropertyCommnad updatePropertyCommnad = getDataUpdatePropertyCommnad();

            updatePropertyCommnad.Property.IdProperty = 1;
            updatePropertyCommnad.Property.IdOwner = 10;

            try
            {
                var result = await _updatePropertyCommnadCommnadHandler.Handle(updatePropertyCommnad, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
                Assert.That(ex.Message, Is.EqualTo("Entity \"Owner\" (10) was not found."));
            }
        }

        private UpdatePropertyCommnad getDataUpdatePropertyCommnad()
        {
            return new UpdatePropertyCommnad()
            {
                Property = _fixture.Create<PropertyUpdateDto>()
            };
        }
    }
}

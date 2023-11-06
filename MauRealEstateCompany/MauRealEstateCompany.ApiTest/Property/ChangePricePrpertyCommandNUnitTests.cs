using Application.Auth.Login;
using Application.Properties.ChangePrice;
using Domain.Properties;
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
    public class ChangePricePrpertyCommandNUnitTests : BaseTest
    {
        private IPropertyQueryRepository _propertyQueryRepository;
        private IPropertyCommandRepository _propertyCommandRepository;
        private ChangePricePrpertyCommandHandler _changePricePrpertyCommandHandler;

        [SetUp]
        public void Setup()
        {
            InitDataSql("Owner");
            InitDataSql("Property");
            _propertyQueryRepository = serviceProvider.GetRequiredService<IPropertyQueryRepository>();
            _propertyCommandRepository = serviceProvider.GetRequiredService<IPropertyCommandRepository>();

            _changePricePrpertyCommandHandler = ActivatorUtilities.CreateInstance<ChangePricePrpertyCommandHandler>(serviceProvider);
        }

        [Test]
        public async Task ChangePricePrpertyCommand_Test_Success()
        {
            var currentProperty = await _propertyQueryRepository.GetByIdAsync(1);
            var currentPropertyPrice = currentProperty?.Price;

            ChangePricePrpertyCommand changePricePrpertyCommand = new ChangePricePrpertyCommand() { 
                PropertyPrice = new PropertyPriceDto() { 
                    IdProperty = 1,
                    NewPrice = 105000
                }
            };

            var resultProperty = await _changePricePrpertyCommandHandler.Handle(changePricePrpertyCommand, CancellationToken.None);

            Assert.IsNotNull(resultProperty);
            
            Assert.That(resultProperty?.Price, Is.Not.EqualTo(currentPropertyPrice));
        }

        [Test]
        public async Task ChangePricePrpertyCommand_Test_Fail()
        {
            ChangePricePrpertyCommand changePricePrpertyCommand = new ChangePricePrpertyCommand() { 
                PropertyPrice = new PropertyPriceDto() { 
                    IdProperty = 10,
                    NewPrice = 105000
                }
            };

            try
            {
                var resultProperty = await _changePricePrpertyCommandHandler.Handle(changePricePrpertyCommand, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
                Assert.That(ex.Message, Is.EqualTo("Entity \"Property\" (10) was not found."));
            }
        }
    }
}

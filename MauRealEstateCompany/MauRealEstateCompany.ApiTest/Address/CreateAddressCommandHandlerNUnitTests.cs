using Application.Addresses.Create;
using Application.Properties.Create;
using Application.Properties.Update;
using AutoFixture;
using Domain.Addresses;
using Domain.Properties;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauRealEstateCompany.ApplicationTest.Address
{
    [TestFixture]
    [Category("UnitTest")]
    public class CreateAddressCommandHandlerNUnitTests : BaseTest
    {
        private IFixture _fixture;
        private CreateAddressCommandHandler _createAddressCommandHandler;
        private IAddressQueryRepository _addressQueryRepository;

        [SetUp]
        public void Setup()
        {
            InitDataSql("Owner");
            InitDataSql("Property");
            _fixture = new Fixture();
            _addressQueryRepository = serviceProvider.GetRequiredService<IAddressQueryRepository>();
            _createAddressCommandHandler = ActivatorUtilities.CreateInstance<CreateAddressCommandHandler>(serviceProvider);
        }

        [Test]
        public async Task CreateAddressCommandHandler_Test_AddressForProperty_Success()
        {
            var addresses = await _addressQueryRepository.GetAll();
            var addressCurrentCount = addresses.Count();

            CreateAddressCommand createAddressCommand = getDataCreateAddressCommand();
            createAddressCommand.IdProperty = 1;

            var addres = await _createAddressCommandHandler.Handle(createAddressCommand, CancellationToken.None);

            Assert.IsNotNull(addres);

            addresses = await _addressQueryRepository.GetAll();
            var addressAfterCount = addresses.Count();

            Assert.IsTrue(addressAfterCount > addressCurrentCount);

        }

        [Test]
        public async Task CreateAddressCommandHandler_Test_AddressForOwner_Success()
        {
            var addresses = await _addressQueryRepository.GetAll();
            var addressCurrentCount = addresses.Count();

            CreateAddressCommand createAddressCommand = getDataCreateAddressCommand();
            createAddressCommand.IdOwner = 1;

            var addres = await _createAddressCommandHandler.Handle(createAddressCommand, CancellationToken.None);

            Assert.IsNotNull(addres);

            addresses = await _addressQueryRepository.GetAll();
            var addressAfterCount = addresses.Count();

            Assert.IsTrue(addressAfterCount > addressCurrentCount);

        }

        [Test]
        public async Task CreateAddressCommandHandler_Test_AddressForOwner_Fail()
        {
            CreateAddressCommand createAddressCommand = getDataCreateAddressCommand();
            createAddressCommand.IdOwner = 11;

            try
            {
                var addres = await _createAddressCommandHandler.Handle(createAddressCommand, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
                Assert.That(ex.Message, Is.EqualTo($"Entity \"Owner\" ({ createAddressCommand.IdOwner }) was not found."));
            }
        }

        [Test]
        public async Task CreateAddressCommandHandler_Test_AddressForProperty_Fail()
        {
            CreateAddressCommand createAddressCommand = getDataCreateAddressCommand();
            createAddressCommand.IdProperty = 11;

            try
            {
                var addres = await _createAddressCommandHandler.Handle(createAddressCommand, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
                Assert.That(ex.Message, Is.EqualTo($"Entity \"Property\" ({ createAddressCommand.IdProperty}) was not found."));
            }
        }


        private CreateAddressCommand getDataCreateAddressCommand()
        {
            return new CreateAddressCommand()
            {
                Address = _fixture.Create<AddressDto>()
            };
        }
    }
}

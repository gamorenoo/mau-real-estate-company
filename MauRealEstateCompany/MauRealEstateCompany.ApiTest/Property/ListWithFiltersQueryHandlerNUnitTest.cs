using Application.Properties.ListWithFilters;
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
    public class ListWithFiltersQueryHandlerNUnitTest : BaseTest
    {
        private ListWithFiltersQueryHandler _listWithFiltersQueryHandler;

        [SetUp]
        public void Setup()
        {
            InitDataSql("Owner");
            InitDataSql("Property");
            InitDataSql("Address");
            _listWithFiltersQueryHandler = ActivatorUtilities.CreateInstance<ListWithFiltersQueryHandler>(serviceProvider);
        }

        [Test]
        public async Task ListWithFiltersQueryHandler_Test_ByIdProerty_Succes()
        {
            ListWithFiltersQuery listWithFiltersQuery = new ListWithFiltersQuery() {
                PropertyFilters = new PropertyFiltersDto() {
                    IdProperty = 1
                }
            };

            var properties = await _listWithFiltersQueryHandler.Handle(listWithFiltersQuery, CancellationToken.None);

            Assert.IsTrue(properties.Any());
        }

        [Test]
        public async Task ListWithFiltersQueryHandler_Test_ByNameProperty_Succes()
        {
            ListWithFiltersQuery listWithFiltersQuery = new ListWithFiltersQuery() {
                PropertyFilters = new PropertyFiltersDto() {
                    NameProperty = "Property Test 1"
                }
            };

            var properties = await _listWithFiltersQueryHandler.Handle(listWithFiltersQuery, CancellationToken.None);

            Assert.IsTrue(properties.Any());
        } 

        [Test]
        public async Task ListWithFiltersQueryHandler_Test_ByYearProperty_Succes()
        {
            ListWithFiltersQuery listWithFiltersQuery = new ListWithFiltersQuery() {
                PropertyFilters = new PropertyFiltersDto() {
                    Year = 2020
                }
            };

            var properties = await _listWithFiltersQueryHandler.Handle(listWithFiltersQuery, CancellationToken.None);

            Assert.IsTrue(properties.Any());
        } 

        [Test]
        public async Task ListWithFiltersQueryHandler_Test_ByCodeInternalProperty_Succes()
        {
            ListWithFiltersQuery listWithFiltersQuery = new ListWithFiltersQuery() {
                PropertyFilters = new PropertyFiltersDto() {
                    CodeInternal = "PT101"
                }
            };

            var properties = await _listWithFiltersQueryHandler.Handle(listWithFiltersQuery, CancellationToken.None);

            Assert.IsTrue(properties.Any());
        }

        [Test]
        public async Task ListWithFiltersQueryHandler_Test_ByNameOwner_Succes()
        {
            ListWithFiltersQuery listWithFiltersQuery = new ListWithFiltersQuery()
            {
                PropertyFilters = new PropertyFiltersDto()
                {
                    NameOwner = "Owner 1 Test"
                }
            };

            var properties = await _listWithFiltersQueryHandler.Handle(listWithFiltersQuery, CancellationToken.None);

            Assert.IsTrue(properties.Any());
        }

        [Test]
        public async Task ListWithFiltersQueryHandler_Test_ByZipCode_Succes()
        {
            ListWithFiltersQuery listWithFiltersQuery = new ListWithFiltersQuery()
            {
                PropertyFilters = new PropertyFiltersDto()
                {
                    ZipCode = "10001"
                }
            };

            var properties = await _listWithFiltersQueryHandler.Handle(listWithFiltersQuery, CancellationToken.None);

            Assert.IsTrue(properties.Any());
        }

        [Test]
        public async Task ListWithFiltersQueryHandler_Test_ByCity_Succes()
        {
            ListWithFiltersQuery listWithFiltersQuery = new ListWithFiltersQuery()
            {
                PropertyFilters = new PropertyFiltersDto()
                {
                    City = "New York"
                }
            };

            var properties = await _listWithFiltersQueryHandler.Handle(listWithFiltersQuery, CancellationToken.None);

            Assert.IsTrue(properties.Any());
        }

        [Test]
        public async Task ListWithFiltersQueryHandler_Test_ByCountry_Succes()
        {
            ListWithFiltersQuery listWithFiltersQuery = new ListWithFiltersQuery()
            {
                PropertyFilters = new PropertyFiltersDto()
                {
                    Country = "USA"
                }
            };

            var properties = await _listWithFiltersQueryHandler.Handle(listWithFiltersQuery, CancellationToken.None);

            Assert.IsTrue(properties.Any());
        }


        [Test]
        public async Task ListWithFiltersQueryHandler_Test_ByManyFilter_Succes()
        {
            ListWithFiltersQuery listWithFiltersQuery = new ListWithFiltersQuery()
            {
                PropertyFilters = new PropertyFiltersDto()
                {
                    Year = 2020,
                    NameOwner = "Owner 1 Test"
                }
            };

            var properties = await _listWithFiltersQueryHandler.Handle(listWithFiltersQuery, CancellationToken.None);

            Assert.IsTrue(properties.Any());
        }
    }
}

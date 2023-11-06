using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Auth.Login;
using Application.Common.Interfaces;
using Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MauRealEstateCompany.ApplicationTest.Auth
{
    [TestFixture]
    [Category("UnitTest")]
    public class LoginQueryHandlerNUnitTests : BaseTest
    {
        private IAuthService _authService;
        private IApplicationDbContext _applicationDbContext;
        private LoginQueryHandler _loginQueryHandler;


        [SetUp]
        public void SetUp()
        {
            _authService = serviceProvider.GetRequiredService<IAuthService>();
            _applicationDbContext = serviceProvider.GetRequiredService<IApplicationDbContext>();
            _loginQueryHandler = new LoginQueryHandler(_applicationDbContext, _authService);

        }

        [Test]
        public async Task LoginQuery_Test_Success()
        {
            LoginQuery loginQuery = new LoginQuery() { 
                User = new UserDto()
                {
                    Email = "gustavoamoreno@outlook.com",
                    Password = "0123456789",
                }
            };
            var resul = await _loginQueryHandler.Handle(loginQuery, CancellationToken.None);
            Assert.IsNotNull(resul);
        }

        [Test]
        public async Task LoginQuery_Test_Fail()
        {
            LoginQuery loginQuery = new LoginQuery() { 
                User = new UserDto()
                {
                    Email = "gustavoamoreno@outlook.com",
                    Password = "9876543210",
                }
            };
            try
            {
                var resul = await _loginQueryHandler.Handle(loginQuery, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("User or Password Invalid"));
            }
        }
    }
}

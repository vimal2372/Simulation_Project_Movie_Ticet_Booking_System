using Authorization;
using Authorization.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTicketBookingTest
{
    [TestFixture]
    public class AuthTest
    {
        private Mock<IConfiguration> config;
        private Mock<IAuthRepo> auth;
        private AccountController token;

        [SetUp]
        public void Setup()
        {
            config = new Mock<IConfiguration>();
            auth = new Mock<IAuthRepo>();
            token = new AccountController(config.Object,auth.Object);
        }
            [Test]
        public void login_when_called_returns_ok()
        {
            auth.Setup(p => p.GenerateJSONWebToken()).Returns("Token");
           
            var result = token.Login(new Authenticate {});

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void login_when_called_returns_unauthorize()
        {
            auth.Setup(p => p.GenerateJSONWebToken()).Returns("Token");

            var result = token.Login(null);

            Assert.That(result, Is.InstanceOf<UnauthorizedResult>());
        }
    }
}

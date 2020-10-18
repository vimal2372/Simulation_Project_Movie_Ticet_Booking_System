using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UserApi.Controllers;
using UserApi.Model;
using UserApi.Repository;

namespace NUnitTest
{
    [TestFixture]
   public class UserApiTest
    {
        private Mock<IUserRepository> config;
        private UserController TokenObj;
        [SetUp]
        public void Setup()
        {
            config = new Mock<IUserRepository>();
            TokenObj = new UserController(config.Object);
        }
        [Test]
        public void Usertests()
        {
            config.Setup(p => p.GetUsers()).Returns(new List<User> {
                new User()
            {
                Id = 1,
                UserName = "dfd",
                Email="dff",
                Password="ddfj",
                PhoneNumber="454"

            }});
            var result = TokenObj.Get();

            Assert.That(result, Is.TypeOf<OkResult>());
            // Assert.That(result, Is.TypeOf<List<User>>());

        }

        [Test]
        public void Usertestspost()
        {
         
            config.Setup(p => p.InsertUser(It.IsAny<User>())).Verifiable();

            var result = TokenObj.Post(new User { });

            Assert.That(result, Is.TypeOf<OkResult>());
            // Assert.That(result, Is.TypeOf<List<User>>());

        }

    }
}

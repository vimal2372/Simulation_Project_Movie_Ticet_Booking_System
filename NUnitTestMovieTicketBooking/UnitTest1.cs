using Authorization.Controllers;
using BookingtApi.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;
using MovieDetails.Controllers;
using NUnit.Framework;
using System.Web.Http.Results;
using UserApi.Controllers;

namespace NUnitTestMovieTicketBooking
{
    [TestFixture]
    public class Bookingt
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void IsTokenNull_When_InvalidUserCredentialsAreUsed()
        {
            //Arrange
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            //Act
            var TokenObj = new AccountController(config.Object);

            var response = TokenObj.Login(new Authorization.Authenticate() { Id=1,UserName = "wronginput", Password = "wronginput" });
            var result = response as UnauthorizedResult;
            //Assert
            Assert.IsNull(result);

        }


/*
      [Test]
        public void IsTokenNotNull_When_InvalidUserCredentialsAreUsed()
        {
            //Arrange
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            //Act
            var TokenObj = new MovieController(config.Object);


           // var response = TokenObj.Login(new Authorization.Authenticate() { Id = 1, UserName = "wronginput", Password = "wronginput" });
           // var result = response as UnauthorizedResult;
            //Assert
            Assert.IsNull(result);

        }*/

    }
}

using AdminApi.Controllers;
using AdminApi.Model;
using AdminApi.Repository;

using BookingtApi.Controllers;
using BookingtApi.Model;
using BookingtApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using MovieDetails.Controllers;
using MovieDetails.Model;
using MovieDetails.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using UserApi.Controllers;
using UserApi.Model;
using UserApi.Repository;

namespace MovieTicketBookingTest
{
    [TestFixture]
    public class Tests
    {
       
        private Mock<IUserRepository> config;
        private UserController TokenObj;

       private Mock<IBookingtRepository> config1;
        private BookingtController TokenObj1;

        private Mock<IAdminRepository> config2;
        private AdminController TokenObj2;

        private Mock<IMovieRepository> config3;
        private MovieController TokenObj3;

       
     //   private Mock<IConfiguration> _config;
       // private Mock<IAuthRepo> config4;
        //private AccountController TokenObj4;

        [SetUp]
        public void Setup()
        {
          
        config = new Mock<IUserRepository>();
            config1 = new Mock<IBookingtRepository>();
            config3 = new Mock<IMovieRepository>();
            config2 = new Mock<IAdminRepository>();
            TokenObj = new UserController(config.Object);
            TokenObj1 = new BookingtController(config1.Object);
            TokenObj2 = new AdminController(config2.Object);
            TokenObj3 = new MovieController(config3.Object);

          //  config4 = new Mock<IAuthRepo>();

          //  TokenObj4 = new AccountController(_config.Object,config4.Object);
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

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            // Assert.That(result, Is.TypeOf<List<User>>());

        }

        [Test]
        public void BookingtTestpost()
        {

            config1.Setup(p => p.InsertBookingt(It.IsAny<Bookingt>())).Verifiable();

            var result = TokenObj1.Post(new Bookingt { });

            Assert.That(result, Is.TypeOf<OkResult>());
            // Assert.That(result, Is.TypeOf<List<User>>());

        }


        [Test]
        public void BookingtTests()
        {
            config1.Setup(p => p.GetBookingts()).Returns(new List<Bookingt> {
                new Bookingt()
            {
                Id = 1,
                seatno = "dfd",
                MovieName="dfdf",
                MovieDetailsId=1,
                Datetopresent="dfdf",
                UserName="dfdf"

            }});
            var result = TokenObj1.Get();

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
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


        [Test]
        public void AdminTests()
        {
            config2.Setup(p => p.GetAdmins()).Returns(new List<Admin> {
                new Admin()
            {
                Id=1,
                UserName="dfdf",
                Password="dkfjdk"

            }});
            var result = TokenObj2.Get();

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            // Assert.That(result, Is.TypeOf<List<User>>());

        }

        [Test]
        public void MovieTests()
        {
            config3.Setup(p => p.GetMovies()).Returns(new List<Movie> {
                new Movie()
            {
                Id=1,
                Movie_Name="",
                Movie_Description="DFD",
                DateAndTime="DF",
                MoviePicture="DD"

            }});
            var result = TokenObj3.Get();

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            // Assert.That(result, Is.TypeOf<List<User>>());

        }

        [Test]
        public void Movietestspost()
        {

            config3.Setup(p => p.InsertMoive(It.IsAny<Movie>())).Verifiable();

            var result = TokenObj3.Post(new Movie { });

            Assert.That(result, Is.TypeOf<OkResult>());
            // Assert.That(result, Is.TypeOf<List<User>>());

        }

        /*
       
        */




    }
}
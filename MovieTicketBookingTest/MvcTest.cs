using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieTicketBooking;
using MovieTicketBooking.Controllers;
using MovieTicketBooking.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTicketBookingTest
{ 
    [TestFixture]
    class MvcTest
    {
        private Mock<ILogger> config;
        private HomeController _controller;
        [SetUp]
        public void Setup()
        {
            config = new Mock<ILogger>();
            _controller = new HomeController();
        }

        [Test]
        public void Index_WhenCalled_Returns_view()
        {
            var result = _controller.demo() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("demo"));
        }

        [Test]
        public void Index_WhenCalled_Returns_demo_string()
        {
            var result = _controller.demo(new UserData { }) as ContentResult;

            Assert.AreEqual("demo1", result.Content);
            //Assert.That(result.ViewName, Is.EqualTo("vimal"));
        }
    }
}

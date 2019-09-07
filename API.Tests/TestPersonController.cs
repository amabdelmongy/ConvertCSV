using System;
using System.IO;
using System.Linq;
using API.Controllers;
using Core.Models;
using Core.Service;
using DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Api.Tests
{
    [TestClass]
    public class TestPersonController
    { 
        private PersonsController PersonsController
        {
            get
            {
                var unitTestPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                var hostingEnvironmentMock = new Moq.Mock<IHostingEnvironment>();
                hostingEnvironmentMock.Setup(foo => foo.ContentRootPath).Returns(unitTestPath);

                var service = new Service(new Parser(new FileManager(), new DataConverter(), new Mapper()));

                var controller = new PersonsController(service, hostingEnvironmentMock.Object);
                return controller;
            }
        }

        [TestMethod]
        public void GivenCSVfile_WhenCsvContains10rows_ThenItShouldReturn10Persons()
        {
            var controller = PersonsController;

            var result = controller.Get();
            Assert.AreEqual(10, result.Count);

            var firstPerson = result[0];
            Assert.AreEqual(1, firstPerson.ID);
            Assert.AreEqual("Müller", firstPerson.Name);
            Assert.AreEqual("Hans", firstPerson.Lastname);
            Assert.AreEqual("Lauterecken", firstPerson.City);
            Assert.AreEqual("67742", firstPerson.Zipcode);
            Assert.AreEqual(Color.blue, firstPerson.Color);

            var lastPerson = result.Last();
            Assert.AreEqual(10, lastPerson.ID);
            Assert.AreEqual("Klaussen", lastPerson.Name);
            Assert.AreEqual("Klaus", lastPerson.Lastname);
            Assert.AreEqual("Hierach", lastPerson.City);
            Assert.AreEqual("43246", lastPerson.Zipcode);
            Assert.AreEqual(Color.green, lastPerson.Color);
        }

        [TestMethod]
        public void GivenCSVfile_WhenGetById1_ThenItShouldReturnCorrectPerson()
        {
            var controller = PersonsController;

            var person = controller.Get(1);  
            Assert.AreEqual(1, person.ID);
            Assert.AreEqual("Müller", person.Name);
            Assert.AreEqual("Hans", person.Lastname);
            Assert.AreEqual("Lauterecken", person.City);
            Assert.AreEqual("67742", person.Zipcode);
            Assert.AreEqual(Color.blue, person.Color); 
        }

        [TestMethod]
        public void GivenCSVfile_WhenGetById9_ThenItShouldReturnCorrectPerson()
        {
            var controller = PersonsController; 

            var person = controller.Get(10);
            Assert.AreEqual(10, person.ID);
            Assert.AreEqual("Klaussen", person.Name);
            Assert.AreEqual("Klaus", person.Lastname);
            Assert.AreEqual("Hierach", person.City);
            Assert.AreEqual("43246", person.Zipcode);
            Assert.AreEqual(Color.green, person.Color);
        }

        [TestMethod]
        public void GivenCSVfile_WhenGetByIdColor_ThenItShouldReturnCorrectPersons()
        {
            var controller = PersonsController;

            var result = controller.Color(Color.blue);
            Assert.AreEqual(2, result.Count);

            var firstPerson = result[0];
            Assert.AreEqual(1, firstPerson.ID);
            Assert.AreEqual("Müller", firstPerson.Name);
            Assert.AreEqual("Hans", firstPerson.Lastname);
            Assert.AreEqual("Lauterecken", firstPerson.City);
            Assert.AreEqual("67742", firstPerson.Zipcode);
            Assert.AreEqual(Color.blue, firstPerson.Color);
             
            var lastPerson = result.Last();
            Assert.AreEqual(8, lastPerson.ID);
            Assert.AreEqual("Bart", lastPerson.Name);
            Assert.AreEqual("Bertram", lastPerson.Lastname);
            Assert.AreEqual("Wasweißich", lastPerson.City);
            Assert.AreEqual("12313", lastPerson.Zipcode);
            Assert.AreEqual(Color.blue, lastPerson.Color);
        }
    }
}
 
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Core.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void GivenCSVfile_WhenCsvContains1rows_ThenItShouldReturn1Persons()
        {
            var Lines = new List<string>();
            Lines.Add("Müller, Hans, 67742 Lauterecken, 1");

            var fileManagerMock = new Moq.Mock<IFileManager>();
            fileManagerMock.Setup(foo => foo.ReadFile(It.IsAny<string>())).Returns(Lines);

            var parser = new Core.Service.Parser(fileManagerMock.Object,new DataConverter(), new Mapper());
            var result = parser.ParseCSV("");

            Assert.AreEqual(1, result.Count); 
            var firstPerson = result[0];
            Assert.AreEqual(1, firstPerson.ID);
            Assert.AreEqual("Müller", firstPerson.Name);
            Assert.AreEqual("Hans", firstPerson.Lastname);
            Assert.AreEqual("Lauterecken", firstPerson.City);
            Assert.AreEqual("67742", firstPerson.Zipcode);
            Assert.AreEqual(Color.blue, firstPerson.Color);
        }

        [TestMethod]
        public void GivenCSVfile_WhenCsvContains2rows_ThenItShouldReturn2Persons()
        {
            var Lines = new List<string>();
            Lines.Add("Müller, Hans, 67742 Lauterecken, 1");
            Lines.Add("Klaussen, Klaus, 43246 Hierach, 2 ");

            var fileManagerMock = new Moq.Mock<IFileManager>();
            fileManagerMock.Setup(foo => foo.ReadFile(It.IsAny<string>())).Returns(Lines);

            var parser = new Core.Service.Parser(fileManagerMock.Object, new DataConverter(), new Mapper());
            var result = parser.ParseCSV("");

            Assert.AreEqual(2, result.Count);

            var firstPerson = result[0];
            Assert.AreEqual(1, firstPerson.ID);
            Assert.AreEqual("Müller", firstPerson.Name);
            Assert.AreEqual("Hans", firstPerson.Lastname);
            Assert.AreEqual("Lauterecken", firstPerson.City);
            Assert.AreEqual("67742", firstPerson.Zipcode);
            Assert.AreEqual(Color.blue, firstPerson.Color);

            var lastPerson = result.Last();
            Assert.AreEqual(2, lastPerson.ID);
            Assert.AreEqual("Klaussen", lastPerson.Name);
            Assert.AreEqual("Klaus", lastPerson.Lastname);
            Assert.AreEqual("Hierach", lastPerson.City);
            Assert.AreEqual("43246", lastPerson.Zipcode);
            Assert.AreEqual(Color.green, lastPerson.Color);
        }

        [TestMethod]
        public void GivenCSVfile_WhenCsvContainsTwoRowsandThreeObjects_ThenItShouldReturnThreePersons()
        {
            var Lines = new List<string>();
            Lines.Add("Millenium, Milly, 77777 made up too, 4 Fujitsu, Tastatur, 42342 Japan,");
            Lines.Add("6 Andersson, Anders, 32132 Schweden - Bonus, 2");

            var fileManagerMock = new Moq.Mock<IFileManager>();
            fileManagerMock.Setup(foo => foo.ReadFile(It.IsAny<string>())).Returns(Lines);

            var parser = new Core.Service.Parser(fileManagerMock.Object, new DataConverter(), new Mapper());
            var result = parser.ParseCSV("");

            Assert.AreEqual(3, result.Count);

            var firstPerson = result[0];
            Assert.AreEqual(1, firstPerson.ID);
            Assert.AreEqual("Millenium", firstPerson.Name);
            Assert.AreEqual("Milly", firstPerson.Lastname);
            Assert.AreEqual("made up too", firstPerson.City);
            Assert.AreEqual("77777", firstPerson.Zipcode);
            Assert.AreEqual(Color.red, firstPerson.Color);

            var person2 = result[1];
            Assert.AreEqual(2, person2.ID);
            Assert.AreEqual("Fujitsu", person2.Name);
            Assert.AreEqual("Tastatur", person2.Lastname);
            Assert.AreEqual("Japan", person2.City);
            Assert.AreEqual("42342", person2.Zipcode);
            Assert.AreEqual(Color.turquois, person2.Color); 

            var lastPerson = result.Last();
            Assert.AreEqual(3, lastPerson.ID);
            Assert.AreEqual("Andersson", lastPerson.Name);
            Assert.AreEqual("Anders", lastPerson.Lastname);
            Assert.AreEqual("Schweden - Bonus", lastPerson.City);
            Assert.AreEqual("32132", lastPerson.Zipcode);
            Assert.AreEqual(Color.green, lastPerson.Color);
        }
    }
}

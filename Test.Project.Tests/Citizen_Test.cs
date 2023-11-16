using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Project.Library;


namespace Test.Project.Tests
{
    [TestClass]
    public class Citizen_Test
    {
        /*Data*/
        Citizen Rizki = new Citizen()
        {
            Name = "Rizki",
            LastName = "Ramadan",
            Document_Number = "00100101010",
            BirthDate = new DateTime(1666, 06, 06),
            Sex = 'M'
        };


        [TestMethod]
        public void Citizen_Creation()
        {

            Assert.IsTrue(Rizki.Id == Guid.Empty);
            Assert.IsTrue(Rizki.Save());
            Assert.AreEqual(Rizki.Name, "Rizki");
            Assert.AreEqual(Rizki.LastName, "Ramadan");
            Assert.AreEqual(Rizki.Sex, (char)Citizen.SexType.Male);
            Assert.AreEqual(Rizki.BirthDate, new DateTime(1666, 06, 06));
            Assert.AreEqual(Rizki.Document_Number, "00100101010");
            Assert.IsTrue(Rizki.Id != Guid.Empty);
        }

        [TestMethod]
        public void Citizen_Age()
        {
            Assert.IsTrue(Rizki.Age() >= 23);
        }

        [TestMethod]
        public void Citizen_Adult()
        {
            Assert.IsTrue(Rizki.IsAdult());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Citizen_Should_Throw_Invalid_Sex()
        {
            Rizki.Sex = 'Y';
        }

        [TestMethod, ExpectedException(typeof(Exception), "Invalid blank document number")]
        public void Citizen_Should_Throw_Invalid_Document_Number()
        {
            Rizki.Document_Number = "This is my document Number";
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Citizen_Should_Throw_Incomplete_Document_Number()
        {
            Rizki.Document_Number = "1234567891";
        }

    }
}

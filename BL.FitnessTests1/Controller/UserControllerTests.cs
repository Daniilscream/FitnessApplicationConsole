using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL.Fitness.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Fitness.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var gender = "man";
            var birthdate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            //Act
            var controller = new UserController(userName);
            controller.SetNewUserData(gender, birthdate, weight, height);
            var controller2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthdate, controller2.CurrentUser.Birthday);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            //Act
            var controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}
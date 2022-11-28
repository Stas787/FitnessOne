using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessOne.BusinessLogic.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessOne.BusinessLogic.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();//рандомное имя
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 100;
            var height = 210;
            var gender = "man";
            var controller = new UserController(userName);
            //Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();            
            //Act
            var controller = new UserController(userName);
            //Assert проверяем то, что получилось и то, что ожидалось Assert - содержит в себе набор проверок
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}
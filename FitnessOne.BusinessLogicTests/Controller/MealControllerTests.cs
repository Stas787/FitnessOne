using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessOne.BusinessLogic.Model;
using FitnessOne.BusinessLogic.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessOne.BusinessLogic.Controller.Tests
{
    [TestClass()]
    public class MealControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rndm = new Random();
            var userController = new UserController(userName);
            var mealController = new MealController(userController.CurrentUser);
            var food = new Food(foodName, rndm.Next(50, 500), rndm.Next(50, 500), rndm.Next(50, 500), rndm.Next(50, 500));

            //Act
            mealController.Add(food, 100);

            //Assert
            Assert.AreEqual(food.Name, mealController.Meal.Foods.Keys.First().Name);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessOne.BusinessLogic.Model;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessOne.BusinessLogic.Controller
{
    public class MealController: ControllerBase
    {
        private const string FoodsFileName = "foods.dat";
        private const string MealsFileName = "meals.dat";

        private readonly User user;
        public List<Food> Foods { get; }
        public Meal Meal { get; }
        public MealController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user), "User can't be blank");
            Foods = GetAllFoods();
            Meal = GetMeal();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Meal.Add(food, weight);
                Save();
            }
            else
            {
                Meal.Add(product, weight);
                Save();
            }
        }

        private Meal GetMeal()
        {
            return Load<Meal>(MealsFileName) ?? new Meal(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FoodsFileName) ?? new List<Food>();            
        }

        private void Save()
        {
            Save(FoodsFileName, Foods);
            Save(MealsFileName, Meal);
        }
    }
}

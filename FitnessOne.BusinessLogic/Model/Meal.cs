using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessOne.BusinessLogic.Model
{
    [Serializable]
    public class Meal
    {
        /// <summary>
        /// Food eating
        /// </summary>
        public DateTime Moment { get; }

        public Dictionary<Food, double> Foods { get; }

        public User User { get; }

        public Meal(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user), "User can't be blank");
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weght)
        {            
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weght);
            }
            else
            {
                Foods[product] += weght;
            }
        }
    }
}

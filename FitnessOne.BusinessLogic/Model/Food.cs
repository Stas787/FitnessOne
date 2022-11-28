using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessOne.BusinessLogic.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get;}

        /// <summary>
        /// Protein number
        /// </summary>
        public double Protein { get; }

        /// <summary>
        /// Fats number
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Carbohydrates number
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Calories number in 100gm
        /// </summary>
        public double Calories { get; }

        public Food(string name) : this(name, 0, 0, 0, 0) {}

        public Food(string name, double protein, double fats, double carbohydrates, double calories)
        {
            //TODO: make check
            Name = name;
            Protein = protein / 100;
            Fats = fats / 100;
            Carbohydrates = carbohydrates / 100;
            Calories = calories / 100;
        }

        public override string ToString()
        {
            return Name;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessOne//.BusinessLogic.Model
{
    /// <summary>
    /// User.
    /// </summary>  

    [Serializable]
    public class User
    {
        #region Properties
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get;} //делаем для того, чтобы установить имя пользователя один раз при создании экземпляра класса
        
        /// <summary>
        /// Gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Weight.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Height.
        /// </summary>
        public double Height { get; set; }

        public int Age 
        { get 
            { //return DateTime.Now.Year - BirthDate.Year;
                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - BirthDate.Year;
                if (BirthDate > nowDate.AddYears(-age)) { age--; }
                return age;
            }
        }
        #endregion

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="birthDate">Birth date.</param>
        /// <param name="weight">Weight.</param>
        /// <param name="height">Height.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {            
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException(nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900"))
            {
                throw new ArgumentException("");
            }

            if (weight <= 10)
            {
                throw new ArgumentException("");
            }

            if (height <= 10)
            {
                throw new ArgumentException("");
            }


            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "User Name can't be null or white space");
            }
            Name=name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}

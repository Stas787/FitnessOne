using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessOne//.BusinessLogic.Model
{
    /// <summary>
    /// Gender.
    /// </summary>

    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Create new gender.
        /// </summary>
        /// <param name="name">name of gender</param>
        /// <exception cref="ArgumentNullException"></exception>
  
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name),"Имя пола не может быть пустым или null");
            }

            Name = name;
        }
        //создаем конструктор
        public override string ToString()
        {
            return Name;
        }

    }
}

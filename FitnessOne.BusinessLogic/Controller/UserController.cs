using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


#pragma warning disable SYSLIB0011
namespace FitnessOne.BusinessLogic.Controller
{
    /// <summary>
    /// User Controller 
    /// </summary>
    public class UserController: ControllerBase
    {
        private const string UsersFileName = "users.dat";
        /// <summary>
        /// User of application
        /// Unsafe variant, made for faster development
        /// </summary>
        public  List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;


        /// <summary>
        /// Creation of new user controller
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            // TODO: must be check
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName), "User Name can't be null or white space");
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        /// <summary>
        /// Get Saved List of Users
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(UsersFileName) ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //Check

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Savae user's data.
        /// </summary>
        public void Save()
        {
            Save(UsersFileName, Users);
        }  
    }
}

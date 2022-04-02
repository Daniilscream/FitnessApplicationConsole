using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BL.Fitness.Controller
{
    public class UserController
    {
        public User User { get; }
        public UserController(string userName, string genderName, DateTime birthday, double weight, double height)
        {
            //TODO: Check it
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthday, weight, height);
        }

        /// <summary>
        /// Get data user
        /// </summary>
        /// <returns></returns>
        public UserController()
        {
            var formater = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.Open))
            {
                if (formater.Deserialize(fs) is User user)
                {
                    User = user;
                }

                //TODO: what doing if user can not read
            }
        }

        /// <summary>
        /// Save data user
        /// </summary>
        public void Save()
        {
            var formater = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
                formater.Serialize(fs, User);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace BL.Fitness.Controller
{
    public class UserController
    {
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("User name is empty", nameof(userName));

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
        /// Get data users
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formater = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formater.Deserialize(fs) is List<User> users)
                    return users;
                else
                    return new List<User>();
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDay, double weight = 30, double height = 120)
        {
            //conditions

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.Birthday = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Save data user
        /// </summary>
        public void Save()
        {
            var formater = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
                formater.Serialize(fs, Users);
        }
    }
}

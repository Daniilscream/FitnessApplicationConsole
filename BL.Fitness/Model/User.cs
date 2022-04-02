using System;

namespace BL.Fitness
{
    [Serializable]
    public class User
    {
        #region Properties
        public string Name { get; }
        public Gender Gender { get; }
        public DateTime Birthday { get; }
        public double Weight { get; set; }
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="name">User name</param>
        /// <param name="gender">User gender</param>
        /// <param name="birthday">User birthday</param>
        /// <param name="weight">User weight</param>
        /// <param name="height">User height</param>
        public User (string name, Gender gender, DateTime birthday, double weight, double height)
        {
            #region Change conditions
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Username doesn't be empty", nameof(name));
            if (gender == null)
                throw new ArgumentNullException("Gender name doesn't be empty", nameof(gender));
            if (birthday < DateTime.Parse("01.01.1940") || birthday >= DateTime.Now)
                throw new ArgumentException("You could not have been born on these dates", nameof(birthday));
            if (weight <= 20)
                throw new ArgumentException("There is nothing so skinny to do here!", nameof(weight));
            if (height <= 120)
                throw new ArgumentException("Too low is not welcome here", nameof(height));
            #endregion
            Name = name;
            Gender = gender;
            Birthday = birthday;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return $"Name: {Name} \n Gender: {Gender} \n Birthday: {Birthday} \n Weight: {Weight} \n Height: {Height}";
        }
    }
}

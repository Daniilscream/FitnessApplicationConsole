using System;

namespace BL.Fitness
{
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Create new gender
        /// </summary>
        /// <param name="name">Gender name</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Gender name doesn't be empty", nameof(name));

            Name = name;
        }
        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
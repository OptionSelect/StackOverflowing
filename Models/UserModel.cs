using System;
namespace StackOverflowing.Models
{
    public class UserModel
    {
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public bool IsMod { get; set; }

        public UserModel()
        {
        }
    }
}

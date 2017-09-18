using System;
namespace StackOverflowing.Models
{
    public class QuestionModel
    {
		public int ID { get; set; }
		public int VoteCount { get; set; }
		public String Title { get; set; }
        public String Body { get; set; }
		public int UserID { get; set; }
		public DateTime PostDate { get; set; }
        public UserModel UserModel { get; set; }

        public QuestionModel()
        {
        }
    }
}

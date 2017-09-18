using System;
namespace StackOverflowing.Models
{
    public class QuestionModel
    {
		public int ID { get; set; }
		public int VoteCount { get; set; }
		public String Title { get; set; }
        public String Body { get; set; }
		public String UserID { get; set; }
		public DateTime PostDate { get; set; } = DateTime.Now;
        public ApplicationUser ApplicationUser { get; set; }

        public QuestionModel()
        {
        }
    }
}

using System;
using System.Collections.Generic;

namespace StackOverflowing.Models
{
    public class QuestionModel
    {
		public int ID { get; set; }
		public int VoteCount { get; set; }
		public String Title { get; set; }
        public String Body { get; set; }
        public String ApplicationUserId { get; set; }
		public DateTime PostDate { get; set; } = DateTime.Now;
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<AnswerModel> Answers { get; set; } = new HashSet<AnswerModel>();

        public QuestionModel()
        {
        }
    }
}

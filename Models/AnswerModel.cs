using System;

namespace StackOverflowing.Models
{
    public class AnswerModel
    {
        public int ID { get; set; }
        public int VoteCount { get; set; }
        public String Body { get; set; }
        public String UserID { get; set; }
        public DateTime PostDate { get; set; }
        public int QuestionID { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public QuestionModel QuestionModel { get; set; }

        public AnswerModel()
        {
        }
    }
}

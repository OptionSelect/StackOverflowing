using System;

namespace StackOverflowing.Models
{
    public class AnswerModel
    {
        public int ID { get; set; }
        public int VoteCount { get; set; }
        public String Body { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;
        public int QuestionModelID { get; set; }
        public String ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public QuestionModel QuestionModel { get; set; }

        public AnswerModel()
        {
        }

    }
}

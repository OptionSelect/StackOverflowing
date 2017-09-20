using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowing.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        public string Body { get; set; }
        public DateTime PostDate { get; set; }
        public int AnswerModelID { get; set; }
        public int QuestionModelID { get; set; }
        public String ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public QuestionModel QuestionModel { get; set; }
        public CommentModel()
        {
        }
    }
}

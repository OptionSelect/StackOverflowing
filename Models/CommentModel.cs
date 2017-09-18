using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowing.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        public string Body { get; set; }
        public String UserID { get; set; }
        public DateTime PostDate { get; set; }
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }

        public UserModel UserModel { get; set; }
        public QuestionModel QuestionModel { get; set; }
        public AnswerModel AnswerModel { get; set; }

        public CommentModel()
        {
        }
    }
}

using System;
namespace StackOverflowing.Models
{
    public class QtieModel
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public int TagID { get; set; }

        public QuestionModel QuestionModel { get; set; }
        public TagModel TagModel { get; set; }

        public QtieModel()
        {
        }
    }
}

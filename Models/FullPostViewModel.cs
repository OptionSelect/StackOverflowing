using System;

namespace StackOverflowing.Models
{
    public class FullPostViewModel
    {
		public int VoteCount { get; set; }
		public String Title { get; set; }
        public String QuestionBody { get; set; }
		public String UserID { get; set; }
		public DateTime PostDate { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public CommentModel comment {get; set;}
        public string CommentBody { get; set; }
        public string AnswerBody { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int AnswerVoteCount {get; set;}
        public QuestionModel question {get; set;}
        public AnswerModel answer {get; set;}

        public FullPostViewModel(){}

        public FullPostViewModel(QuestionModel question, CommentModel comment, AnswerModel answer)
        {
            this.VoteCount = question.VoteCount;
            this.Title = question.Title;
            this.QuestionBody = question.Body;
            this.PostDate = question.PostDate;
            this.QuestionId = question.ID;
            this.AnswerVoteCount = answer.VoteCount;
            this.AnswerBody = answer.Body;
            this.CommentBody = comment.Body;
        }
    }
}
using kokshengoj.Domain.Common.Models;
using kokshengoj.Domain.QuestionSubmitAggregate.ValueObjects;

namespace kokshengoj.Domain.QuestionSubmitAggregate
{
    public sealed class QuestionSubmit : AggregateRoot<QuestionSubmitId, int>
    {
        public string language { get; set; }
        public string code { get; set; }
        public string judgeInfo { get; set; }
        public int status { get; set; }
        public int questionId { get; set; }
        public int userId { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public int isDelete { get; set; }

        private QuestionSubmit(
            QuestionSubmitId questionSubmitId,
            string language,
            string code,
            string judgeInfo,
            int status,
            int questionId,
            int userId,
            DateTime createTime,
            DateTime updateTime,
            int isDelete)
            : base(questionSubmitId)
        {
            language = language;
            code = code;
            judgeInfo = judgeInfo;
            status = status;
            questionId = questionId;
            userId = userId;
            createTime = createTime;
            updateTime = updateTime;
            isDelete = isDelete;
        }

        public static QuestionSubmit Create(
            string language,
            string code,
            string judgeInfo,
            int status,
            int questionId,
            int userId)
        {
            return new(
                null,  // EF Core will set this value
                language,
                code,
                judgeInfo,
                status,
                questionId,
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow,
                0);
        }

        // Private parameterless constructor for EF Core
        private QuestionSubmit() : base(null)
        {
            // EF Core requires an empty constructor for materialization
        }
    }
}

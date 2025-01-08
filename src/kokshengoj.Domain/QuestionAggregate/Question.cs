using kokshengoj.Domain.Common.Models;
using kokshengoj.Domain.QuestionAggregate.ValueObjects;

namespace kokshengoj.Domain.QuestionAggregate
{
    public sealed class Question : AggregateRoot<QuestionId, int>
    {
        public string title { get; set; }
        public string content { get; set; }
        public string tags { get; set; }
        public string answer { get; set; }
        public int submitNum { get; set; }
        public int acceptedNum { get; set; }
        public string judgeCase { get; set; }
        public string judgeConfig { get; set; }
        public int thumbNum { get; set; }
        public int favourNum { get; set; }
        public int userId { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public int isDelete { get; set; }

        private Question(
            QuestionId questionId,
            string title,
            string content,
            string tags,
            string answer,
            int submitNum,
            int acceptedNum,
            string judgeCase,
            string judgeConfig,
            int thumbNum,
            int favourNum,
            int userId,
            DateTime createTime,
            DateTime updateTime,
            int isDelete)
            : base(questionId)
        {
            title = title;
            content = content;
            tags = tags;
            answer = answer;
            submitNum = submitNum;
            acceptedNum = acceptedNum;
            judgeCase = judgeCase;
            judgeConfig = judgeConfig;
            thumbNum = thumbNum;
            favourNum = favourNum;
            userId = userId;
            createTime = createTime;
            updateTime = updateTime;
            isDelete = isDelete;
        }

        public static Question Create(
            string title,
            string content,
            string tags,
            string answer,
            int submitNum,
            int acceptedNum,
            string judgeCase,
            string judgeConfig,
            int thumbNum,
            int favourNum,
            int userId)
        {
            return new(
                null,  // EF Core will set this value
                title,
                content,
                tags,
                answer,
                submitNum,
                acceptedNum,
                judgeCase,
                judgeConfig,
                thumbNum,
                favourNum,
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow,
                0);
        }
        // Private parameterless constructor for EF Core
        private Question() : base(null)
        {
            // EF Core requires an empty constructor for materialization
        }
    }
}

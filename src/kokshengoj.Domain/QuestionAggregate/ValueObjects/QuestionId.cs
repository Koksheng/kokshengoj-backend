using kokshengoj.Domain.Common.Models;

namespace kokshengoj.Domain.QuestionAggregate.ValueObjects
{
    public sealed class QuestionId : AggregateRootId<int>
    {
        public override int Value { get; protected set; }
        public QuestionId(int value)
        {
            Value = value;
        }
        public static QuestionId Create(int value)
        {
            return new QuestionId(value);
        }
        //public static QuestionId CreateUnique()
        //{
        //    // Assuming you have a mechanism to generate unique integers, like an auto-incremented ID from a database.
        //    // Here, just for example, let's simulate generating a unique integer ID.
        //    // This should be replaced with your actual unique ID generation logic.
        //    int uniqueId = GenerateUniqueId();
        //    return new QuestionId(uniqueId);
        //}
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        //private static int GenerateUniqueId()
        //{
        //    // This is a placeholder. Replace it with your unique integer ID generation logic.
        //    // For example, you might fetch this from a database sequence or an auto-increment column.
        //    // Here, we'll just use a static counter for demonstration purposes.

        //    // Simulate an ID generation logic
        //    Random random = new Random();
        //    return random.Next(1, int.MaxValue);
        //}
    }
}

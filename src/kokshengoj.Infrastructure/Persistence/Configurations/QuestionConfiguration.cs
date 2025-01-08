using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using kokshengoj.Domain.QuestionAggregate;
using kokshengoj.Domain.QuestionAggregate.ValueObjects;

namespace kokshengoj.Infrastructure.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            ConfigureQuestionsTable(builder);
        }
        private void ConfigureQuestionsTable(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
                   .HasConversion(
                       id => id.Value,
                       value => QuestionId.Create(value))
                   .ValueGeneratedOnAdd() // Ensure ID is generated on add
                   .IsRequired();

            //builder.Property(m => m.name).HasMaxLength(1000);
        }
    }
}

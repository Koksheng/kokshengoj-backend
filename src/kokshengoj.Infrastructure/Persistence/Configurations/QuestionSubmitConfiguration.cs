using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using kokshengoj.Domain.QuestionSubmitAggregate;
using kokshengoj.Domain.QuestionSubmitAggregate.ValueObjects;

namespace kokshengoj.Infrastructure.Persistence.Configurations
{
    public class QuestionSubmitConfiguration : IEntityTypeConfiguration<QuestionSubmit>
    {
        public void Configure(EntityTypeBuilder<QuestionSubmit> builder)
        {
            ConfigureQuestionSubmitsTable(builder);
        }
        private void ConfigureQuestionSubmitsTable(EntityTypeBuilder<QuestionSubmit> builder)
        {
            builder.ToTable("QuestionSubmits");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
                   .HasConversion(
                       id => id.Value,
                       value => QuestionSubmitId.Create(value))
                   .ValueGeneratedOnAdd() // Ensure ID is generated on add
                   .IsRequired();

            //builder.Property(m => m.name).HasMaxLength(1000);
        }
    }
}

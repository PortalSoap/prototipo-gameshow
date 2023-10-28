using Microsoft.EntityFrameworkCore;
using ButtonBattle.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ButtonBattle.Data.Map;

public class QuestionMap : IEntityTypeConfiguration<QuestionViewModel>
{
    public void Configure(EntityTypeBuilder<QuestionViewModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Theme).IsRequired().HasMaxLength(60);
        builder.Property(x => x.Question).IsRequired().HasMaxLength(350);
        builder.Property(x => x.OptionA).IsRequired();
        builder.Property(x => x.OptionB).IsRequired();
        builder.Property(x => x.OptionC).IsRequired();
        builder.Property(x => x.OptionD).IsRequired();
        builder.Property(x => x.OptionE).IsRequired();
        builder.Property(x => x.CorrectOption).IsRequired();
    }
}
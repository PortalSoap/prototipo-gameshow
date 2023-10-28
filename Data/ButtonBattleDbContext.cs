using Microsoft.EntityFrameworkCore;
using ButtonBattle.Models;
using ButtonBattle.Data.Map;

namespace ButtonBattle.Data;

public class ButtonBattleDbContext : DbContext
{
    public ButtonBattleDbContext(DbContextOptions<ButtonBattleDbContext> options)
    : base(options)
    {

    }

    public DbSet<QuestionViewModel> Questions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new QuestionMap());
        
        base.OnModelCreating(modelBuilder);
    }
}
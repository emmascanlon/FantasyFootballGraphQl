using Microsoft.EntityFrameworkCore;

public class LeagueDbContext : DbContext
{
    //   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         optionsBuilder.UseSqlServer("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
    //     }
    // }
    public LeagueDbContext(DbContextOptions<LeagueDbContext> options) : base(options){}
    public DbSet<TeamDto> Teams {get; set;} 
    public DbSet<PlayerDto> Players {get; set;}
    public DbSet<FantasyTeamDto> FantasyTeams {get; set;}
}
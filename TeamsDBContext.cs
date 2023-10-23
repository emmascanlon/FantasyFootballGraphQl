using Microsoft.EntityFrameworkCore;
using TeamsAndPlayersGraphQL;

public class TeamsDbContext: DbContext
{
    public TeamsDbContext(DbContextOptions<TeamsDbContext> options) : base(options) { }

    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
}
using System.Data.SqlClient;
using Dapper;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using TeamsAndPlayersGraphQL;

public class Query {

      private LeagueDbContext _context;
      public Query(LeagueDbContext context)
      {
            _context = context;
      }

    //[UsePaging(IncludeTotalCount = true, DefaultPageSize = 3)]
        public async Task<IQueryable<TeamDto>> Teams()
    {

           return _context.Teams;
    }

    [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 3)]
        public async Task<IQueryable<Team>> GetOffsetTeams()
    {
           SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
           var list = await connection.QueryAsync<Team>("SELECT * FROM Teams");
           return list.AsQueryable();
    }

    public async Task<Team?> Team(int id)
    {
        SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
           var list = await connection.QueryAsync<Team>(@"SELECT * FROM Teams WHERE Id = @id", parameters);
           return list.FirstOrDefault();
    }

    public async Task<IQueryable<Player>> Players()
    {
        {
        var playerDTOs = _context.Players
            .Include(p => p.Team)
           .Include(p => p.FantasyTeam);

        return playerDTOs.Select(player => new Player {
                Id = player.Id,
                Name = player.PlayerName,
                TeamId = player.TeamId,
                Team = new Team {
                    Name = player.Team.TeamName,
                    Logo = player.Team.Logo,
                    UpcomingMatchIsHomeMatch = player.Team.UpcomingMatchIsHomeMatch,
                    UpcomingOpponentName = player.Team.UpcomingOpponentName

                },
                FantasyTeamId = player.FantasyTeamId,
                FantasyTeam = new FantasyTeam {
                    TeamName = player.FantasyTeam.TeamName,
                    ManagerName = player.FantasyTeam.ManagerName,
                },
                HealthStatus = player.HealthStatus,
                 PassCompletionsPerGame = player.PassCompletionsPerGame,
                //Photo = player.Photo,
                ProjectedPoints = player.ProjectedPoints,
                RecYardsPerGame = player.RecYardsPerGame,
                RushYdsPerGame = player.RushYdsPerGame,
                TdPerGame = player.TdPerGame,
                 TotalFantasyPoints = player.TotalFantasyPoints
        });
        }
    }
}
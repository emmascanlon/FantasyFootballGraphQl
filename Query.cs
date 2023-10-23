using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace TeamsAndPlayersGraphQL
{
    public class Query
{
        private readonly IDbContextFactory<TeamsDbContext> _contextFactory;
        public Query(IDbContextFactory<TeamsDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        //public IQueryable<Player>? GetPlayers()
        //{
        //    Console.WriteLine("get Players");
        //    return Context.Players.AsQueryable();
        //}
        //public Team GetTeam(DeleteTeamInput input)
        //{
        //    return Context.Teams.FirstOrDefault(team => team.Id == input.Id) ?? new Team();
        //}
        public IQueryable<Player>? Players()
    {
        SqlConnection con = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Players", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Player> playerList = new List<Player>();
            if (dt.Rows.Count > 0 )
            {
                for(int i=0; i < dt.Rows.Count; i++)
                {
                    Player player = new Player
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                        Name = Convert.ToString(dt.Rows[i]["Name"]),
                        TeamId = Convert.ToInt32(dt.Rows[i]["TeamId"])
                    };
                    playerList.Add(player);
                }
            }
            return playerList.AsQueryable();
    }
}
}

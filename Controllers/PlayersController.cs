using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace TeamsAndPlayersGraphQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {

        public PlayersController()
        {
        }

        [HttpGet]
        [Route("/GetAllPlayers")]
        public async Task<IEnumerable<Player>> GetPlayers()
        {
            SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
            var list = await connection.QueryAsync<Player>("SELECT * FROM Players");
            return list;
        }


        private List<Player> GetPlayerListFrom(SqlDataAdapter da)
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Player> playerList = new List<Player>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Player player = new Player();
                    player.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    player.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    player.TeamId = Convert.ToInt32(dt.Rows[i]["TeamId"]);
                    playerList.Add(player);
                }
            }
            return playerList;
        }




        //[HttpGet]
        //[Route("/GetAllPlayersWithTeams")]
        //public List<Player> GetPlayersWithTeams()
        //{
        //    SqlConnection con = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
        //    SqlDataAdapter da = new SqlDataAdapter("select p.Id as Id, p.Name as name, p.TeamId as TeamId, t.Name as TeamName, t.Logo from Players p\r\njoin Teams t on T.Id = p.TeamId", con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    List<Player> playerList = new List<Player>();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            Player player = new Player();
        //            player.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
        //            player.Name = Convert.ToString(dt.Rows[i]["Name"]);
        //            player.TeamId = Convert.ToInt32(dt.Rows[i]["TeamId"]);
        //            player.TeamName = Convert.ToString(dt.Rows[i]["TeamName"]);
        //            player.TeamLogo = Convert.ToString(dt.Rows[i]["Logo"]);

        //            playerList.Add(player);
        //        }
        //    }
        //    return playerList;
        //}
    }
}
using Microsoft.AspNetCore.Mvc;
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
            Console.WriteLine("CONTROLLER");
           SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
           var list = await connection.QueryAsync<Player>("SELECT * FROM Players");
           return list;
       }


       [HttpGet]
       [Route("/GetAllTeams")]
         public async Task<IEnumerable<Player>> GetTeams()
       {
           SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
           var list = await connection.QueryAsync<Player>("SELECT * FROM Teams t JOIN Players on t.Id == TeamId");
           return list;
       }

    //    [HttpGet]
    //    [Route("/GetAllTeams")]
    //      public async Task<IEnumerable<Player>> GetTeams()
    //    {
    //        var players = _client.GetAllPlayersFromSomewhere();
    //        var teams = _otherClient.GetAllTeamsFromSomewhere();
    //        return players.Join(teams);
    //    }

   }
}
using TeamsAndPlayersGraphQL;
using System.Data.SqlClient;
using Dapper;

namespace TeamsAndPlayersGraphQL
{
    public class Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TeamId { get; set; }
        public async Task<Team?> Team()
        {
            SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
            var parameters = new DynamicParameters();
            parameters.Add("@id", TeamId);
            var teams = await connection.QueryAsync<Team>(@"SELECT * FROM Teams WHERE id = @id", parameters);
            return teams.FirstOrDefault();
        }
    }
}

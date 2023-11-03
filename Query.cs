using TeamsAndPlayersGraphQL;
using System.Data.SqlClient;
using Dapper;
public class Query
{
    public async Task<IQueryable<Player>> GetPlayers()
    {
            SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
            var list = await connection.QueryAsync<Player>("SELECT * FROM Players");
            return list.AsQueryable();
    }

    public async Task<IQueryable<Team>> Teams()
    {
            SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
            var list = await connection.QueryAsync<Team>("SELECT * FROM Teams");
            return list.AsQueryable();
    }

    public async Task<Team?> GetTeam(int id)
    {
        SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
        var teams = await connection.QueryAsync<Team>(@"SELECT * FROM Teams WHERE id = @id", parameters);
        return teams.FirstOrDefault();
    }
}
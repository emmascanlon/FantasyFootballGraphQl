using System.Data.SqlClient;
using Dapper;

public class Query {
    public async Task<IQueryable<Team>> Teams()
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
}
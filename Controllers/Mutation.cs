using System.Data.SqlClient;
using Dapper;

public class Mutation
{
    public async Task<IQueryable<Team>> AddTeam(CreateTeamInput input)
    {
          SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
        var parameters = new DynamicParameters();
        parameters.Add("@name", input.Name);
        parameters.Add("@logo", input.Logo);
           var list = await connection.QueryAsync<Team>(@"INSERT INTO Teams (Name, Logo) Values (@name, @logo)
           SELECT * FROM Teams", parameters);
           return list.AsQueryable();
    }

       public async Task<IQueryable<Team>> UpdateTeam(UpdateTeamInput input)
    {
          SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
        var parameters = new DynamicParameters();
        parameters.Add("@name", input.Name);
        parameters.Add("@logo", input.Logo);
        parameters.Add("@id", input.Id);
           var list = await connection.QueryAsync<Team>(@"UPDATE teams SET Name = @name, Logo = @logo WHERE Id = @id
           SELECT * FROM Teams", parameters);
           return list.AsQueryable();
    }

          public async Task<IQueryable<Team>> DeleteTeam(int id)
    {
          SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
           var list = await connection.QueryAsync<Team>(@"DELETE FROM Teams WHERE id = @id
           SELECT * FROM Teams", parameters);
           return list.AsQueryable();
    }


}
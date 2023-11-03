using Dapper;
using System;
using System.Data.SqlClient;

public class Mutation
{
	public async Task<IQueryable<Team>> AddTeam(CreateTeamInput input)
	{
        SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
        var parameters = new DynamicParameters();
        parameters.Add("@name", input.Name);
        parameters.Add("@logo", input.Logo);
        var teams = await connection.QueryAsync<Team>(
        @"INSERT INTO Teams (Name, Logo) VALUES (@name, @logo) 
        SELECT * FROM Teams"
        , parameters);
        return teams.AsQueryable();
    }

    	public async Task<IQueryable<Team>> DeleteTeam(int id)
	{
        SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
        var teams = await connection.QueryAsync<Team>(
        @"DELETE FROM Teams WHERE id = @id
        SELECT * FROM Teams"
        , parameters);
        return teams.AsQueryable();
    }

    public async Task<IQueryable<Team>> UpdateTeam(UpdateTeamInput input)
    {
        SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
        var parameters = new DynamicParameters();
        parameters.Add("@id", input.Id);
        parameters.Add("@name", input.Name);
        parameters.Add("@logo", input.Logo);

        var teams = await connection.QueryAsync<Team>(
        @"UPDATE teams SET Name = @name, Logo = @logo WHERE id = @id
        SELECT * FROM Teams"
        , parameters);
        return teams.AsQueryable();
    }
}

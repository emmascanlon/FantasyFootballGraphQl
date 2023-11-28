﻿using System.Data.SqlClient;
using Dapper;
using HotChocolate;
using TeamsAndPlayersGraphQL;
using TeamsAndPlayersGraphQL.Controllers;

public class Team
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Logo{ get; set; }
    public async Task<Player[]> Players([Service] PlayersDataLoader playersDataLoader)
    {
        return await playersDataLoader.LoadAsync(Id, CancellationToken.None);
    }
}
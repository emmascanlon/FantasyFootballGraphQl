using System.Data.SqlClient;
using Dapper;
using HotChocolate;
using HotChocolate.Types.Pagination;
using TeamsAndPlayersGraphQL;
using TeamsAndPlayersGraphQL.Controllers;

public class Team
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Logo{ get; set; }
    public string UpcomingOpponentName {get; set;}
    public bool UpcomingMatchIsHomeMatch {get; set;}
    public async Task<Player[]> Players([Service] PlayersDataLoader playersDataLoader)
    {
        return await playersDataLoader.LoadAsync(Id, CancellationToken.None);
    }
}

// public class TeamsConnection
// {
//     public PageInfoType? PageInfo {get; set;}
//     public TeamsEdge[]? Edges {get; set;}
//     public Team[]? Nodes {get; set;}
// }

// public class TeamsEdge
// {
//     public string? Cursor {get; set;}
//     public Team? Node {get; set;}
// }

// public class PageInfo{
//     public bool HasNextPage {get; set;}
//     public bool HasPreviousPage {get; set;}
//     public string? StartCursor {get; set;}
//     public string? EndCursor {get; set;}
// }
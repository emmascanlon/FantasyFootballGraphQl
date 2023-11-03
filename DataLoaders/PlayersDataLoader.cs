using System.Data.SqlClient;
using Dapper;
using GreenDonut;
using HotChocolate.DataLoader;

namespace TeamsAndPlayersGraphQL;
public class PlayersDataLoader : GroupedDataLoader<int, Player>
{
     
    public PlayersDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions<int>? options = null) : base(batchScheduler, options)
    {
    }

    protected override async Task<ILookup<int, Player>> LoadGroupedBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        SqlConnection connection = new SqlConnection("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true");
        var players = await connection.QueryAsync<Player>(@"SELECT * FROM Players WHERE TeamId IN @TeamIds", new {TeamIds = keys.ToArray()});
        return players.ToLookup(p=>p.TeamId);
    }
}
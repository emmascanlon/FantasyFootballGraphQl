using System.Data.SqlClient;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

public class Mutation
{
      private LeagueDbContext _context;
      public Mutation(LeagueDbContext context)
      {
            _context = context;
      }
    public IQueryable<TeamDto> AddTeam(CreateTeamInput input)
      {
            _context.Teams.Add(new TeamDto { TeamName = input.Name, Logo = input.Logo });
            _context.SaveChanges();
            return _context.Teams.AsQueryable();
      }

    //   public async Task<TeamDto> UpdateTeam(UpdateTeamInput input)
    //   {
    //         var team = new TeamDto{TeamName = input.Name, Id = input.Id, Logo = input.Logo};
    //         _context.Teams.Update(team);
    //        await  _context.SaveChangesAsync();
    //         return team;
    //   }

    //   public async Task<bool> DeleteTeam(int id)
    //   {
    //         var team = new TeamDto 
    //         {
    //               Id = id
    //         };
    //         _context.Teams.Remove(team);
    //        return await _context.SaveChangesAsync() > 0;
    //   }
}
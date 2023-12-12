namespace TeamsAndPlayersGraphQL
{
    public class Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TeamId { get; set; }
        public Team Team {get; set;}
        public int? FantasyTeamId {get; set;}
        public FantasyTeam? FantasyTeam {get; set;}
        public string HealthStatus {get; set;}
        public string Photo {get; set;}
        public decimal ProjectedPoints {get; set;}
        public int TotalFantasyPoints {get; set;}
        public decimal TdPerGame {get; set;}
        public decimal RushYdsPerGame {get; set;}
        public decimal RecYardsPerGame {get; set;}
        public decimal PassCompletionsPerGame {get; set;}
        public string Position {get; set;}
    }
}

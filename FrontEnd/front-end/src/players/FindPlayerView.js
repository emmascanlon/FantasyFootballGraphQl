import React from "react";
import { useQuery, gql } from "@apollo/client";

const PLAYERS_QUERY = gql`
{
  players {
      name, id, team {
        name
      }
  }
}
`;

export const FindPlayerView = () => {
  const { data, loading, error } = useQuery(PLAYERS_QUERY);

  if (loading) return "Loading...";
  if (error) return <pre>{error.message}</pre>

  return (
    <div>
      <h1>All Players</h1>
      <ul>
        {data.players.map((player) => (
          <li key={player.id}>{player.name}-{player.team.name}</li>
        ))}
      </ul>
    </div>
  );
}
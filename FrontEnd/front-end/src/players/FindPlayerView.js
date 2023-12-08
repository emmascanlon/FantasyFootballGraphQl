import React from "react";
import { useQuery, gql } from "@apollo/client";
import { PlayerRow } from "./PlayerRow";
import {styled} from "styled-components";

const AllPlayers = styled.div`
  max-width: 500px;
  justify-self: center;
  padding: 12px;
`;

const FlexDiv = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-evenly;
  align-items: center;
`;

const SelectionBar = () => {
  return(
    <FlexDiv>
      <button>Available</button>
      <button>Leaders</button>
      </FlexDiv>
  )
}

const PLAYERS_QUERY = gql`
{
  players {
      name, id, position, projectedPoints, 
      totalFantasyPoints, healthStatus, rushYdsPerGame, recYardsPerGame, passCompletionsPerGame, tdPerGame,
      team {
        name, logo, id, upcomingOpponentName, upcomingMatchIsHomeMatch
      },
      fantasyTeam {
        managerName
      }
  }
}
`;

export const FindPlayerView = () => {
  const { data, loading, error } = useQuery(PLAYERS_QUERY, {fetchPolicy: "no-cache"});

  if (loading) return "Loading...";
  if (error) return <pre>{error.message}</pre>

  return (
    <AllPlayers>
      <h1>Players</h1>
      <SelectionBar />
      <ul>
        {data.players.map((player, index) => (
          <PlayerRow key={player.id} player = {player} index={index} />
        ))}
      </ul>
    </AllPlayers>
  );
}
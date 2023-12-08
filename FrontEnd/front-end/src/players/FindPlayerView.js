import React from "react";
import { useQuery, gql } from "@apollo/client";
import { PlayerRow } from "./PlayerRow";
import {styled} from "styled-components";
import {SelectionBar} from "./SelectionBar";
import {PositionSelector} from './PositionSelector';

const AllPlayers = styled.div`
  max-width: 600px;
  min-width: 600px;
  justify-self: center;
  padding: 12px;
`;


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
      <PositionSelector />
      <ul>
        {data.players.map((player, index) => (
          <PlayerRow key={player.id} player = {player} index={index} />
        ))}
      </ul>
    </AllPlayers>
  );
}
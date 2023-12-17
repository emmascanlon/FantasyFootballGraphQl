import React, {useState} from "react";
import { useQuery, gql } from "@apollo/client";
import { PlayerRow } from "./PlayerRow";
import {styled} from "styled-components";
import {SelectionBar} from "./SelectionBar";
import {PositionSelector} from './PositionSelector';
import { InView} from 'react-intersection-observer';

const AllPlayers = styled.div`
  max-width: 600px;
  min-width: 600px;
  justify-self: center;
  padding: 12px;
`;

export const FindPlayerView = () => {
  const [selectedPosition, setSelectedPosition] = useState('QB');
  const [showLeaderBoard, setShowLeaderBoard] = useState(true)
  const PLAYERS_QUERY = gql`
  query Players($first: Int!, $after: String!, $filter: PlayerFilterInput!, $sort: [PlayerSortInput!]) {
    players(first: $first, after: $after, where: $filter, order: $sort){
    edges {
        node {
         name, id, projectedPoints, totalFantasyPoints, healthStatus, rushYdsPerGame, recYardsPerGame, passCompletionsPerGame, tdPerGame, position,
         team {
             name, logo, id, upcomingOpponentName, upcomingMatchIsHomeMatch
         },
         fantasyTeam {
             managerName
         }
             }
    },
    pageInfo {
        hasNextPage,
        hasPreviousPage,
        endCursor
    },
    totalCount
    }
  }
  `;

  const positionFilter = {position: {eq: selectedPosition}}
  const availibilityFilter = {fantasyTeam : {managerName : {eq: null}}}
  const positionAndAvailibilityFilter = {and: [positionFilter, availibilityFilter]}

  const getFilterObject = () => {
    if (!showLeaderBoard)
    {
      return selectedPosition ? positionAndAvailibilityFilter: availibilityFilter
    }
    else {
      return selectedPosition ? positionFilter : {}
    }
  }

  const { data, loading, error, fetchMore } = useQuery(PLAYERS_QUERY, {
    variables: {
      first: 10,
      after: "MA==",
      filter: getFilterObject(),
      sort: [showLeaderBoard ? {totalFantasyPoints: "DESC" } : {projectedPoints: "DESC"}]
    }
  });

  if (loading) return "Loading...";
  if (error) return <pre>{error.message}</pre>



  const onInView = (inView) => {
    if (inView && data.players.pageInfo.hasNextPage) 
    {
      fetchMore({
      variables: {
        first: 10,
        after: data.players.pageInfo.endCursor
      },
      updateQuery: ( prev, { fetchMoreResult }) => {
        console.log(prev)
        console.log(fetchMoreResult)
        if (!fetchMoreResult) return prev;
        return {
          ...prev,
          players: {
            edges: [...prev.players.edges, ...fetchMoreResult.players.edges],
            pageInfo: fetchMoreResult.players.pageInfo,
            totalCount: fetchMoreResult.players.totalCount},
        }
      }
    });
  }
  }
  return (
    <AllPlayers>
      <h1>Players</h1>
      <i>{data.players.totalCount} players found</i>
      <SelectionBar showLeaderBoard= {showLeaderBoard} setShowLeaderBoard={setShowLeaderBoard}/>
      <PositionSelector setPosition = {setSelectedPosition} selectedPosition={selectedPosition}/>
      <ul>
        {data.players.edges.map((player, index) => {
          if (data.players.edges.length === index + 1)
          {
            return( 
              <InView key={player.id} onChange ={(inView) => onInView(inView)}> 
                <PlayerRow key={player.id} player={player.node} index={index} />
            </InView>
            )
          }
          else return <PlayerRow key={player.id} player = {player.node} index={index} />
        
})}
      </ul>
    </AllPlayers>
  );
}
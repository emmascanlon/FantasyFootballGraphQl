import React from 'react';
import {styled} from "styled-components";

const FlexDiv = styled.div`
display: flex;
justify-content: space-between;
align-items: center;
margin: 3px;
background-color: ${props => props.background ?? 'white'};
padding: 4px 10px;
`;

const PlayerRowDiv = styled.div`
    margin-bottom: 20px;
`;

const ProjectedPoints = styled.div`
    background-color: #808080;
    color: white;
    display: flex;
    flex-direction: column;
    padding: 5px 8px;
    justify-content: space-evenly;
    max-height: 30px;
`;

const SmallFont = styled.div`
    color: #D3D3D3;
    font-size: 8px;
`;

const StatDiv = styled.button`
display: flex;
flex-direction: column;
background-color:  #808080;
border: none;
`;

const Stat = styled.div`
color: white;
`;

const Username = styled.div`
    font-size: 14px;
    color: darkRed;
`;

const BioDiv = styled.div`
    max-width: 350px;
    min-width: 350px;
`;

const Index = styled.div`
font-size: 24px;
`;

const StatBar = ({player}) => {
    return (
        <FlexDiv background={'#808080'}>
            <StatDiv>
            <SmallFont>FPTS</SmallFont>
            <Stat>{player.totalFantasyPoints}</Stat>
            </StatDiv>
            <StatDiv>
            <SmallFont>  RUSH YDS</SmallFont>
           <Stat> {player.rushYdsPerGame}</Stat>
            </StatDiv>
            <StatDiv>
            <SmallFont>  REC YDS</SmallFont>
                <Stat>{player.recYardsPerGame}</Stat>
            </StatDiv>
            <StatDiv>
            <SmallFont>  PASS CMP</SmallFont>
                <Stat>{player.passCompletionsPerGame}</Stat>
            </StatDiv>
            <StatDiv>
            <SmallFont>   TD</SmallFont>
            <Stat>{player.tdPerGame}</Stat>
            </StatDiv>
        </FlexDiv>
    )
}

export const PlayerRow =({player, index}) => {
var {upcomingMatchIsHomeMatch, upcomingOpponentName} = player.team;

    return(
        <PlayerRowDiv>
        <FlexDiv>
        <Index>{index + 1}</Index>
         <BioDiv>
         <strong>{player.name}</strong> 
            <div>{player.position}-{player.team.name}</div>
            <div>Sun 2:00 PM {`${upcomingMatchIsHomeMatch ? "vs." : "@"} ${upcomingOpponentName}`}</div>
            {player.fantasyTeam && <Username>&rarr; {player.fantasyTeam.managerName}</Username>}
        </BioDiv>
        <ProjectedPoints>
            <SmallFont>PROJ</SmallFont> 
            <div>{player.projectedPoints}</div>
        </ProjectedPoints>
        </FlexDiv>
        <StatBar player={player}/>
        </PlayerRowDiv>
    )
}
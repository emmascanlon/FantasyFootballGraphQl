import React from 'react';
import {FaChartLine} from 'react-icons/fa';
import styled from "styled-components";
import { GiAmericanFootballHelmet } from "react-icons/gi";
import { Button } from '../components';

const FlexDiv = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-evenly;
  align-items: center;
  margin-bottom: 20px;
`;

export const SelectionBar = ({showLeaderBoard, setShowLeaderBoard}) => {
  const toggleBoard = () => {
    setShowLeaderBoard(prev=> !prev);
  }
  return(
    <FlexDiv>
      <Button onClick = {toggleBoard} isSelected={!showLeaderBoard}>
        <GiAmericanFootballHelmet/>
        <div>Available</div>
        </Button>
      <Button onClick={toggleBoard} isSelected={showLeaderBoard}>
        <FaChartLine /> 
        <div>Leaders</div>
        </Button>
      </FlexDiv>
  )
}
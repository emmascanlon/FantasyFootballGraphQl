import React from 'react';
import styled from "styled-components";
import {Button} from "../components"

const FlexDiv = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-evenly;
  align-items: center;
`;

const positions = ['QB', 'RB', 'WR', 'TE', 'DEF'];
export const PositionSelector = ({selectedPosition, setPosition}) => {
  const toggleButton = (e) => {
    console.log(e.target.value);
    console.log(selectedPosition)
    selectedPosition === e.target.value ? setPosition(null) : setPosition(e.target.value)
  }
  return(
    <FlexDiv>
     {positions.map(pos => (
        <Button key={pos} value={pos} onClick = {toggleButton} isSelected={selectedPosition === pos}>
            {pos}
        </Button>
     ))}
      </FlexDiv>
  )
}
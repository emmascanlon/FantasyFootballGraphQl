import React from 'react';
import styled from "styled-components";

const FlexDiv = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-evenly;
  align-items: center;
`;

const positions = ['QB', 'RB', 'WR', 'TE', 'DEF'];
export const PositionSelector = () => {
  return(
    <FlexDiv>
     {positions.map(pos => (
        <button>
            {pos}
        </button>
     ))}
      </FlexDiv>
  )
}
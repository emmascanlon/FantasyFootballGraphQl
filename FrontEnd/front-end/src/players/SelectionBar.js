import React from 'react';
import {FaChartLine} from 'react-icons/fa';
import styled from "styled-components";
import { GiAmericanFootballHelmet } from "react-icons/gi";

const FlexDiv = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-evenly;
  align-items: center;
  margin-bottom: 20px;
`;

export const SelectionBar = () => {
  return(
    <FlexDiv>
      <button>
        <GiAmericanFootballHelmet/>
        <div>Available</div>
        </button>
      <button>
        <FaChartLine /> 
        <div>Leaders</div>
        </button>
      </FlexDiv>
  )
}
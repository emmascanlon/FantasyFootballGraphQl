import styled from "styled-components";

const selectedColor = "#808080";
export const Button = styled.button`
  background-color: ${props => props.isSelected ? selectedColor : "white"};
  color: ${props => props.isSelected && "yellow"}
`;
import React from "react";
import { ApolloProvider, ApolloClient, InMemoryCache, HttpLink } from "@apollo/client";
import styled from 'styled-components';
import { FindPlayerView} from "./players/FindPlayerView";

const client = new ApolloClient({
  link: new HttpLink({
    uri: "http://localhost:5191/graphql",
  }),
  cache: new InMemoryCache(),
});

const CenteredDiv = styled.div`
  display: flex;
  justify-content: center;
`;

function App() {
  return (
    <ApolloProvider client={client}>
      <CenteredDiv>
    <FindPlayerView />
    </CenteredDiv>
  </ApolloProvider>
  );
}

export default App;

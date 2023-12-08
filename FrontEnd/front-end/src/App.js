import React from "react";
import { ApolloProvider, ApolloClient, InMemoryCache, HttpLink } from "@apollo/client";

import { FindPlayerView } from "./players/FindPlayerView";

const client = new ApolloClient({
  link: new HttpLink({
    uri: "http://localhost:5191/graphql",
  }),
  cache: new InMemoryCache(),
});

function App() {
  return (
    <ApolloProvider client={client}>
    <FindPlayerView />
  </ApolloProvider>
  );
}

export default App;

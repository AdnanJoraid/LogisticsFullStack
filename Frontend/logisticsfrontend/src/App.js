import React, { Component } from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link,
  BrowserRouter,
} from "react-router-dom";
import HomeView from "./Views/HomeView";

function App() {
  return (
    <Router>
      <Routes>
        <Route exact path="/" element={<HomeView />} />
      </Routes>
    </Router>
  );
}

export default App;

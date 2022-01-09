import React, { Component } from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link,
  BrowserRouter,
} from "react-router-dom";
import HomeView from "./Views/HomeView";
import CreateView from "./Views/CreateView";
import ViewItem from "./Views/ViewItems";

function App() {
  return (
    <Router>
      <Routes>
        <Route exact path="/" element={<HomeView />} />
        <Route path="/Create" element={<CreateView />} />
        <Route path="/View" element={<ViewItem />} />
      </Routes>
    </Router>
  );
}

export default App;

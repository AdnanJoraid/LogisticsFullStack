import React, { Component } from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import HomeView from "./Views/HomeView";
import CreateView from "./Views/CreateView";
import ViewItem from "./Views/ViewItems";
import WarehousesView from "./Views/WarehousesView";
import TransactionsView from "./Views/TransactionsView";
import InventoryItemsView from "./Views/InventoryItemsView";
import EditInventoryView from "./Views/EditInventoryView";
import EditWarehouseView from "./Views/EditWarehouseView";
function App() {
  return (
    <Router>
      <Routes>
        <Route exact path="/" element={<HomeView />} />
        <Route path="/Create" element={<CreateView />} />
        <Route path="/View" element={<ViewItem />} />
        <Route path="/View/InventoryItems" element={<InventoryItemsView />} />
        <Route path="/View/Warehouses" element={<WarehousesView />} />
        <Route path="/View/Transactions" element={<TransactionsView />} />
        <Route path="/EditInventory/:id" element={<EditInventoryView />} />
        <Route path="/EditWarehouse/:id" element={<EditWarehouseView />} />
      </Routes>
    </Router>
  );
}

export default App;

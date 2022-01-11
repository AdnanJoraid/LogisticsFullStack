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
import EditTransactionView from "./Views/EditTransactionView";
import CreateTransactionView from "./Views/CreateTransactionView";
import CreateInventoryItemView from "./Views/CreateInventoryItemView";
import CreateWarehoseView from "./Views/CreateWarehouseView";

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
        <Route path="/EditTransaction/:id" element={<EditTransactionView />} />
        <Route
          path="/Create/InventoryItem"
          element={<CreateInventoryItemView />}
        />
        <Route path="/Create/Warehouse" element={<CreateWarehoseView />} />

        <Route path="/Create/Transaction" element={<CreateTransactionView />} />
      </Routes>
    </Router>
  );
}

export default App;

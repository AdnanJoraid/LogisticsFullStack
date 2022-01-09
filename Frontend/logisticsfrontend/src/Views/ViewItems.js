import React from "react";
import "../Styles/HomeView.css";
import { useNavigate } from "react-router-dom";
const ViewItems = () => {
      const navigate = useNavigate();

  return (
    <div className="center" style={{ margin: 55 }}>
      <h1>
        Welcome To Logistics - Shopify summer 2022 backend challenge - By Adnan
        Joraid
      </h1>
      <div style={{ margin: 280 }}>
        <button
          style={{ width: 350, height: 50, margin: 10 }}
          className="buttonStyle"
          onClick={() => navigate("/View/InventoryItems")}
        >
          View Inventory Items
        </button>
        <div></div>
        <button
          style={{ width: 350, height: 50, margin: 10 }}
          className="buttonStyle"
          onClick={() => navigate("/View/Warehouses")}
        >
          View Warehouses
        </button>
        <div></div>
        <button
          style={{ width: 350, height: 50, margin: 10 }}
          className="buttonStyle"
          onClick={() => navigate("/View/Transactions")}
        >
          View Transactions
        </button>
      </div>
    </div>
  );
};

export default ViewItems;

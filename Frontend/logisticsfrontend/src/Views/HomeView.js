import React from "react";
import { Stack, Button } from "react-bootstrap/";
import "../Styles/HomeView.css";

function HomeView() {
  return (
    <div className="center" style={{ margin: 55 }}>
      <h1>
        Welcome To Logistics - Shopify summer 2022 backend challenge - By Adnan
        Joraid
      </h1>
      <div className="center" style={{ margin: 300 }}>
        <button style={{ width: 350, height: 50 }} className="buttonStyle">
          Create items, warehouses, and transactions
        </button>
        <button
          style={{ width: 350, height: 50 }}
          className="buttonStyleSecondary"
        >
          View items, warehouses, and transactions
        </button>
      </div>
    </div>
  );
}

export default HomeView;

import React from "react";
import "../Styles/HomeView.css";
import { useNavigate } from "react-router-dom";
function HomeView() {
  const navigate = useNavigate();
  return (
    <div className="center" style={{ margin: 55 }}>
      <h1>
        Welcome To Logistics - Shopify summer 2022 backend challenge - By Adnan
        Joraid
      </h1>
      <div className="center" style={{ margin: 300 }}>
        <button
          style={{ width: 350, height: 50 }}
          className="buttonStyle"
          onClick={() => navigate("/Create")}
        >
          Create items, warehouses, and transactions
        </button>
        <button
          style={{ width: 350, height: 50 }}
          className="buttonStyleSecondary"
          onClick={() => navigate("/View")}
        >
          View items, warehouses, and transactions
        </button>
      </div>
    </div>
  );
}

export default HomeView;

import React from "react";
import "../Styles/HomeView.css";
import { useNavigate, Link } from "react-router-dom";
const ViewItems = () => {
  const navigate = useNavigate();

  return (
    <div className="center" style={{ margin: 55 }}>
      <h1>
        <Link to={"/"}>Home</Link>
      </h1>
      <div style={{ margin: 280 }}>
        <button
          style={{ width: 350, height: 50, margin: 10 }}
          className="buttonStyle"
          onClick={() => navigate("/View/InventoryItems")}
        >
          View, edit, and delete Inventory Items
        </button>
        <div></div>
        <button
          style={{ width: 350, height: 50, margin: 10 }}
          className="buttonStyle"
          onClick={() => navigate("/View/Warehouses")}
        >
          View, edit, and delete Warehouses
        </button>
        <div></div>
        <button
          style={{ width: 350, height: 50, margin: 10 }}
          className="buttonStyle"
          onClick={() => navigate("/View/Transactions")}
        >
          View, edit, and delete Transactions
        </button>
      </div>
    </div>
  );
};

export default ViewItems;

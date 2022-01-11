import React from "react";
import "../Styles/HomeView.css";
import { useNavigate, Link } from "react-router-dom";

const CreateView = () => {
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
          onClick={() => navigate("/Create/InventoryItem")}
        >
          Create an Inventory Item
        </button>
        <div></div>
        <button
          style={{ width: 350, height: 50, margin: 10 }}
          className="buttonStyle"
          onClick={() => navigate("/Create/Warehouse")}
        >
          Create a Warehouse
        </button>
        <div></div>
        <button
          style={{ width: 350, height: 50, margin: 10 }}
          className="buttonStyle"
          onClick={() => navigate("/Create/Transaction")}
        >
          Create a Transaction
        </button>
      </div>
    </div>
  );
};

export default CreateView;

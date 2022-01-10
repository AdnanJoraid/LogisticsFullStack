import React, { useState, useEffect } from "react";
import "../Styles/HomeView.css";
import Table from "react-bootstrap/Table";
import axios from "axios";
import { Link } from "react-router-dom";


const InventoryItemsView = () => {
  const [items, setItems] = useState([]);
  useEffect(() => {
    GetInventoryItems();
  });

  const GetInventoryItems = async () => {
    await axios("http://localhost:5000/api/inventory/items")
      .then((response) => {
        setItems(response.data);
      })
      .catch((error) => {
        console.error("Error fetching data: ", error);
      });
  };

  const DeleteInventoryItem = async (itemId) => {
    await axios
      .delete(`http://localhost:5000/api/inventory/${itemId}`, { data: itemId })
      .then((res) => console.log(res))
      .then(() => window.location.reload(false))
      .catch((error) => {
        console.log(error);
      });
  };
  return (
    <div className="center" style={{ margin: 25 }}>
      <Link to={"/"}>Home</Link>
      <h1>Inventory Items View</h1>
      <div style={{ margin: 25 }}>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>#</th>
              <th>ID</th>
              <th>Name</th>
              <th>Beginning QTY</th>
              <th>Price</th>
              <th>In-Stock</th>
              <th>Created At</th>
              <th>Edit</th>
              <th>Delete</th>
            </tr>
          </thead>
          <tbody>
            {items.map((item, idx) => (
              <tr key={item.id}>
                <td>{idx + 1}</td>
                <td>{item.id}</td>
                <td>{item.itemName}</td>
                <td>{item.beginningQuantity}</td>
                <td>{item.itemPrice}</td>
                <td>{String(item.isAvailable)}</td>
                <td>{item.dateOfCreation}</td>
                <td>
                  <Link to={{ pathname: `/EditInventory/${item.id}` }}>
                    Edit
                  </Link>
                </td>
                <td>
                  <td>
                    <button
                      style={{
                        color: "red",
                        borderColor: "white",
                        boxShadow: "white",
                      }}
                      onClick={() => {
                        DeleteInventoryItem(item.id);
                      }}
                    >
                      Delete
                    </button>
                  </td>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    </div>
  );
};

export default InventoryItemsView;

import React, { useState, useEffect } from "react";
import "../Styles/HomeView.css";
import Table from "react-bootstrap/Table";
import axios from "axios";
import { Link } from "react-router-dom";
const WarehousesView = () => {
  const [warehouses, setWarehouses] = useState([]);
  useEffect(() => {
    GetWarehouses();
  });

  const GetWarehouses = async () => {
    await axios("http://localhost:5000/api/warehouse/all")
      .then((response) => {
        setWarehouses(response.data);
      })
      .catch((error) => {
        console.error("Error fetching data: ", error);
      });
  };

  const DeleteWarehouse = async (warehouseId) => {
    await axios
      .delete(`http://localhost:5000/api/warehouse/${warehouseId}`, {
        data: warehouseId,
      })
      .then((res) => console.log(res))
      .then(() => window.location.reload(false))
      .catch((error) => {
        console.log(error);
      });
  };
  return (
    <div className="center" style={{ margin: 25 }}>
      <h1>Warehouses</h1>
      <div style={{ margin: 25 }}>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>#</th>
              <th>ID</th>
              <th>Name</th>
              <th>Address</th>
              <th>Edit</th>
              <th>Delete</th>
            </tr>
          </thead>
          <tbody>
            {warehouses.map((warehouse, idx) => (
              <tr key={warehouse.id}>
                <td>{idx + 1}</td>
                <td>{warehouse.id}</td>
                <td>{warehouse.name}</td>
                <td>{warehouse.address}</td>
                <td>
                  <Link to={{ pathname: `/EditWarehouse/${warehouse.id}` }}>
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
                        DeleteWarehouse(warehouse.id);
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

export default WarehousesView;

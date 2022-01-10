import React, { useState, useEffect } from "react";
import { useParams, useLocation, useNavigate } from "react-router-dom";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

import axios from "axios";
import "../Styles/HomeView.css";

const EditWarehouseView = () => {
  const [responseDone, setResponseDone] = useState(false);
  const { id } = useParams();
  const [oldWarehouse, setOldWarehouse] = useState({});
  const [updatedWarehouseName, setUpdatedWarehouseName] = useState(null);
  const [updatedWarehouseAddress, setUpdatedWarehouseAddress] = useState(null);
  let navigate = useNavigate();

  useEffect(() => {
    GetWarehouse().then(setResponseDone(true));
  }, [responseDone]);

  const GetWarehouse = async () => {
    await axios(`http://localhost:5000/api/warehouse/${id}`)
      .then((response) => {
        setOldWarehouse(response.data);
      })
      .catch((error) => {
        console.error("Error fetching data: ", error);
      });
  };

  const UpdateWarehouseItem = async () => {
    await axios({
      method: "put",
      url: `http://localhost:5000/api/warehouse/update/${id}`,
      data: {
        name: updatedWarehouseName ? updatedWarehouseName : oldWarehouse.name,
        address: updatedWarehouseAddress
          ? updatedWarehouseAddress
          : oldWarehouse.address,
      },
    })
      .then((res) => console.log(res))
      .then(navigate("/View/Warehouses"));
  };
  return (
    <div style={{ margin: 40 }} className="center">
      <h3>Update Warehouse with ID: {oldWarehouse.id}</h3>
      <Form className="center">
        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Warehouse Name</Form.Label>
          <Form.Control
            type="input"
            placeholder={oldWarehouse.name}
            onChange={(e) => {
              setUpdatedWarehouseName(e.target.value);
              console.log(e.target.value);
            }}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Warehouse Address</Form.Label>
          <Form.Control
            type="input"
            placeholder={oldWarehouse.address}
            onChange={(e) => {
              setUpdatedWarehouseAddress(e.target.value);
              console.log(e.target.value);
            }}
          />
        </Form.Group>
      </Form>
      <Button variant="primary" type="submit" onClick={UpdateWarehouseItem}>
        Update
      </Button>
    </div>
  );
};

export default EditWarehouseView;

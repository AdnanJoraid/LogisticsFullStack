import React, { useState } from "react";
import Form from "react-bootstrap/Form";
import axios from "axios";
import Button from "react-bootstrap/Button";
import { Link } from "react-router-dom";

const CreateWarehouseView = () => {
  const [warehouseName, setWarehouseName] = useState("");
  const [warehouseAddress, setWarehouseAddress] = useState("");

  const AddWarehouseToDatabase = async () => {
    await axios({
      method: "post",
      headers: { "Content-Type": "application/json" },
      url: `http://localhost:5000/api/warehouse/`,
      data: {
        name: warehouseName,
        address: warehouseAddress,
      },
    })
      .then((response) => console.log(response))
      .then(window.location.reload(false))
      .catch((err) => console.error(err));
  };

  return (
    <div style={{ margin: 40 }} className="center">
      <Link to={"/"}>Home</Link>

      <h3>Create Warehouse</h3>

      <Form className="center">
        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Warehouse Name</Form.Label>
          <Form.Control
            type="input"
            placeholder="Enter Warehouse Name"
            required
            onChange={(e) => setWarehouseName(e.target.value)}
          ></Form.Control>
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Warehouse Address</Form.Label>
          <Form.Control
            type="input"
            placeholder="Enter WarehouseAddress"
            required
            onChange={(e) => setWarehouseAddress(e.target.value)}
          ></Form.Control>
        </Form.Group>
      </Form>
      <Button variant="primary" type="submit" onClick={AddWarehouseToDatabase}>
        Add
      </Button>
    </div>
  );
};

export default CreateWarehouseView;

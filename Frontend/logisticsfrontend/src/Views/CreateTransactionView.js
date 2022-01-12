import React, { useState } from "react";
import Form from "react-bootstrap/Form";
import axios from "axios";
import Button from "react-bootstrap/Button";
import { Link } from "react-router-dom";

const CreateTransactionView = () => {
  const [inventoryId, setInventoryId] = useState("");
  const [warehouseId, setWarehouseId] = useState("");
  const [type, setType] = useState("");
  const [itemAisle, setItemAisle] = useState(0);
  const [itemShelf, setItemShelf] = useState(0);
  const [itemRack, setItemRack] = useState(0);
  const [itemBin, setItemBin] = useState(0);

  const AddTransactionToDatabase = async () => {
    await axios({
      method: "post",
      headers: { "Content-Type": "application/json" },
      url: `http://localhost:5000/api/Transaction/${inventoryId}/${warehouseId}/${type}`,
      data: {
        itemLocation: {
          aisle: itemAisle,
          rack: itemRack,
          shelf: itemShelf,
          bin: itemBin,
        },
      },
    })
      .then((response) => console.log(response))
      .then(window.location.reload(false))
      .catch((err) => console.error(err));
  };

  return (
    <div style={{ margin: 40 }} className="center">
      <Link to={"/"}>Home</Link>

      <h3>Create Transaction</h3>

      <Form className="center">
        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item ID</Form.Label>
          <Form.Control
            type="input"
            placeholder="Enter Inevntory Item ID"
            required
            onChange={(e) => setInventoryId(e.target.value)}
          ></Form.Control>
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Warehouse ID</Form.Label>
          <Form.Control
            type="input"
            placeholder="Enter Warehouse ID"
            required
            onChange={(e) => setWarehouseId(e.target.value)}
          ></Form.Control>
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Type. IN/OUT</Form.Label>
          <Form.Control
            type="input"
            placeholder="Enter Type"
            required
            onChange={(e) => setType(e.target.value)}
          ></Form.Control>
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Location - Aisle</Form.Label>
          <Form.Control
            type="number"
            placeholder="Enter Inevntory Item Location - Aisle"
            required
            onChange={(e) => setItemAisle(e.target.value)}
          ></Form.Control>
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Location - Rack</Form.Label>
          <Form.Control
            type="number"
            placeholder="Enter Inevntory Item Location - Rack"
            required
            onChange={(e) => setItemRack(e.target.value)}
          ></Form.Control>
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Location - Shelf</Form.Label>
          <Form.Control
            type="number"
            placeholder="Enter Inevntory Item Location - Shelf"
            required
            onChange={(e) => setItemShelf(e.target.value)}
          ></Form.Control>
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Location - Bin</Form.Label>
          <Form.Control
            type="number"
            placeholder="Enter Inevntory Item Location - Bin"
            required
            onChange={(e) => setItemBin(e.target.value)}
          ></Form.Control>
        </Form.Group>
      </Form>
      <Button
        variant="primary"
        type="submit"
        onClick={AddTransactionToDatabase}
      >
        Add
      </Button>
    </div>
  );
};
export default CreateTransactionView;

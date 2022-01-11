import React, { useState } from "react";
import Form from "react-bootstrap/Form";
import axios from "axios";
import Button from "react-bootstrap/Button";
import { Link } from "react-router-dom";

const CreateInventoryItemView = () => {
  const [itemName, setItemName] = useState("");
  const [itemDescription, setItemDescription] = useState("");
  const [itemBeginningQuantity, setItemBeginningQuantity] = useState(0);
  const [itemPrice, setItemPrice] = useState(0);

  const AddInventoryItemToDatabase = async () => {
    await axios({
      method: "post",
      headers: { "Content-Type": "application/json" },
      url: `http://localhost:5000/api/inventory`,
      data: {
        itemName: itemName,
        description: itemDescription,
        beginningQuantity: itemBeginningQuantity,
        itemPrice: itemPrice,
      },
    })
      .then((response) => console.log(response))
      .then(window.location.reload(false))
      .catch((err) => console.error(err));
  };

  return (
    <div style={{ margin: 40 }} className="center">
      <Link to={"/"}>Home</Link>

      <h3>Create Inventory Item</h3>

      <Form className="center">
        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Name</Form.Label>
          <Form.Control
            type="input"
            placeholder="Enter Item Name"
            required
            onChange={(e) => setItemName(e.target.value)}
          ></Form.Control>
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Description</Form.Label>
          <Form.Control
            type="input"
            placeholder="Enter Item Description"
            required
            onChange={(e) => setItemDescription(e.target.value)}
          ></Form.Control>
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Beginning Quantity</Form.Label>
          <Form.Control
            type="number"
            placeholder="Enter Beginning Quantity"
            required
            onChange={(e) => setItemBeginningQuantity(e.target.value)}
          ></Form.Control>
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Price</Form.Label>
          <Form.Control
            type="number"
            placeholder="Enter Inevntory Item Price"
            required
            onChange={(e) => setItemPrice(e.target.value)}
          ></Form.Control>
        </Form.Group>
      </Form>
      <Button
        variant="primary"
        type="submit"
        onClick={AddInventoryItemToDatabase}
      >
        Add
      </Button>
    </div>
  );
};

export default CreateInventoryItemView;

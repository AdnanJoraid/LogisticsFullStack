import React, { useState, useEffect } from "react";
import { useParams, useLocation, useNavigate } from "react-router-dom";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

import axios from "axios";
import "../Styles/HomeView.css";
const EditInventoryView = () => {
  const [responseDone, setResponseDone] = useState(false);
  const { id } = useParams();
  const [oldItem, setOldItem] = useState({});
  const [updatedItemName, setUpdatedItemName] = useState(null);
  const [updatedItemDescription, setUpdatedItemDescription] = useState(null);
  const [updatedItemPrice, setUpdatedItemPrice] = useState(0);
  let navigate = useNavigate();

  useEffect(() => {
    GetInventoryItems().then(setResponseDone(true));
  }, [responseDone]);

  console.log(oldItem);

  const GetInventoryItems = async () => {
    await axios(`http://localhost:5000/api/inventory/${id}`)
      .then((response) => {
        setOldItem(response.data);
      })
      .catch((error) => {
        console.error("Error fetching data: ", error);
      });
  };

  const UpdateInventoryItem = async () => {
    if (!updatedItemPrice) setUpdatedItemPrice(oldItem.itemPrice);

    if (!updatedItemDescription) setUpdatedItemDescription(oldItem.description);

    if (!updatedItemName) setUpdatedItemName(oldItem.itemName);
    await axios({
      method: "put",
      url: `http://localhost:5000/api/inventory/update/item/${id}`,
      data: {
        itemName: updatedItemName ? updatedItemName : oldItem.itemName,
        description: updatedItemDescription
          ? updatedItemDescription
          : oldItem.description,
        itemPrice: updatedItemPrice ? updatedItemPrice : oldItem.itemPrice,
        beginningQuantity: oldItem.beginningQuantity,
      },
    })
      .then((res) => console.log(res))
      .then(navigate("/View/InventoryItems"));
  };
  return (
    <div style={{ margin: 40 }} className="center">
      <h3>Update Inventory Item with ID: {oldItem.id}</h3>
      <Form className="center">
        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Name</Form.Label>
          <Form.Control
            type="input"
            placeholder={oldItem.itemName}
            onChange={(e) => {
              setUpdatedItemName(e.target.value);
              console.log(e.target.value);
            }}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Description</Form.Label>
          <Form.Control
            type="input"
            placeholder={oldItem.description}
            onChange={(e) => {
              setUpdatedItemDescription(e.target.value);
              console.log(e.target.value);
            }}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Price</Form.Label>
          <Form.Control
            type="input"
            placeholder={oldItem.itemPrice}
            onChange={(e) => {
              setUpdatedItemPrice(e.target.value);
              console.log(e.target.value);
            }}
          />
        </Form.Group>
      </Form>
      <Button variant="primary" type="submit" onClick={UpdateInventoryItem}>
        Update
      </Button>
    </div>
  );
};

export default EditInventoryView;

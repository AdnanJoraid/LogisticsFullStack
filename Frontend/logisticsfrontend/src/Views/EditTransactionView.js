import React, { useState, useEffect } from "react";
import { useParams, useLocation, useNavigate } from "react-router-dom";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

import axios from "axios";
import "../Styles/HomeView.css";

const EditTransactionView = () => {
  const [responseDone, setResponseDone] = useState(false);
  const { id } = useParams();
  const [oldTransaction, setOldTransaction] = useState({});
  const [updatedTransactionType, setUpdatedTransactionType] = useState();
  const [updatedTransactionItemAisle, setUpdatedTransactionItemAisle] =
    useState();
  const [updatedTransactionItemShelf, setUpdatedTransactionItemShelf] =
    useState();
  const [updatedTransactionItemRack, setUpdatedTransactionItemRack] =
    useState();
  const [updatedTransactionItemBin, setUpdatedTransactionItemBin] = useState();
  let navigate = useNavigate();

  useEffect(() => {
    GetTransction().then(setResponseDone(true));
  }, [responseDone]);

  console.log(oldTransaction);

  const GetTransction = async () => {
    await axios(`http://localhost:5000/api/Transaction/${id}`)
      .then((response) => {
        setOldTransaction(response.data);
        console.log(response);
        return response;
      })
      .then(console.log(oldTransaction))
      .catch((error) => {
        console.error("Error fetching data: ", error);
      });
  };

  const UpdateTransaction = async () => {
    await axios({
      method: "put",
      url: `http://localhost:5000/api/Transaction/update/${id}`,
      data: {
        inventoryItem: oldTransaction.inventoryItem,
        warehouse: oldTransaction.warehouse,
        itemLocation: {
          aisle: updatedTransactionItemAisle
            ? updatedTransactionItemAisle
            : oldTransaction.itemLocation.aisle,
          shelf: updatedTransactionItemShelf
            ? updatedTransactionItemShelf
            : oldTransaction.itemLocation.shelf,
          rack: updatedTransactionItemRack
            ? updatedTransactionItemRack
            : oldTransaction.itemLocation.rack,
          bin: updatedTransactionItemBin
            ? updatedTransactionItemBin
            : oldTransaction.itemLocation.bin,
        },
        type: updatedTransactionType
          ? parseInt(updatedTransactionType)
          : oldTransaction.type,
      },
    })
      .then((res) => console.log(res))
      .then(navigate("/View/Transactions"));
  };
  return (
    <div style={{ margin: 40 }} className="center">
      <h3>Update Transaction with ID: {oldTransaction.id}</h3>
      <Form className="center">
        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Transaction Type. 0 for IN, 1 for OUT</Form.Label>
          <Form.Control
            type="number"
            placeholder={oldTransaction.type}
            onChange={(e) => {
              setUpdatedTransactionType(e.target.value);
              console.log(e.target.value);
            }}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Location - Aisle</Form.Label>
          <Form.Control
            type="input"
            placeholder={oldTransaction.itemLocation?.aisle}
            onChange={(e) => {
              setUpdatedTransactionItemAisle(e.target.value);
              console.log(e.target.value);
            }}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Location - Rack</Form.Label>
          <Form.Control
            type="number"
            placeholder={oldTransaction.itemLocation?.rack}
            onChange={(e) => {
              setUpdatedTransactionItemRack(e.target.value);
              console.log(e.target.value);
            }}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Location - Shelf</Form.Label>
          <Form.Control
            type="number"
            placeholder={oldTransaction.itemLocation?.shelf}
            onChange={(e) => {
              setUpdatedTransactionItemShelf(e.target.value);
              console.log(e.target.value);
            }}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="{exampleForm.ControlInput1}">
          <Form.Label>Inventory Item Location - Bin</Form.Label>
          <Form.Control
            type="number"
            placeholder={oldTransaction.itemLocation?.bin}
            onChange={(e) => {
              setUpdatedTransactionItemBin(e.target.value);
              console.log(e.target.value);
            }}
          />
        </Form.Group>
      </Form>
      <Button variant="primary" type="submit" onClick={UpdateTransaction}>
        Update
      </Button>
    </div>
  );
};

export default EditTransactionView;

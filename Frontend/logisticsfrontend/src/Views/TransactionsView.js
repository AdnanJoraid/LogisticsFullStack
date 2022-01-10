import React, { useState, useEffect } from "react";
import "../Styles/HomeView.css";
import Table from "react-bootstrap/Table";
import axios from "axios";
import { Link } from "react-router-dom";

const TransactionsView = () => {
  const [transactions, setTransactions] = useState([]);
  useEffect(() => {
    GetTransctions();
  });

  const GetTransctions = async () => {
    await axios("http://localhost:5000/api/Transaction/")
      .then((response) => {
        setTransactions(response.data);
      })
      .catch((error) => {
        console.error("Error fetching data: ", error);
      });
  };

  const DeleteTransaction = async (transactionId) => {
    await axios
      .delete(`http://localhost:5000/api/Transaction/delete/${transactionId}`, {
        data: transactionId,
      })
      .then((res) => console.log(res))
      .then(() => window.location.reload(false))
      .catch((error) => {
        console.log(error);
      });
  };
  return (
    <div className="center" style={{ margin: 25 }}>
      <h1>Transactions</h1>
      <div style={{ margin: 25 }}>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>#</th>
              <th>Transaction ID</th>
              <th>Inventory Item ID</th>
              <th>Inventory Item Name</th>
              <th>Warehouse ID</th>
              <th>Warehouse Name</th>
              <th>Type IN/OUT</th>
              <th>Inventory Item Location. Asile-Rack-Shelf-Bin</th>
              <th>Issued At</th>
              <th>Edit</th>
              <th>Delete</th>
            </tr>
          </thead>
          <tbody>
            {transactions.map((transaction, idx) => (
              <tr key={transaction.id}>
                <td>{idx + 1}</td>
                <td>{transaction.id}</td>
                <td>{transaction.inventoryItem.id}</td>
                <td>{transaction.inventoryItem.itemName}</td>
                <td>{transaction.warehouse.id}</td>
                <td>{transaction.warehouse.name}</td>
                <td>{transaction.typeString}</td>
                <td>{transaction.formattedLocation}</td>
                <td>{transaction.createdDate}</td>
                <td>
                  <Link to={{ pathname: `/EditTransaction/${transaction.id}` }}>
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
                        DeleteTransaction(transaction.id);
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

export default TransactionsView;

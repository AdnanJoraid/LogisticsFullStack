# LogisticsAPI-ShopifyBackend-2022
Hey! My name is Adnan Joraid, and this is my submission for the Shopify backend developer intern (summer 2022) challenge. This readme will contain detailed information on the installations required and an overview of technologies used, which type of feature I chose to implement, and finally, a demo of the working application. 

## Table of Contents
- [Technologies](#technologies)
- [Installation and Running the Application](#installation-and-running-the-application)
  - [Backend](#backend)
  - [Frontend](#frontend)
- [API Endpoints Examples and how to use](#api-endpoints-examples-and-how-to-use)
  - [Inventory Controller API endpoints](#inventory-controller-api-endpoints)
  - [Warehouse Controller API endpoints](#warehouse-controller-api-endpoints)
  - [Transaction Controller API endpoints](#transaction-controller-api-endpoints)
- [Demo](#demo)

# Technologies
LogisticsAPI is an extensive REST API back-end built with C#, SQLite database, and ASP.NET framework that implements an inventory tracking web application for a logistics company. The back-end supports basic CRUD functionality for creating inventory items, warehouses, and inventory transactions. The back-end provides a high-quality code with input validation, try-catch statements to handle unexpected exceptions, and different HTTP status codes returned with the response to provide confirmation or error messages. Although this is a back-end specific challenge, I implemented a frontend using React allowing users to add items, warehouses, and transactions. Moreover, the user is also able to view all the items, warehouses and transactions through the frontend.



# Installation and Running the Application
Backend:
- Language used: C# 
- Database: SQLite 
- Framework: ASP.NET 
- IDE: Visual Studio Code

Frontend:
- React, JavaScript, and HTML/CSS
  
To run the backend after installation:
1. cd backend 
2. dotnet run 

To run Frontend:
1. cd frontend 
2. cd logisticsfrontend
3. npm start

## Backend
1. Download .NET 5.0 SDK from here https://dotnet.microsoft.com/en-us/download/dotnet
2. Download VSCode from here https://code.visualstudio.com/download 
3. Download Git from here https://git-scm.com/download/
4. Test if dotnet is downloaded correctly by:
	- Go to the terminal 
	- Write dotnet --version
5. Open a new terminal and clone the repo using this link: https://github.com/AdnanJoraid/LogisticsAPI-ShopifyBackend-2022
6. Open any IDE of your choice 
7. (VSCode-Specfic step): If you open the code using VSCode, at the bottom right you might get a pop-up that says "required assets to build and debug are missing". choose the "yes" option for that. 
8. open the terminal and navigate to the backend directory: cd backend 
9. run the command: dotnet run

## Frontend
1. Install Node.js from here https://nodejs.org/en/download/ 
2. To verify installation, write: node -v in the terminal. Also try running: npm --version 
3. open a new terminal and navigate to the project 
4. This time navigate to the frontend folder: cd frontend 
5. Navigate to the react project: cd logisticsfrontend
6. write in the terminal" npm install 
7. Type in the terminal: npm start
8. (In case of error in previous step) write this command in the terminal npm install react-scripts --save
9. If everything worked, the server will be here -> http://localhost:3000/ 


# API Endpoints Examples and how to use
## Inventory Controller API endpoints
POST - http://localhost:5000/api/inventory : Adds an inventory item to the SQLite database.
Example: Request Body:
```json
{
    "ItemName" : "RTX 3070", 
    "Description" : "RTX 3070 is a high-end graphics card by NVIDIA, launched on September 1st, 2020. Built on the 8 nm process, and based on the GA104 graphics processor, in its GA104-300-A1 variant, the card supports DirectX 12 Ultimate.",
    "beginningQuantity" : 43, 
    "ItemPrice" : 679.99
}
```
Resposne: The item RTX 3070 has been added to the database. </br>

POST - http://localhost:5000/api/inventory/items/add : Adds a list of inventory items objects to the database. 
Example: Request Body:
```json
[{
  "ItemName": "Jello - Assorted",
  "Description": "Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.\n\nVestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.",
  "QuantityStock": 46,
  "ItemPrice": 9.64
}, {
  "ItemName": "Sambuca - Ramazzotti",
  "Description": "In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.\n\nMaecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.",
  "QuantityStock": 36,
  "ItemPrice": 9.23
}]
```
Response: List of items has been added to the database. </br>

GET - http://localhost:5000/api/inventory/{id} : Retrieves an inventory item with a given ID. 
</br>
Example:
http://localhost:5000/api/inventory/81b291b7-eb3a-458c-b5b5-43fee992d8f5
</br>
response:

```json
{
  "id": "81b291b7-eb3a-458c-b5b5-43fee992d8f5",
  "itemName": "RTX 3070",
  "description": "RTX 3070 is a high-end graphics card by NVIDIA, launched on September 1st, 2020. Built on the 8 nm process, and based on the GA104 graphics processor, in its GA104-300-A1 variant, the card supports DirectX 12 Ultimate.",
  "beginningQuantity": 43,
  "isAvailable": true,
  "itemPrice": 679.99,
  "dateOfCreation": "2022-01-11T15:41:04.3154171"
}
```

GET - http://localhost:5000/api/inventory/items/ : Retrieves all the inventory items in the database. 
Example: </br>
Response:
```json
{
  "ItemName": "Jello - Assorted",
  "Description": "Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.\n\nVestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.",
  "QuantityStock": 46,
  "ItemPrice": 9.64
}, {
  "ItemName": "Sambuca - Ramazzotti",
  "Description": "In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.\n\nMaecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.",
  "QuantityStock": 36,
  "ItemPrice": 9.23
}
```

PUT  - http://localhost:5000/api/inventory/update/item/{id} : Updates an inventroy item's data with an updated inventory item passed alongside the ID of the old inventroy item. </br>
Example: </br>
Request: http://localhost:5000/api/inventory/update/item/81b291b7-eb3a-458c-b5b5-43fee992d8f5 </br>
Body:

```json
{
  "id": "81b291b7-eb3a-458c-b5b5-43fee992d8f5",
  "itemName": "RTX 3060",
  "description": "RTX 3070 is a high-end graphics card by NVIDIA, launched on September 1st, 2020. Built on the 8 nm process, and based on the GA104 graphics processor, in its GA104-300-A1 variant, the card supports DirectX 12 Ultimate.",
  "beginningQuantity": 43,
  "isAvailable": true,
  "itemPrice": 679.99,
  "dateOfCreation": "2022-01-11T15:41:04.3154171"
}
```
Response: The item with the id 81b291b7-eb3a-458c-b5b5-43fee992d8f5 has been updated.


DELETE - http://localhost:5000/api/inventory/{id} : Deletes an inventory item with a given ID. </br>

Example:  http://localhost:5000/api/inventory/81b291b7-eb3a-458c-b5b5-43fee992d8f5 <br>
Response: Item with ID 81b291b7-eb3a-458c-b5b5-43fee992d8f5 has been deleted

## Warehouse Controller API endpoints

POST - http://localhost:5000/api/warehouse : Adds a warehouse item to the SQLite database.


Example -> Body:

```json
{
    "Name" : "Amazon", 
    "Address" : "Amazon Canada Fulfillment Services, Inc., 6363 Millcreek Dr, Mississauga, ON L5N 1L8"
}
```
Response: Warehouse has been added to the database. The warehouse ID is 1f40dcdf-7072-46ab-8688-03c11f111e35


GET  - http://localhost:5000/api/warehouse/{id} : Retrieves a warehouse with a given ID. 


Example: GET - http://localhost:5000/api/warehouse/5c3d9a61-2e25-4324-9319-add5c130083e

Response:
```json
{
    "Name" : "Amazon", 
    "Address" : "Amazon Canada Fulfillment Services, Inc., 6363 Millcreek Dr, Mississauga, ON L5N 1L8"
}
```

GET  - http://localhost:5000/api/warehouse/all/ : Retrieves all the warehouses in the database. 

Response:

```json 
[
  {
    "id": "5c3d9a61-2e25-4324-9319-add5c130083e",
    "name": "Amazon",
    "address": "Amazon Canada Fulfillment Services, Inc., 6363 Millcreek Dr, Mississauga, ON L5N 1L8"
  },
  {
    "id": "1f40dcdf-7072-46ab-8688-03c11f111e35",
    "name": "Amazon Canada",
    "address": "Amazon Canada Fulfillment Services, Inc., 6363 Millcreek Dr, Mississauga, ON L5N 1L8"
  }
]
```

PUT  - http://localhost:5000/api/warehouse/update/{id} : Updates a warehouse data with an updated warehouse passed alongside the ID of the old warehouse.

Example: PUT - http://localhost:5000/api/warehouse/update/1f40dcdf-7072-46ab-8688-03c11f111e35 

Body: 

```json
{
  "name": "Amazon Brampton",
  "address": "8050 Heritage Rd, Brampton, ON L6Y 0C9"
}
```

response: The warehouse with the ID 1f40dcdf-7072-46ab-8688-03c11f111e35 has been updated


DELETE - http://localhost:5000/api/warehouse/{id} : Deletes a warehouse with a given ID. 

Example: DELETE - http://localhost:5000/api/warehouse/1f40dcdf-7072-46ab-8688-03c11f111e35 

Response: The warehouse with the ID 1f40dcdf-7072-46ab-8688-03c11f111e35 has been deleted.


## Transaction Controller API endpoints
POST -   http://localhost:5000/api/transaction/{inventoryId}/{warehouseId}/{type} : Adds a transaction item to the SQLite database in addition to the warehouse and item associated with it.

Example:POST- http://localhost:5000/api/transaction/2422b392-e1b1-4664-95da-4a58684dc184/5c3d9a61-2e25-4324-9319-add5c130083e/out

Body: 

```json
{
    "ItemLocation": {
        "Aisle" : 1, 
        "Rack": 4, 
        "Shelf" : 2, 
        "Bin" : 4
    }
}
```

Response: Transaction with the ID 0d09babe-cd40-471e-8b85-ba954bdf510b has been issued on 2022-01-11 6:37:09 PM


GET  -   http://localhost:5000/api/transaction/{id} : Retrieves a transaction with a given ID. 

Example: http://localhost:5000/api/transaction/0d09babe-cd40-471e-8b85-ba954bdf510b

Response: 

```json 
{
  "id": "0d09babe-cd40-471e-8b85-ba954bdf510b",
  "inventoryItem": {
    "id": "2422b392-e1b1-4664-95da-4a58684dc184",
    "itemName": "PlayStation 5 Digital Edition Console",
    "description": "Advanced gaming is easier than ever thanks to this PlayStation 5 Digital Edition console with Astro's Playroom. Designed without a disc drive, it allows you to log into your PlayStation account to instantly purchase and download your favourite games. It's equipped with impressive technologies like the haptic feedback support and 3D audio for an immersive experience.",
    "beginningQuantity": 533,
    "isAvailable": true,
    "itemPrice": 499.99,
    "dateOfCreation": "2022-01-11T15:48:57.2611517"
  },
  "warehouse": {
    "id": "5c3d9a61-2e25-4324-9319-add5c130083e",
    "name": "Amazon",
    "address": "Amazon Canada Fulfillment Services, Inc., 6363 Millcreek Dr, Mississauga, ON L5N 1L8"
  },
  "typeString": "out",
  "type": 0,
  "itemLocation": {
    "id": "37c8f4d5-5e72-4a0d-ace5-2ac1e491f320",
    "aisle": 1,
    "rack": 4,
    "shelf": 2,
    "bin": 4
  },
  "formattedLocation": "01-04-02-4",
  "createdDate": "2022-01-11T18:37:09.6583447"
}
```
GET  -   http://localhost:5000/api/transaction/ : Retrieves all the transactions in the database. 

Example -> Response

```json
[{
    "id": "01dec629-b852-41a9-982e-cedac5a0ac84",
    "inventoryItem": {
      "id": "883e81db-5749-466d-ac49-fc9630b41024",
      "itemName": "One Piece.",
      "description": "As a child, Monkey D. Luffy was inspired to become a pirate by listening to the tales of the buccaneer 'Red-Haired' Shanks. But his life changed when Luffy accidentally ate the Gum-Gum Devil Fruit and gained the power to stretch like rubber ... at the cost of never being able to swim again! Years later, still vowing to become the king of the pirates, Luffy sets out on his adventure ... one guy alone in a rowboat, in search of the legendary 'One Piece', said to be the greatest treasure in the world",
      "beginningQuantity": 43,
      "isAvailable": true,
      "itemPrice": 12.99,
      "dateOfCreation": "2022-01-09T22:07:35.469209"
    },
    "warehouse": {
      "id": "5c3d9a61-2e25-4324-9319-add5c130083e",
      "name": "Amazon",
      "address": "Amazon Canada Fulfillment Services, Inc., 6363 Millcreek Dr, Mississauga, ON L5N 1L8"
    },
    "typeString": "IN",
    "type": 0,
    "itemLocation": {
      "id": "0683d6e4-8356-4df6-a39a-ae2297440143",
      "aisle": 1,
      "rack": 4,
      "shelf": 2,
      "bin": 4
    },
    "formattedLocation": "01-04-02-4",
    "createdDate": "2022-01-11T18:34:13.8239739"
  },
  {
    "id": "0d09babe-cd40-471e-8b85-ba954bdf510b",
    "inventoryItem": {
      "id": "2422b392-e1b1-4664-95da-4a58684dc184",
      "itemName": "PlayStation 5 Digital Edition Console",
      "description": "Advanced gaming is easier than ever thanks to this PlayStation 5 Digital Edition console with Astro's Playroom. Designed without a disc drive, it allows you to log into your PlayStation account to instantly purchase and download your favourite games. It's equipped with impressive technologies like the haptic feedback support and 3D audio for an immersive experience.",
      "beginningQuantity": 533,
      "isAvailable": true,
      "itemPrice": 499.99,
      "dateOfCreation": "2022-01-11T15:48:57.2611517"
    },
    "warehouse": {
      "id": "5c3d9a61-2e25-4324-9319-add5c130083e",
      "name": "Amazon",
      "address": "Amazon Canada Fulfillment Services, Inc., 6363 Millcreek Dr, Mississauga, ON L5N 1L8"
    },
    "typeString": "out",
    "type": 0,
    "itemLocation": {
      "id": "37c8f4d5-5e72-4a0d-ace5-2ac1e491f320",
      "aisle": 1,
      "rack": 4,
      "shelf": 2,
      "bin": 4
    },
    "formattedLocation": "01-04-02-4",
    "createdDate": "2022-01-11T18:37:09.6583447"
  }
]
```
PUT  -   http://localhost:5000/api/transaction/update/{id} : Updates a transaction data with an updated transaction passed alongside the ID of the old transaction.

Example -> http://localhost:5000/api/transaction/update/0d09babe-cd40-471e-8b85-ba954bdf510b

Request body:

```json
{
  "id": "0d09babe-cd40-471e-8b85-ba954bdf510b",
  "inventoryItem": {
    "id": "2422b392-e1b1-4664-95da-4a58684dc184",
    "itemName": "PlayStation 5 Digital Edition Console",
    "description": "Advanced gaming is easier than ever thanks to this PlayStation 5 Digital Edition console with Astro's Playroom. Designed without a disc drive, it allows you to log into your PlayStation account to instantly purchase and download your favourite games. It's equipped with impressive technologies like the haptic feedback support and 3D audio for an immersive experience.",
    "beginningQuantity": 533,
    "isAvailable": true,
    "itemPrice": 499.99,
    "dateOfCreation": "2022-01-11T15:48:57.2611517"
  },
  "warehouse": {
    "id": "5c3d9a61-2e25-4324-9319-add5c130083e",
    "name": "Amazon",
    "address": "Amazon Canada Fulfillment Services, Inc., 6363 Millcreek Dr, Mississauga, ON L5N 1L8"
  },
  "type": 0,
  "itemLocation": {
    "id": "37c8f4d5-5e72-4a0d-ace5-2ac1e491f320",
    "aisle": 2,
    "rack": 2,
    "shelf": 2,
    "bin": 2
  }
}

```

Response: The transaction with the ID 0d09babe-cd40-471e-8b85-ba954bdf510b has been updated 


DELETE - http://localhost:5000/api/transaction/delete/{id} : Deletes a transaction with a given ID. 

Example: DELETE -  http://localhost:5000/api/Transaction/delete/0d09babe-cd40-471e-8b85-ba954bdf510b

Response: The transaction with the ID 0d09babe-cd40-471e-8b85-ba954bdf510b has been deleted.


# Demo



https://user-images.githubusercontent.com/59744727/149042771-55de46ce-4c6b-4acd-8122-34c3a131236f.mp4



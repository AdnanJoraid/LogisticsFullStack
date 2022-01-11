# LogisticsAPI-ShopifyBackend-2022
Hey! My name is Adnan Joraid and this is my try for Shopify backend developer intern (summer 2022) challenge. This readme will contain a detailed information on the installations required and an overview of teachnologies used, which type of feature I chose to implement, and finally a demo of the working application. 
- [LogisticsAPI-ShopifyBackend-2022](#logisticsapi-shopifybackend-2022)
- [Technologies](#technologies)
- [Installation and Running](#installation-and-running)
  - [Backend](#backend)
  - [Frontend](#frontend)
- [API Endpoints and Examples](#api-endpoints-and-examples)
    - [Inventory Controller API endpoints </br>](#inventory-controller-api-endpoints-br)
- [Demo](#demo)

# Technologies
LogisticsAPI is an extensive REST API back-end built with C#, SQLite database, and ASP.NET framework that implements an inventory tracking web application for a logistics company. The back-end supports basic CRUD functionality for creating inventory items, warehouses, and inventory transactions. The back-end provides a high quality code with input validation, try-catch statements to handle unexpected exeptions, and different HTTP status code returned with the response to provide a clear confirmation and/or error messages. Although this is a back-end specific challenge, I implemented a frontend using React that allow users to add items, warehouses, and transactions. Moreover, the user is also able to view all th items, warehouses and transactions through the frontend using React-Bootstrap tables. 



# Installation and Running
Backend:
- Language used: C# 
- Database: SQLite 
- Framework: ASP.NET 
- IDE: Visual Studio Code

Frontend:
- React
  
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
3. Test if dotnet is downloaded correctly by:
	- Go to the terminal 
	- Write dotnet --version
4. Open a new terminal and clone the repo using this link: https://github.com/AdnanJoraid/LogisticsAPI-ShopifyBackend-2022
5. Open any IDE of your choice 
6. (VSCode-Specfic step): If you open the code using VSCode, at the bottom right you will get a pop-up that says "required assets to build and debug are missing". choose the "yes" option for that. 
7. open the terminal and navigate to the backend directory: cd backend 
8. run the command: dotnet run
9. If everything worked, the server will be here ->  http://localhost:5000/ 

## Frontend
1. Install Node.js from here https://nodejs.org/en/download/ 
2. To verify installation, write: node -v in the terminal. Also try running: npm -v 
3. open a new terminal and navigate to the project 
4. This time navigate to the frontend folder: cd frontend 
5. Navigate to the react project: cd logisticsfrontend
6. Type in the terminal: npm start
7. If everything worked, the server will be here -> http://localhost:3000/ 


# API Endpoints and Examples
### Inventory Controller API endpoints </br>
POST - http://localhost:5000/api/inventory : Adds an inventory item to the SQLite database.
Example: Request:
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
Example: Request:
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


# Demo

# LogisticsAPI-ShopifyBackend-2022
Hey! My name is Adnan Joraid and this is my try for Shopify backend developer intern (summer 2022) challenge. This readme will contain a detailed information on the installations required and an overview of teachnologies used, which type of feature I chose to implement, and finally a demo of the working application. 
- [LogisticsAPI-ShopifyBackend-2022](#logisticsapi-shopifybackend-2022)
- [Technologies](#technologies)
- [Installation](#installation)
  - [Backend](#backend)
  - [Frontend](#frontend)
- [Classes](#classes)
- [API Endpoints and Examples](#api-endpoints-and-examples)
- [Demo](#demo)

# Technologies
LogisticsAPI is an extensive REST API back-end built with C#, SQLite database, and ASP.NET framework that implements an inventory tracking web application for a logistics company. The back-end supports basic CRUD functionality for creating inventory items, warehouses, and inventory transactions. The back-end provides a high quality code with input validation, try-catch statements to handle unexpected exeptions, and different HTTP status code returned with the response to provide a clear confirmation and/or error messages. Although this is a back-end specific challenge, I implemented a frontend using React that allow users to add items, warehouses, and transactions. Moreover, the user is also able to view all th items, warehouses and transactions through the frontend using React-Bootstrap tables. 

***

# Installation
Backend:
    -Language used: C# 
    -Database: SQLite 
    -Framework: ASP.NET 
    -IDE: Visual Studio Code 
Frontend:
    -React

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

***
# Classes

# API Endpoints and Examples

# Demo

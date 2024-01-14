# Stock Market Application
This is a sample application that implements a stock market system using Domain-Driven Design (DDD), Clean Architecture, SignalR, and a background service. The application consists of two main screens: the Market Screen and the Order Screen.

# Market Screen
The Market Screen displays the list of stocks currently in the market. The prices of these stocks change every 10 seconds, and they are accessible to other parts of the system. Prices are randomly generated in the range from 1 to 100.

# Technologies Used
ASP.NET Core
Domain-Driven Design (DDD)
Clean Architecture
SignalR for real-time communication
Background service to update stock prices every 10 seconds
# Entities
# Stock
Name: String
ID: Integer
Price: Integer (randomly generated in the range from 1 to 100)
Order Screen
The Order Screen displays a list of all orders made in the system. Each order includes information such as person name, stock name, price, and quantity. Users can create orders directly from this screen, and new orders will be updated in the order list.

# Entities
# Order
StockID: Integer
Price: Decimal
Quantity: Integer
Person Name: String
Technologies Used
ASP.NET Core
Domain-Driven Design (DDD)
Clean Architecture
SignalR for real-time communication
# How to Run the Application
Clone this repository:


git clone https://github.com/mostafaAli122/StockMarket.git
cd stock-market-app
# Run the backend (ASP.NET Core):

Navigate to the StockMarket.WebApi directory:


cd StockMarket.WebApi
Run the ASP.NET Core application:


dotnet run
# Run the frontend (Angular):

Navigate to the StockMarket.WebUI directory:


cd StockMarket.WebUI
# Install dependencies:


npm install
# Run the Angular application:


ng serve
# Open your browser and navigate to http://localhost:4200 to access the Stock Market Application.
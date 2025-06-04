# Order Management API

This API is a .NET migration of SQL stored procedures for managing customer orders. It provides RESTful endpoints to perform the same operations that were previously handled by stored procedures.

## Migrated Stored Procedures

1. **GetOrdersByCustomerEmail** → `GET /api/orders/customer/{email}`
2. **InsertOrder** → `POST /api/orders`
3. **DeleteOrderById** → `DELETE /api/orders/{id}`
4. **GetAllOrders** → `GET /api/orders`

## Database Schema

The API works with a normalized database schema consisting of:
- **Customers**: Customer information
- **Products**: Product catalog
- **Orders**: Order headers
- **OrderItems**: Order line items

## Configuration

Update the connection string in `appsettings.json` to match your MySQL database configuration.

## Running the API

1. Ensure your MySQL database is running
2. Update the connection string in `appsettings.json`
3. Run `dotnet build` to build the project
4. Run `dotnet run` to start the API
5. Navigate to the root URL to access Swagger UI

## API Endpoints

- **GET /api/orders**: Get all orders
- **GET /api/orders/customer/{email}**: Get orders by customer email
- **POST /api/orders**: Create a new order
- **DELETE /api/orders/{id}**: Delete an order by ID

All endpoints are documented in the Swagger UI interface.

CREATE TABLE CustomerOrders (
    OrderID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerName VARCHAR(100),
    CustomerEmail VARCHAR(100),
    ProductName VARCHAR(100),
    Quantity INT,
    OrderDate DATETIME
);
 
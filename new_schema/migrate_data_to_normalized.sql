
-- Insert unique customers
INSERT INTO Customers (Name, Email)
SELECT DISTINCT CustomerName, CustomerEmail
FROM OldStore.CustomerOrders;
 
-- Insert unique products
INSERT INTO Products (ProductName)
SELECT DISTINCT ProductName
FROM OldStore.CustomerOrders;

-- Insert orders
INSERT INTO Orders (OrderID, CustomerID, OrderDate)
SELECT 
    o.OrderID,
    c.CustomerID,
    o.OrderDate
FROM OldStore.CustomerOrders o
JOIN Customers c ON o.CustomerEmail = c.Email;

-- Insert order items
INSERT INTO OrderItems (OrderID, ProductID, Quantity)
SELECT 
    o.OrderID,
    p.ProductID,
    o.Quantity
FROM OldStore.CustomerOrders o
JOIN Products p ON o.ProductName = p.ProductName;

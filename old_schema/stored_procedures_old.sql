-- GetOrdersByCustomerEmail
DELIMITER $$
CREATE PROCEDURE GetOrdersByCustomerEmail (
    IN inputEmail VARCHAR(100)
)
BEGIN 
    SELECT * FROM CustomerOrders
    WHERE CustomerEmail = inputEmail
    ORDER BY OrderDate DESC;
END$$
DELIMITER ;

-- InsertOrder
DELIMITER $$
CREATE PROCEDURE InsertOrder (
    IN inputCustomerName VARCHAR(100),
    IN inputCustomerEmail VARCHAR(100),
    IN inputProductName VARCHAR(100),
    IN inputQuantity INT,
    IN inputOrderDate DATETIME
)
BEGIN
    INSERT INTO CustomerOrders (CustomerName, CustomerEmail, ProductName, Quantity, OrderDate)
    VALUES (inputCustomerName, inputCustomerEmail, inputProductName, inputQuantity, inputOrderDate);
END$$
DELIMITER ;

-- DeleteOrderById
DELIMITER $$
CREATE PROCEDURE DeleteOrderById (
    IN inputOrderID INT
)
BEGIN
    DELETE FROM CustomerOrders
    WHERE OrderID = inputOrderID;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE GetAllOrders()
BEGIN
    SELECT * FROM CustomerOrders;
END$$
DELIMITER ;

-- GetAllOrders
DELIMITER $$
CREATE PROCEDURE GetAllOrders()
BEGIN
    SELECT * FROM CustomerOrders;
END$$
DELIMITER ;
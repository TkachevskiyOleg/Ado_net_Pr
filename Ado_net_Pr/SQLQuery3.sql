CREATE DATABASE StationeryCompany;
USE StationeryCompany;

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    Quantity INT NOT NULL,
    CostPrice DECIMAL(10, 2) NOT NULL,
    SupplierName VARCHAR(255) NOT NULL,
    SupplierContact VARCHAR(100) NOT NULL
);

CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY,
    Manager VARCHAR(100) NOT NULL,
    CustomerName VARCHAR(255) NOT NULL,
    SalesManager VARCHAR(100) NOT NULL,
    QuantitySold INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    SaleDate DATE NOT NULL,
    ProductID INT NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);


INSERT INTO Products (Name, Type, Quantity, CostPrice, SupplierName, SupplierContact)
VALUES ('Pen', 'Stationery', 100, 1.50, 'ABC Suppliers', 'abc@example.com'),
       ('Notebook', 'Stationery', 50, 2.00, 'XYZ Suppliers', 'xyz@example.com');


INSERT INTO Sales (Manager, CustomerName, SalesManager, QuantitySold, UnitPrice, SaleDate, ProductID)
VALUES ('John Doe', 'Customer A', 'Sales Manager A', 10, 1.50, '2024-04-27', 1),
       ('Jane Smith', 'Customer B', 'Sales Manager B', 5, 2.00, '2024-04-28', 2);

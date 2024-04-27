using System;
using System.Data.SqlClient;

class Program
{
    static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StationeryCompany;Integrated Security=True;Connect Timeout=30;";

    static void Main()
    {
        if (TestConnection())
        {
            Console.WriteLine("Connection to the database successful");
            DisplayAllProducts();
            DisplayAllProductTypes();
            DisplayAllSalesManagers();
            DisplayProductsWithMaxQuantity();
            DisplayProductsWithMinQuantity();
            DisplayProductsWithMinCostPrice();
            DisplayProductsWithMaxCostPrice();
            DisplayProductsByType("Pens");
            DisplayProductsSoldByManager("John Doe");
            DisplayProductsPurchasedByCompany("ABC Company");
            DisplayRecentSalesInfo();
            DisplayAverageQuantityByProductType();
        }
        else
        {
            Console.WriteLine("Failed to connect to the database");
        }
    }

    static bool TestConnection()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }

    static void DisplayAllProducts()
    {
        Console.WriteLine("\n--- All Products ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Products";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ProductID: {reader["ProductID"]}, Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity: {reader["Quantity"]}, CostPrice: {reader["CostPrice"]}");
            }
            reader.Close();
        }
    }

    static void DisplayAllProductTypes()
    {
        Console.WriteLine("\n--- All Product Types ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT DISTINCT Type FROM Products";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Type: {reader["Type"]}");
            }
            reader.Close();
        }
    }

    static void DisplayAllSalesManagers()
    {
        Console.WriteLine("\n--- All Sales Managers ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT DISTINCT SalesManager FROM Sales";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Sales Manager: {reader["SalesManager"]}");
            }
            reader.Close();
        }
    }

    static void DisplayProductsWithMaxQuantity()
    {
        Console.WriteLine("\n--- Products with Maximum Quantity ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Products WHERE Quantity = (SELECT MAX(Quantity) FROM Products)";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ProductID: {reader["ProductID"]}, Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity: {reader["Quantity"]}, CostPrice: {reader["CostPrice"]}");
            }
            reader.Close();
        }
    }

    static void DisplayProductsWithMinQuantity()
    {
        Console.WriteLine("\n--- Products with Minimum Quantity ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Products WHERE Quantity = (SELECT MIN(Quantity) FROM Products)";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ProductID: {reader["ProductID"]}, Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity: {reader["Quantity"]}, CostPrice: {reader["CostPrice"]}");
            }
            reader.Close();
        }
    }

    static void DisplayProductsWithMinCostPrice()
    {
        Console.WriteLine("\n--- Products with Minimum Cost Price ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Products WHERE CostPrice = (SELECT MIN(CostPrice) FROM Products)";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ProductID: {reader["ProductID"]}, Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity: {reader["Quantity"]}, CostPrice: {reader["CostPrice"]}");
            }
            reader.Close();
        }
    }

    static void DisplayProductsWithMaxCostPrice()
    {
        Console.WriteLine("\n--- Products with Maximum Cost Price ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Products WHERE CostPrice = (SELECT MAX(CostPrice) FROM Products)";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ProductID: {reader["ProductID"]}, Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity: {reader["Quantity"]}, CostPrice: {reader["CostPrice"]}");
            }
            reader.Close();
        }
    }

    static void DisplayProductsByType(string type)
    {
        Console.WriteLine($"\n--- Products of type '{type}' ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = $"SELECT * FROM Products WHERE Type = '{type}'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ProductID: {reader["ProductID"]}, Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity: {reader["Quantity"]}, CostPrice: {reader["CostPrice"]}");
            }
            reader.Close();
        }
    }

 
    static void DisplayProductsSoldByManager(string manager)
    {
        Console.WriteLine($"\n--- Products sold by manager '{manager}' ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = $"SELECT * FROM Sales WHERE SalesManager = '{manager}'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ProductID: {reader["ProductID"]}, Customer: {reader["CustomerName"]}, Quantity Sold: {reader["QuantitySold"]}, Unit Price: {reader["UnitPrice"]}, Sale Date: {reader["SaleDate"]}");
            }
            reader.Close();
        }
    }


    static void DisplayProductsPurchasedByCompany(string companyName)
    {
        Console.WriteLine($"\n--- Products purchased by company '{companyName}' ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = $"SELECT * FROM Sales WHERE CustomerName = '{companyName}'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ProductID: {reader["ProductID"]}, Sales Manager: {reader["SalesManager"]}, Quantity Sold: {reader["QuantitySold"]}, Unit Price: {reader["UnitPrice"]}, Sale Date: {reader["SaleDate"]}");
            }
            reader.Close();
        }
    }


    static void DisplayRecentSalesInfo()
    {
        Console.WriteLine("\n--- Recent Sales Information ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT TOP 10 * FROM Sales ORDER BY SaleDate DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"SaleID: {reader["SaleID"]}, Customer: {reader["CustomerName"]}, Sales Manager: {reader["SalesManager"]}, Quantity Sold: {reader["QuantitySold"]}, Unit Price: {reader["UnitPrice"]}, Sale Date: {reader["SaleDate"]}");
            }
            reader.Close();
        }
    }

    
    static void DisplayAverageQuantityByProductType()
    {
        Console.WriteLine("\n--- Average Quantity by Product Type ---");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Type, AVG(Quantity) AS AverageQuantity FROM Products GROUP BY Type";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Type: {reader["Type"]}, Average Quantity: {reader["AverageQuantity"]}");
            }
            reader.Close();
        }
    }
}

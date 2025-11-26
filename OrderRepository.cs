using System.Data.SqlClient;
using Domain.Entities;
using Domain.Services;
using Application.Common;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public class OrderRepository 
{
    private readonly string _connectionString;
    private readonly ILogger _logger;

    public OrderRepository(string cs, ILogger logger)
    {
        _connectionString = cs;
        _logger = logger;
    }

    public void Save(Mysqlx.Crud.Order order)
    {
        const string sql = @"INSERT INTO Orders(Id, Customer, Product, Qty, Price) 
                             VALUES (@Id, @Customer, @Product, @Qty, @Price)";

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@Id", order.Id);
        cmd.Parameters.AddWithValue("@Customer", order.CustomerName);
        cmd.Parameters.AddWithValue("@Product", order.ProductName);
        cmd.Parameters.AddWithValue("@Qty", order.Quantity);
        cmd.Parameters.AddWithValue("@Price", order.UnitPrice);

        conn.Open();
        cmd.ExecuteNonQuery();

        _logger.Log("Order saved in DB");
    }
}



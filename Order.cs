using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Order
{
    public int Id { get; private set; }
    public string CustomerName { get; private set; }
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    public decimal Total => Quantity * UnitPrice;

    public Order(int id, string customer, string product, int qty, decimal price)
    {
        Id = id;
        CustomerName = customer;
        ProductName = product;
        Quantity = qty;
        UnitPrice = price;
    }
}


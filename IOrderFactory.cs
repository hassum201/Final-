using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Services;

namespace Infrastructure.Implementation;

public class OrderFactory 
{
    private readonly Random _random = new();

    public Order Create(string customer, string product, int qty, decimal price)
    {
        return new Order(
            _random.Next(1, 9999999),
            customer,
            product,
            qty,
            price
        );
    }
}


using System;
using System.Threading;
namespace Application.UseCases;

using Domain.Entities;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Logging;

public class CreateOrderUseCase
{
    private readonly IOrderFactory _factory;
    private readonly IOrderRepository _repository;
    private readonly ILogger _logger;

    public CreateOrderUseCase(IOrderFactory factory, IOrderRepository repository, ILogger logger)
    {
        _factory = factory;
        _repository = repository;
        _logger = logger;
    }

    public Order Execute(string customer, string product, int qty, decimal price)
    {
        _logger.Log("CreateOrder starting");

        var order = _factory.Create(customer, product, qty, price);

        _repository.Save(order);

        return order;
    }
}

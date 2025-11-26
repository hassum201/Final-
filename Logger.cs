using Application.Common;
using Microsoft.Extensions.Logging;
using System;

namespace Infrastructure.Logging;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now} - {message}");
    }
}
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public interface ICustomerRepository
{
    void Add(Customer c);
    Customer Get(int id);
}

public class InMemoryCustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _db = new List<Customer>();

    public void Add(Customer c)
    {
        _db.Add(c);
    }

    public Customer Get(int id)
    {
        foreach (Customer c in _db)
        {
            if (c.Id == id)
            {
                return c;
            }
        }
        return null;
    }
}

public class CustomerService
{
    private readonly ICustomerRepository _repo;

    public CustomerService(ICustomerRepository repo)
    {
        _repo = repo;
    }

    public void PrintCustomer(int id)
    {
        var customer = _repo.Get(id);
        if (customer == null)
            Console.WriteLine($"Customer {id} not found!");
        else
            Console.WriteLine($"Customer: {customer.Id} - {customer.Name}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
                services.AddTransient<CustomerService>();
            });

        var app = builder.Build();

        var repo = app.Services.GetRequiredService<ICustomerRepository>();
        repo.Add(new Customer { Id = 1, Name = "Alice" });
        repo.Add(new Customer { Id = 2, Name = "Bob" });

        var service = app.Services.GetRequiredService<CustomerService>();
        service.PrintCustomer(1);
        service.PrintCustomer(2);
        service.PrintCustomer(99);
    }
}

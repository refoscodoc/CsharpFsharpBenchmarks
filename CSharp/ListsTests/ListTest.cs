using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace CSharp.ListsTests;

[MemoryDiagnoser]
public class ListTest
{
    private static string[] names = new[]
    {
        "John", "Alberto", "Tomasz", "Jean-Pierre", "Nathalie",
        "Samantha", "Edward", "Tanya", "Michelle", "Kurt",
        "Justine", "Christian", "Christopher", "Andres", "Katarzyna",
        "Leon", "Adrian", "Sheldon", "Maxime", "Monika"
    };

    private static bool[] booleans = new[] {true, false};
    
    ImmutableList<Customer> customers = CSharpGenerateCustomersImmutable().ToImmutableList<Customer>();

    public static List<Customer> CSharpGenerateCustomersImmutable()
    {
        var numberToGenerate = 1000000;
        var random = new Random(10);
        List<Customer> _customers = new List<Customer>();

        for (int i = 0; i < numberToGenerate; i++)
        {
            _customers.Add(new Customer
            {
                Id = i,
                Age = random.Next(18, 100),
                Name = names[random.Next(0, names.Length)],
                IsVip = booleans[random.Next(0, booleans.Length)],
                CustomerSince = DateTime.Today.AddMonths(-random.Next(0, 121))
            });
        }

        return _customers;
    }

    [Benchmark]
        [ArgumentsSource(nameof(customers))]
        public void CSharpModifyCustomersImmutable()
        {            
            var today = DateTime.Today;
            foreach (var customer in customers)
            {
                if (today.Subtract(customer.CustomerSince).Days > 365*2)
                {
                    customer.IsVip = true;
                }
            }
        }
    
}

public class Customer
{
    public int  Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsVip { get; set; }
    public DateTime CustomerSince { get; set; }
}
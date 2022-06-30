using BenchmarkDotNet.Attributes;

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
    
    List<Customer> _customers = new();

    public void CSharpGenerateCustomersImmutable()
    {
        var numberToGenerate = 1000000;
        var random = new Random(10);

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
    }

    // public class PerformanceTestsImmutableList
    // {
    //     List<Customer> _customers = new();
    //
    //     public void CSharpGenerateCustomersImmutable()
    //     {
    //         var numberToGenerate = 1000000;
    //         var random = new Random(10);
    //
    //         for (int i = 0; i < numberToGenerate; i++)
    //         {
    //             _customers.Add(new Customer
    //             {
    //                 Id = i,
    //                 Age = random.Next(18, 100),
    //                 Name = names[random.Next(0, names.Length)],
    //                 IsVip = booleans[random.Next(0, booleans.Length)],
    //                 CustomerSince = DateTime.Today.AddMonths(-random.Next(0, 121))
    //             });
    //         }
    //     }

        [Benchmark]
        [ArgumentsSource(nameof(_customers))]
        public void CSharpModifyCustomersImmutable()
        {
            CSharpGenerateCustomersImmutable();
            var today = DateTime.Today;
            foreach (var customer in _customers)
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
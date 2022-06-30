using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CSharp.ListsTests;
using CSharp.SpanTests;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            // BenchmarkRunner.Run<BenchmarkCsharp>();
            BenchmarkRunner.Run<ListTest>();
        }
    }

    [MemoryDiagnoser()]
    public class BenchmarkCsharp
    {
        private readonly string _dateAndNow = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        
        [Benchmark]
        public (int day, int month, int year, int hour, int minutes) SpanTestSlicerCsharp()
        {
            ReadOnlySpan<char> dateReadOnlySpan = _dateAndNow;
            var dayAsText = int.Parse(dateReadOnlySpan.Slice(0, 2));
            var monthAsText = int.Parse(dateReadOnlySpan.Slice(3, 2));
            var yearAsText = int.Parse(dateReadOnlySpan.Slice(6, 4));
            var hourAsText = int.Parse(dateReadOnlySpan.Slice(11, 2));
            var minutesAsText = int.Parse(dateReadOnlySpan.Slice(14, 2));
        
            return (dayAsText, monthAsText, yearAsText, hourAsText, minutesAsText);
        }
    }
}
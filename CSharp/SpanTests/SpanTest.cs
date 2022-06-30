using BenchmarkDotNet.Attributes;

namespace CSharp.SpanTests;

public class SpanTest
{
    private readonly string _dateAndNow = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

    [Benchmark]
    public (int day, int month, int year, int hour, int minutes) SpanTestSlicer()
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
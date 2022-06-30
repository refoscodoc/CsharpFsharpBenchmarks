``` ini

BenchmarkDotNet=v0.13.1, OS=garuda 
AMD Ryzen 7 3700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.102
  [Host]     : .NET 6.0.2 (6.0.222.11801), X64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.11801), X64 RyuJIT


```
|               Method |     Mean |    Error |   StdDev | Allocated |
|--------------------- |---------:|---------:|---------:|----------:|
| SpanTestSlicerCsharp | 77.03 ns | 1.222 ns | 1.143 ns |         - |

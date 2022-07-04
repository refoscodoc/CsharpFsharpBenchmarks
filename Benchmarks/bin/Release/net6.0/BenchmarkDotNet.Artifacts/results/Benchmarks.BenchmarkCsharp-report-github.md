``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1766 (20H2/October2020Update)
AMD Ryzen 5 PRO 3500U w/ Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.102
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
|               Method |     Mean |   Error |   StdDev | Allocated |
|--------------------- |---------:|--------:|---------:|----------:|
| SpanTestSlicerCsharp | 118.0 ns | 5.88 ns | 16.87 ns |         - |

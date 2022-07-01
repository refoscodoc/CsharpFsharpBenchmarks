``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1766 (20H2/October2020Update)
AMD Ryzen 5 PRO 3500U w/ Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.102
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT DEBUG  [AttachedDebugger]
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
|                         Method |     Mean |    Error |   StdDev | Allocated |
|------------------------------- |---------:|---------:|---------:|----------:|
| FSharp_ModifyCustomers_Mutable | 302.2 ns | 14.60 ns | 43.04 ns |         - |

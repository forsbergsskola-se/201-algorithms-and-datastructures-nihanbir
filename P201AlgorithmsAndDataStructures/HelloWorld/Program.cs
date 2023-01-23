using System.Diagnostics;
using TurboCollections;

TurboMaths.SayHello();

var sw = new Stopwatch();
sw.Start();
Console.WriteLine(TurboMaths.RecursiveFib(40));
sw.Stop();
Console.WriteLine($"Time elapsed (recursive): {sw.Elapsed}");
sw.Reset();
sw.Start();
Console.WriteLine(TurboMaths.IterativeFib(40));
sw.Stop();
Console.WriteLine($"Time elapsed (iterative): {sw.Elapsed}");
using System.Collections.Concurrent;

var usage = new ConcurrentDictionary<int, int>();
var resultsBag = new ConcurrentBag<double>();

var values = Enumerable.Range(1, 10);

var parallel = values.AsParallel().AsOrdered();

var sum = (from val in parallel 
               select Flag(val * val)).AsSequential().Aggregate((sum, next)=>
               {
                   Console.WriteLine($"{sum} - {next} on {Environment.CurrentManagedThreadId}");
                   
                   return 2 * sum + next;
               });

Console.WriteLine(sum);

//sequence.ForAll(val =>
//{
//    Console.WriteLine($"Displaying {val} on {Environment.CurrentManagedThreadId}");
//});

//foreach (var i in sequence)
//    Console.WriteLine(i);

int Flag(int n)
{
    Console.WriteLine($"Processing {n} on {Environment.CurrentManagedThreadId}");

    return n;
}

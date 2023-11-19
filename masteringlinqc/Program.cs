//one to ten int list
using System.Collections;

var range = Enumerable.Range(1, 10).ToList();
Console.WriteLine(range);
Console.WriteLine("--------------------------------");

// alphabet listchar
var alpabet = Enumerable.Range('a', 'z' - 'a' + 1).Select(x => (char)x).ToList();

foreach (var item in alpabet)
{
    Console.WriteLine(item);
}
Console.WriteLine("--------------------------------");
// list of string

var lstString = Enumerable.Range(1, 10).Select(x => new string('x', x)).ToList();

foreach (var item in lstString)
{
    Console.WriteLine(item);
}

Console.WriteLine("--------------------------------");

var list = new ArrayList();
list.Add(1);
list.Add(2);
list.Add(3);
//Console.WriteLine(list.sel); ArrayList is not implement IEnumerable so you cant Iterate

Console.WriteLine(list.Cast<int>().Average());

Console.WriteLine("--------------------------------");

var numbers = Enumerable.Range(1, 10);
var arr = numbers.ToArray(); // toList
var dict = numbers.ToDictionary(i => (double)i / 10, i => i % 2 == 0);

var arr2 = new[] { 1, 2, 3 };
IEnumerable<int> arre = arr2.AsEnumerable();

foreach (var item in dict)
{
    Console.WriteLine(item);
}

Console.WriteLine("--------------------------------");
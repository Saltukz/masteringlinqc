//one to ten int list
using masteringlinqc;
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

//Console.WriteLine(list.Cast<int>().Average());

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

var numbers1 = Enumerable.Range(1, 4);
var squares1 = numbers1.Select(i => i * i);

Console.WriteLine("--------------------------------");

var sentence = "this is a nice sentence";
var wordLengths = sentence.Split().Select(i => i.Length);
var wordswithLength = sentence.Split()
    .Select(w => new { w, w.Length }).ToList();

foreach (var word in wordswithLength)
{
    Console.WriteLine(word);
}

Console.WriteLine("--------------------------------");

Random rand = new Random();
//you dont have to use range inputs in select
var randomNumbers = Enumerable.Range(1, 10).Select(_ => rand.Next(10));

Console.WriteLine("--------------------------------");

var sequnces = new[] { "red,green,blue", "orange", "white,pink" };

var allWords = sequnces.SelectMany(s => s.Split(',')).ToList();

Console.WriteLine("--------------------------------");

string[] objects = { "house", "car", "bicycle" };

string[] colors = { "red", "green", "gray" };

var pairs = colors.SelectMany(_ => objects, (c, o) => $"{c} {o}");
foreach (var pair in pairs)
{
    Console.WriteLine(pair);
}

var pairs1 = colors.SelectMany(_ => objects, (c, o) => new { color = c, obj = o });
foreach (var pair in pairs)
{
    Console.WriteLine(pair);
}

Console.WriteLine("--------------------------------");

var rand1 = new Random();
var randomValues = Enumerable.Range(1, 10).Select(_ => rand1.Next(10) - 5);

var csvString = new Func<IEnumerable<int>, string>(values =>
{
    return string.Join(",", values.Select(v => v.ToString()).ToArray());
});
Console.WriteLine(csvString(randomValues));
Console.WriteLine(csvString(randomValues.OrderBy(x => x)));
Console.WriteLine(csvString(randomValues.OrderByDescending(x => x)));

Console.WriteLine("--------------------------------");

//var people = new List<Person>
//{
//   new Person{Name = "Adam",Age= 36},
//   new Person{Name = "Adam",Age= 36},
//   new Person{Name = "Boris",Age= 18},
//   new Person{Name = "Claire",Age= 36},
//   new Person{Name = "Adam",Age= 20},
//   new Person{Name = "Jack",Age= 36}
//};

//IOrderedEnumerable<Person> sortedPeople = people.OrderBy(x => x.Name).ThenBy(x => x.Age);

//string s = "this is a test";

//Console.WriteLine(new string(s.Reverse().ToArray()));

//Console.WriteLine("--------------------------------");

//var byName = people.GroupBy(z => z.Name);

//var byAgeName = people.GroupBy(z => z.Age, x => x.Name);
//Console.WriteLine(byName);

Console.WriteLine("--------------------------------");

string word1 = "helloooo";
string word2 = "help";

word1.Distinct();//unique elements

var lettersInBoth = word1.Intersect(word2); // common elements

word1.Union(word2);//all uniques as collection

word1.Except(word2); // distinction, all uniqe letter in word1

Console.WriteLine("--------------------------------");

int[] numbers2 = { 1, 2, 3, 4, 5 };
//are all numbers>0?
numbers2.All(x => x > 0); // true
//are all numbers odd?
numbers2.All(x => x % 2 == 1); // false
//any number < 2?
numbers2.Any(x => x < 2);

Console.WriteLine(new int[] { }.Any()); //false bc no element any checks it

// contains 5?
numbers2.Contains(5);

Console.WriteLine("---------Skip&&Take----------");

var numbers3 = new[] { 3, 3, 2, 2, 1, 1, 2, 2, 3, 3 };

numbers3.Skip(2);//skip first 2 elemet
numbers3.Skip(2).Take(6);//skip first 2 element take 6 element after

//skipwhile
numbers3.SkipWhile(x => x == 3);// skip first equals element

//takewhile
numbers3.TakeWhile(x => x > 1); // stops after find false

Console.WriteLine("---------Join&&GroupJoin----------");

var people1 = new Person[]
{
    new Person("Jane","jane@foo.com"),
    new Person("John","john@foo.com"),
    new Person("Chris",string.Empty)
};

var records = new Record[]
{
    new Record("jane@foo.com","JaneAtFoo"),
    new Record("jane@foo.com","JaneAtHome"),
    new Record("john@foo.com","John1980")
};

var query = people1.Join(records, x => x.Email, y => y.Mail, (person, record) => new { Name = person.Name, SkypeId = record.SkypeId });

foreach (var nameless in query)
    Console.WriteLine(nameless);

people1.GroupJoin(records, x => x.Email, y => y.Mail, (person, recs) => new
{
    Name = person.Name,
    SkypeIds = recs.Select(r => r.SkypeId).ToArray()
});

foreach (var grp in people1)
    Console.WriteLine(grp);

//first last single elementat

var numbers4 = new List<int> { 1, 2, 3 };

//invalid operation exception
//numbers.First(x => x > 10);

//returns default value if not match which is zero for int
numbers.FirstOrDefault(x => x > 10);

//same operations like first
numbers.Last(x => x < 10);

//sequnce contains more than one element
//var sigleObj = new int[] { 123, 45 }.Single();

//0 if empty if 1 returns single other situations exception
//var sigleOrObj = new int[] { 123, 45 }.SingleOrDefault();

// like [0]
numbers4.ElementAt(0);

// not expcetion if range has been
numbers4.ElementAtOrDefault(5);

//concatenation

var integralTypes = new[] { typeof(int), typeof(short) };
var fpTypes = new[] { typeof(float), typeof(double) };

//concat 2 types as a one new type
integralTypes.Concat(fpTypes).Prepend(typeof(bool));

//Statical Functions
var numbersStatical = Enumerable.Range(1, 10);

//sum
//1 2 3 4 5 ...
// 1 2 -> 3
// 3 3 -> 6
numbersStatical.Aggregate((p, x) => p + x);
//same
numbersStatical.Sum();
// 1 1 -> 1
// 1 2 -> 2
// 2 3 -> 6

numbersStatical.Aggregate(1, (p, x) => p * x);

//avarage
numbersStatical.Average();

//comma between

var wordsAggregate = new[] { "one", "two", "three" };
wordsAggregate.Aggregate((p, x) => p + "," + x);

//ParalelLinq

const int count = 50;

var items = Enumerable.Range(1, count).ToArray();

var resultsParalel = new int[count];

items.AsParallel().ForAll(x =>
{
    int newValue = x * x * x;
    Console.WriteLine($"{newValue},({Task.CurrentId})\t");
    resultsParalel[x - 1] = newValue;
});

//foreach (var item in resultsParalel)
//{
//    Console.WriteLine(item);
//}

var cubes = items.AsParallel().AsOrdered().Select(x => x * x * x);

foreach (var item in cubes)
{
    Console.WriteLine(item);
}

//Cancelation and Exception

var cts = new CancellationTokenSource();
var itemsCan = ParallelEnumerable.Range(1, 20);

var resultsCan = itemsCan.WithCancellation(cts.Token).Select(i =>
{
    double result = Math.Log10(i);

    if (result > 2)
    {
        throw new InvalidOperationException();
    }
    Console.WriteLine($"i = {i},taskid = {Task.CurrentId}");
    return result;
});

try
{
    foreach (var c in resultsCan)
    {
        if (c > 1)
        {
            cts.Cancel();
        }
        Console.WriteLine($"result = {c}");
    }
}
catch (AggregateException ae)
{
    ae.Handle(e =>
    {
        Console.WriteLine($"{e.GetType().Name} : {e.Message}");
        return true;
    });
}
catch (OperationCanceledException e)
{
    Console.WriteLine("Canceled");
}

//MergeOptions

var numbersMerge = ParallelEnumerable.Range(1, 20).ToArray();

var resultsMerge = numbersMerge
    .AsParallel()
    .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
    .Select(x =>
    {
        var result = Math.Log10(x);
        Console.WriteLine($"Produced {result}");
        return result;
    });

foreach (var res in resultsMerge)
{
    Console.WriteLine($"Consumed {res}");
}

//CustomAggregation

var sum = ParallelEnumerable.Range(1, 1000)
    .Aggregate(0, (partialSUm, i) => partialSUm += 1, (total, subTotal) => total += subTotal, i => i);

internal static class ExtensionMethods
{
    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> values, T value)
    {
        yield return value;
        foreach (var item in values)
        {
            yield return item;
        }
    }
}
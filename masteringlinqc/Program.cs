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
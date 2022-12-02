// TODO try stuff with Spans
// TODO write as one-liner for shits and giggles

var input = File.ReadAllLines("C:\\dev\\area-51\\advent-of-code-22\\Day1\\Inputs\\input.txt");

// TODO dynamic seperator for where clause and add to static "Toolbox" class
// grabs the indexes at which the whitespaces occur (and add an index for the end of the file)
var borders = input
    .Select((line, index) => (line, index))
    .Where(x => string.IsNullOrWhiteSpace(x.line))
    .Select(x => x.index)
    .Append(input.Length)
    .ToArray();

// gets the sum of values between indexes
int Accumulate(int from, int until) => input.Take(from..until).Sum(int.Parse);

// TODO can probably simplify
// if we know how many borders there are, we know how many groups there are, sooo... accumulate the values between the borders :)
var result = borders.Select((border, i) => Accumulate((i == 0 ? 0 : borders[i - 1] + 1), border)).ToArray();

// gives some insight into the select
foreach (var (border, i) in borders.Select((x, y) => (x, y)))
{
    Console.WriteLine($"accumulate from: {(i == 0 ? 0 : borders[i - 1] + 1)} \t until: {border} \t results in: {result[i]}");
}

Console.WriteLine("--------------------");
Console.WriteLine($"max: {result.Max()}");
Console.WriteLine("--------------------");
Console.WriteLine($"sum top 3: {result.OrderDescending().Take(3).Sum()}");
Console.WriteLine("--------------------");
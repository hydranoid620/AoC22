using System.Text.RegularExpressions;
using static CommonLib.CommonLib;

List<string> input = ReadFileColumn<string>(args[0]).ToList();
var cratesStack = new List<Stack<char>>();

// Read my input and create part 1's data
string[] stacksInput = input.TakeWhile(x => x != "").ToArray();
string stackNumbersInput = stacksInput.Last();
for (var i = 0; i < stackNumbersInput.Length; i++)
{
    if (!char.IsNumber(stackNumbersInput[i])) continue;
    
    var newStack = new Stack<char>();
    for (int j = stacksInput.Length - 2; j >= 0  && stacksInput[j][i] != ' '; j--) newStack.Push(stacksInput[j][i]);
    cratesStack.Add(newStack);
}

// Create part 2's data
var cratesList = new List<List<char>>(cratesStack.Select(stack => stack.ToList()));
foreach (List<char> list in cratesList) list.Reverse(); // Much easier to append to a list than to prepend 

// Run each instruction
Regex rx = new(@"[0-9]+");
foreach (string instruction in input.SkipWhile(x => !x.StartsWith("move")))
{
    MatchCollection matches = rx.Matches(instruction);
    int numberOfMoves = int.Parse(matches[0].Value);
    int source = int.Parse(matches[1].Value) - 1;
    int destination = int.Parse(matches[2].Value) - 1;

    // Execute instruction for CrateMover 9000
    for (var i = 0; i < numberOfMoves; i++) cratesStack.ElementAt(destination).Push(cratesStack.ElementAt(source).Pop());

    // Execute instruction for CrateMover 9001
    cratesList.ElementAt(destination).AddRange(cratesList.ElementAt(source).Skip(cratesList.ElementAt(source).Count - numberOfMoves));
    cratesList.ElementAt(source).RemoveRange(cratesList.ElementAt(source).Count - numberOfMoves, numberOfMoves);
}

Console.Write("Part 1: ");
foreach (Stack<char> stack in cratesStack) Console.Write(stack.Peek());
Console.Write("\nPart 2: ");
foreach (List<char> list in cratesList) Console.Write(list.Last());
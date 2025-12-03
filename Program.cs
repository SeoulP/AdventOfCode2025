// See https://aka.ms/new-console-template for more information

using AdventOfCode2025.Day_2;

Console.WriteLine("Select a Day and Part (ex: 1.1)");
bool isStillProcessing = true;

do
{
    Console.Write("Enter Day: ");
    var input = Console.ReadLine();
    switch (input)
    {
        case "1.1":
            Day1Part1.Run();
            isStillProcessing = false;
            break;
        case "1.2":
            Day1Part2.Run();
            isStillProcessing = false;
            break;
        case "2.1":
            Day2Part1.Run();
            isStillProcessing = false;
            break;
        case "2.2":
            Day2Part2.Run();
            isStillProcessing = false;
            break;
        default:
            Console.WriteLine("This is not a valid day.");
            isStillProcessing = true;
            break;
    }
} while (isStillProcessing);

Console.WriteLine("Day finished.");

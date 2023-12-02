// See https://aka.ms/new-console-template for more information

using Advent_of_Code_2023___Snowpocalypse.Day1_Trebuchet;
using Advent_of_Code_2023___Snowpocalypse.Day2_CubeConundrum;

Console.WriteLine("-- Advent of Code 2023 - Snowpocalypse --");


Console.WriteLine("Day 1 - Trebuchet");
var documentDePrettifier = new DocumentDePrettifier();
documentDePrettifier.PrintProblem();


Console.WriteLine("Day 2 - Cube Conundrum");
var testCubeElf = new CubeElf(File.ReadAllLines(@"Day2-CubeConundrum\testdata.txt"));
var cubeElf = new CubeElf(File.ReadAllLines(@"Day2-CubeConundrum\data.txt"));

Console.WriteLine($@"Part 1: Test data returns sum {testCubeElf.SumValidGames()}");
Console.WriteLine($@"Part 1: Data returns sum {cubeElf.SumValidGames()}");

Console.WriteLine($@"Part 2: Test data returns sum {testCubeElf.SumGamePower()}");
Console.WriteLine($@"Part 2: Data returns sum {cubeElf.SumGamePower()}");


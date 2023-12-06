// See https://aka.ms/new-console-template for more information

using Advent_of_Code_2023___Snowpocalypse.Day1_Trebuchet;
using Advent_of_Code_2023___Snowpocalypse.Day2_CubeConundrum;
using Advent_of_Code_2023___Snowpocalypse.Day3_GearRatops;
using Advent_of_Code_2023___Snowpocalypse.Day4_Scratchcards;
using Advent_of_Code_2023___Snowpocalypse.Day5_Gardening;
using Advent_of_Code_2023___Snowpocalypse.Day6_BoatRace;

Console.WriteLine("-- Advent of Code 2023 - Snowpocalypse --");


// Console.WriteLine("Day 1 - Trebuchet");
// var documentDePrettifier = new DocumentDePrettifier();
// documentDePrettifier.PrintProblem();
//
// Console.WriteLine("Day 2 - Cube Conundrum");
// var testCubeElf = new CubeElf(File.ReadAllLines(@"Day2-CubeConundrum\testdata.txt"));
// var cubeElf = new CubeElf(File.ReadAllLines(@"Day2-CubeConundrum\data.txt"));
// Console.WriteLine($@"Part 1: Test data returns sum {testCubeElf.SumValidGames()}");
// Console.WriteLine($@"Part 1: Data returns sum {cubeElf.SumValidGames()}");
// Console.WriteLine($@"Part 2: Test data returns sum {testCubeElf.SumGamePower()}");
// Console.WriteLine($@"Part 2: Data returns sum {cubeElf.SumGamePower()}");

// Console.WriteLine("Day 3 - Gear Ratios");
// var testSchematic = new SchematicParser(File.ReadAllLines(@"Day3-GearRatios\test_data.txt"));
// var schematic = new SchematicParser(File.ReadAllLines(@"Day3-GearRatios\data.txt"));
// Console.WriteLine($@"Part 1: Test data returns sum {testSchematic.SumValidPartNumber()}");
// Console.WriteLine($@"Part 1: Data returns sum {schematic.SumValidPartNumber()}");
// Console.WriteLine($@"Part 2: Test data returns sum {testSchematic.GearRatioCalculator()}");
// Console.WriteLine($@"Part 2: Data returns sum {schematic.GearRatioCalculator()}");

// Console.WriteLine("Day 4 - Scratchcards");
// var testScratcher = new ScratchMaster3000(File.ReadAllLines(@"Day4-Scratchcards\test_data.txt"));
// var scratcher = new ScratchMaster3000(File.ReadAllLines(@"Day4-Scratchcards\data.txt"));
// Console.WriteLine($@"Part 1: Test data returns sum {testScratcher.SumPoints()}");
// Console.WriteLine($@"Part 1: Data returns sum {scratcher.SumPoints()}");
// Console.WriteLine($@"Part 2: Test data returns sum {testScratcher.NumberOfWonScratchcards()}");
// Console.WriteLine($@"Part 2: Data returns sum {scratcher.NumberOfWonScratchcards()}");

// Console.WriteLine("Day 5 - Gardening");
// var testAlmanac = new Almanac(File.ReadAllLines(@"Day5-Gardening\test_data.txt"));
// var testAlmanac2 = new AlmanacPart2(File.ReadAllLines(@"Day5-Gardening\test_data.txt"));
// Console.WriteLine($@"Part 2: Test data returns min location {testAlmanac2.MinLocation}");
// var almanac = new Almanac(File.ReadAllLines(@"Day5-Gardening/data"));
// var almanac2 = new AlmanacPart2(File.ReadAllLines(@"Day5-Gardening/data"));
// Console.WriteLine($@"Part 1: Test data returns min location {testAlmanac.SeedToMinLocation()}");
// Console.WriteLine($@"Part 1: Data returns min location {almanac.SeedToMinLocation()}");


Console.WriteLine("Day 6 - Boat Race");
var testCompetition = new Competition(File.ReadAllLines(@"Day6-BoatRace\test_data.txt"));
Console.WriteLine($@"Part 1: Data returns {testCompetition.NumberOfWaysToBeatFactor()}");
var competition = new Competition(File.ReadAllLines(@"Day6-BoatRace\data.txt"));
Console.WriteLine($@"Part 1: Data returns {competition.NumberOfWaysToBeatFactor()}");
var testCompetition2 = new Competition(File.ReadAllLines(@"Day6-BoatRace\test_data2.txt"));
Console.WriteLine($@"Part 2: Data returns {testCompetition2.NumberOfWaysToBeatFactor()}");
var competition2 = new Competition(File.ReadAllLines(@"Day6-BoatRace\data2.txt"));
Console.WriteLine($@"Part 2: Data returns {competition2.NumberOfWaysToBeatFactor()}");


// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using ConsoleApp1;

var arrayTasks = new ArrayTasks();
Console.WriteLine(string.Join(", ", arrayTasks.ArrayFilterViaResize()));
Console.WriteLine(string.Join(", ", arrayTasks.ArrayFilterViaArrayConcat()));
Console.WriteLine(string.Join(", ", arrayTasks.ArrayFilterViaWhereClause()));
Console.WriteLine(string.Join(", ", arrayTasks.ArrayFilterViaListsWhereClause()));
Console.WriteLine(string.Join(", ", arrayTasks.ArrayFilterViaResultArraySameSized()));
Console.WriteLine(string.Join(", ", arrayTasks.ArrayFilterViaListsAdd()));
var summary = BenchmarkRunner.Run<ArrayTasks>();
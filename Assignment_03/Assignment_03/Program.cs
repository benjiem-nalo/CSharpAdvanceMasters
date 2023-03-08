// See https://aka.ms/new-console-template for more information

using System.Collections;
using Assignment_03;

Hashtable keyValuePairs = new();
Console.WriteLine("Add item in the list!!!");
InputCollections inputCollections = new InputCollections(keyValuePairs);
ConsoleKey key;
ConsoleKey kk;
do
{
    while (!Console.KeyAvailable)
    {
        inputCollections.AddInput(Console.ReadLine());

        Console.Write($"Add more? Y/N : ");
        if (Console.ReadKey(false).Key == ConsoleKey.N)
        {
            Console.WriteLine();
            inputCollections.DisplayList();
            inputCollections.ClearLists();
        }
        else
        {
            inputCollections.AddInput(Console.ReadLine());
           
        }
    }

    // Key is available - read it
    key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.Z)
    {
        //inputCollections.DisplayList();
    }

} while (key != ConsoleKey.Escape);
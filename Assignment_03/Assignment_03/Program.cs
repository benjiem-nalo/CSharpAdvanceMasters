// See https://aka.ms/new-console-template for more information

using Assignment_03;

Dictionary<int, object> keyValuePairs = new();
Console.WriteLine("Add item in the list!!!");
InputCollections inputCollections = new InputCollections(keyValuePairs);
ConsoleKey key;
do
{
    while (!Console.KeyAvailable)
    {
        inputCollections.AddInput(Console.ReadLine());

        Console.WriteLine($"Add more? Y/N");
        if (Console.ReadKey(true).Key == ConsoleKey.N)
        {
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
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using Assignment_02;
using Contracts;
using System.Diagnostics.CodeAnalysis;

namespace Session_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo Key = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            do
            {
                Console.WriteLine("Select a pet:");

                var assymbly = Assembly.LoadFrom("C:\\repo\\MyProjects\\CSharpAdvanceMasters\\Assignment_02\\Pets\\bin\\Debug\\net6.0\\Pets.dll");
                var ass = assymbly.GetExportedTypes().ToList();

                foreach (var (item, index) in ass.WithIndex())
                {
                    Console.WriteLine($"{index}) {item.Name}");
                }

                //Get User pet selection
                Console.Write($"Pet number: ");
                var userInput = Console.ReadLine();

                _ = int.TryParse(userInput, out int parsedInput);
                var selectedPet = ass.WithIndex().FirstOrDefault(_ => _.index == parsedInput).item;

                //Display info base on selected pet
                if (selectedPet is null) 
                {
                    Console.WriteLine("No pet selected.");
                    Console.WriteLine("_________________");
                }
                else
                {
                    Console.WriteLine("*********");
                    Console.WriteLine($"Class: {selectedPet.Name}");

                    object? petInstance = Activator.CreateInstance(selectedPet);

                    //display properties
                    PropertyInfo[] properties = selectedPet.GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        var pValue = property.GetValue(petInstance);
                        Console.WriteLine($"{property.Name}: {pValue}");
                    }
                    Console.WriteLine("*********");
                    Console.WriteLine("Abilities");

                    Dictionary<int, string> abilitiesTemp = new Dictionary<int, string>();

                    //display abilities
                    MethodInfo[] methods = selectedPet.GetMethods();
                    int i = 0;
                    foreach (MethodInfo method in methods)
                    {
                        var caa = method.GetCustomAttribute<AbilityAttribute>();
                        if (caa is not null && caa is AbilityAttribute)
                        {
                            ++i;
                            abilitiesTemp.Add(i, method.Name);
                            Console.WriteLine($"{i}){method.Name}");
                        }
                    }

                    //Get User pet selection
                    Console.Write($"Select ability number: ");
                    var abilityInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(abilityInput))
                    {
                        Console.WriteLine("No ability selected.");
                        Console.WriteLine("_________________");
                    }
                    else
                    {
                        //parse input
                        _ = int.TryParse(abilityInput, out int parsedAbilityInput);
                        var selectedAbility = abilitiesTemp.FirstOrDefault(_ => _.Key == parsedAbilityInput).Value;
                        //print abilities
                        Abilities abilities = new((Pet)petInstance);
                        abilities.UseAbility(selectedAbility);
                        Console.WriteLine("_________________");
                    }
                }

                Key = Console.ReadKey();
            }
            while (Key.Key != ConsoleKey.Escape);
        }
    }
}
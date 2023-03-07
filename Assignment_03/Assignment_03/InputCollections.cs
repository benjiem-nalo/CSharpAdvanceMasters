using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_03
{
    public class InputCollections
    {
        private Dictionary<int, object?> repo;

        public InputCollections(Dictionary<int, object?> _repo)
        {
            repo = _repo;
        }
        public List<string>? StringList { get; set; } = new();
        public List<int>? IntList { get; set; } = new();
        public List<bool>? BoolList { get; set; } = new();
        public List<double>? DoubleList { get; set; } = new();

        public void AddInput<T>(T input)
        {
            //ParseAndSort(repo);
            var s = input?.ToString();
            if (!string.IsNullOrWhiteSpace(s))
            {
                repo?.Add(repo.Count + 1, input);

                if (int.TryParse(s, out int f))
                {
                    IntList.Add(f);
                }
                else if (double.TryParse(s, out double d))
                {
                    DoubleList.Add(d);
                }
                else if (bool.TryParse(s, out bool b))
                {
                    BoolList.Add(b);
                }
                else
                {
                    StringList.Add(s);
                }
            }

        }

        public void DisplayList()
        {
            Console.WriteLine("All inputs:");
            repo.ToList().ForEach(i => Console.WriteLine($"{i.Key} : {i.Value}"));
            Console.WriteLine($"Int inputs");
            IntList.ForEach(i => Console.WriteLine($"{i}"));
            Console.WriteLine($"Double inputs");
            DoubleList.ForEach(i => Console.WriteLine($"{i}"));
            Console.WriteLine($"Bool inputs");
            BoolList.ForEach(i => Console.WriteLine($"{i}"));
            Console.WriteLine($"String inputs");
            StringList.ForEach(i => Console.WriteLine($"{i}"));
        }

        public void ClearLists()
        {
            repo.Clear();
            IntList.Clear();
            DoubleList.Clear();
            BoolList.Clear();
            StringList.Clear();
        }
    }
}

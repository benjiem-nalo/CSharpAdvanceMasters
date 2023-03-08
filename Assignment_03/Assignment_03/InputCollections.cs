using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_03
{
    public class InputCollections
    {
        private Hashtable repo;

        public InputCollections(Hashtable _repo)
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
                repo?.Add(repo.Count+1, input);

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
            ArrayList al = new ArrayList(repo.Keys);
            al.Sort();

            Console.WriteLine("All inputs:");
            var orderedRepo = repo?.Cast<Dictionary<int,object>>().OrderBy(k => k);
            for (int i = 0; i < al.Count; i++)
            {
                Console.WriteLine($"{al[i]} : {repo[al[i]]}");
            }
            Console.WriteLine($"Int inputs:");
            IntList.ForEach(i => Console.WriteLine($"-->  {i}"));
            Console.WriteLine($"Double inputs:");
            DoubleList.ForEach(i => Console.WriteLine($"--> {i}"));
            Console.WriteLine($"Bool inputs:");
            BoolList.ForEach(i => Console.WriteLine($"--> {i}"));
            Console.WriteLine($"String inputs:");
            StringList.ForEach(i => Console.WriteLine($"--> {i}"));
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

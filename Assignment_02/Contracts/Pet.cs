using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Assignment_02
{
    public abstract class Pet : IPet
    {
        public abstract PetEnum PetType { get; }
        public abstract string Name { get; }
        [Ability]
        public void Sleep() { Console.WriteLine("Sleeping..."); }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_02;
using Contracts;

namespace Pets
{
    public class Fish : Pet
    {
        public override PetEnum PetType => PetEnum.Fish;
        public override string Name => "MyNameIsFish";
        [Ability]
        public void Swim()
        {
            Console.WriteLine($"{this.Name} is Swimming...");
        }
    }
}

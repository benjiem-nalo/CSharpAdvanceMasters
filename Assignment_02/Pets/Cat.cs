using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_02;
using Contracts;

namespace Pets
{
    public class Cat : Pet
    {
        public override PetEnum PetType => PetEnum.Cat;
        public override string Name => "MyNameIsCat";
        [Ability]
        public void Jump()
        {
            Console.WriteLine($"{this.Name} is Jumping...");
        }
        [Ability]
        public void Scratch()
        {
            Console.WriteLine($"{this.Name} is Scratching...");
        }
    }
}

using Assignment_02;
using Contracts;

namespace Pets
{
    public class Dog : Pet
    {
        public override PetEnum PetType => PetEnum.Dog;
        public override string Name => "MyNameIsDog";
        [Ability]
        public void Bark()
        {
            Console.WriteLine($"{this.Name} says Aw!!");
        }
        [Ability]
        public void Roll()
        {
            Console.WriteLine($"{this.Name} is Rolling...");
        }
    }
}
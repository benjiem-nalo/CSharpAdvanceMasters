using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Assignment_02;

namespace Assignment_02
{
    public class Abilities
    {
        IPet _Pet;

        public Abilities(IPet pet) 
        {
            _Pet = pet;
        }

        public void UseAbility(string ability)
        {
            var pet = _Pet.GetType();

            MethodInfo? mInfo = pet.GetMethod(ability);

            if (mInfo == null)
            {
                _Pet.Sleep();
            }
            else
            {
                // Step 3 Dynamic invoke
                object? petAbility = Activator.CreateInstance(pet);
                mInfo.Invoke(petAbility, null);
            }
        }
    }
}

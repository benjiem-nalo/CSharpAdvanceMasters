using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    public interface IPet
    {
        public PetEnum PetType { get; }
        public string Name { get; }
        public void Sleep() { }
    }
}

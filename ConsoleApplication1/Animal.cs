using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djur

{
   abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public abstract void PrintInfo();
        public override string ToString() => $"Name: {Name} Age: {Age}";
       

    }
}

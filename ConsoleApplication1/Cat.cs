using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djur
{
    class Cat : Animal
    {
        private string djur = "Katt";

        public override void PrintInfo()
        {
            Console.WriteLine($"djur:{djur}, Name:{Name}");
        }
        public override string ToString() => $"Djur: {djur} {base.ToString()}";
       
    }
}

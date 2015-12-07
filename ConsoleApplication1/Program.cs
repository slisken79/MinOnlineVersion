using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djur
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat() { Name = "Kajsa", Age = 3 };
            //cat.PrintInfo();
            Console.WriteLine(cat);
            Dog dog = new Dog() { Name = "Dogelito", Age = 8 };
            Console.WriteLine(dog);
            //dog.PrintInfo();
            Console.ReadLine();
        }
    }
}

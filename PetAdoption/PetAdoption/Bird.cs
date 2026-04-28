using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption
{
    public class Bird : Pet
    {
        public Bird() { }
        public Bird(int petid, string name, string breed, int age) : base(petid, name, breed, age)
        { }
        public override double FeeCalculation()
        {
            return 500;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine();
            Console.WriteLine(" Bird's name :" + name + ", \n Bird's ID :" + petid + ", \n Bird's breed : " + breed + ", \n Bird's age : " + age );
            Console.WriteLine();
        }
    }
}

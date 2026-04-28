using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption
{
    public class Cat : Pet
    {
        public Cat() { }
        public Cat(int petid, string name, string breed, int age) :base ( petid,  name,  breed,  age)
            { }
        public override double FeeCalculation()
        {
            if (age > 0 && age < 4)
                return 5000;
            else
                  if (age > 3 && age < 7)
                return 4000;
            else
                return 2000;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine();
            Console.WriteLine(" Cat's name :" + name + ", \n Cat's ID :" + petid + ", \n Cat's breed : " + breed + ", \n Cat's age : " + age  );
            Console.WriteLine();
        }









    }
}

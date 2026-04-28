using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption
{
    public class Dog : Pet {

        public Dog()
        {
            petid = 0; name = " "; breed = " "; age = 0;
        }


        public Dog(int petid, string name, string breed, int age ) : base (petid, name, breed, age) {}
        

        public override double FeeCalculation() {

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
            Console.WriteLine(" Dog's name :" + name + ", \n Dog's ID :" + petid + ", \n Dog's breed : " + breed + ", \n Dog's age : " +age);
            Console.WriteLine();
        }
        















    }





    }



















//  fee calculation
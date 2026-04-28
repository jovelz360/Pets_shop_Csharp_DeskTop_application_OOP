using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption
{
    public abstract class Pet
    {

        protected int petid;
        protected string name;
        protected string breed;
        protected int age;
       // protected bool availability;

        public Pet()
        {
            petid = 0; name = " "; breed = " "; age = 0; 
        }
        public Pet(int petid, string name, string breed, int age )
        {
           this.breed = breed;
            this.name = name;
            if (petid > 0)
                this.petid = petid;
            else this.petid = 0;
            if (age > 0)
                this.age = age;
            else this.age = 0;
            
        }
        public int ID
        {
            get { return petid; }
            set
            {
                if (value > 0)
                    petid = value;
                else
                { petid = 0; Console.WriteLine("EROR in ID input"); }


            }
        }
        public string Name { 
         get { return name; }
         set { name = value; }
        
        }
        public string Breed { 
         get { return breed; } set { breed = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                    age = value;
                else
                {
                    age = 0; Console.WriteLine("EROR in age input");
                }
            }
        }

      // public bool Avail { get { return availability; } set { availability = value; } }

        public abstract double FeeCalculation();
        public abstract void DisplayInfo();














    }
}
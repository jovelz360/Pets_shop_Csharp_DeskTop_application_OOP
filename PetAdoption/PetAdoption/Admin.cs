using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption
{
    public class Admin : User 
    {
        protected int AdminID;
        protected string AdminName;
        protected string AdminPassword;
        protected User user;
        protected Dog[] dogs;
        protected Cat[] cats;
        protected Bird[] birds;

        public Admin() { AdminID = 0; AdminName = " "; dogs = new Dog[25]; cats = new Cat[25]; birds = new Bird[25]; }
        public Admin(int AdminID, string AdminName , Dog[] dogs , Cat[] cats , Bird[] birds )
        {
            this.AdminID = AdminID; this.AdminName = AdminName;
            this.dogs = dogs; this.cats = cats; this.birds = birds;
        }

        public int ADMINID { get { return AdminID; } set { AdminID = value; } }

        public string ADMINNAME { get { return AdminName; } set { AdminName = value; } }

        public Dog[] Dogs { set { dogs = value; } get { return dogs; } }

        public Cat[] Cats {  set { cats = value; } get { return cats; } }

        public Bird[] Birds { set { birds = value; } get { return birds; } }


 

       
        public void DisplayAdminInfo()
        {
            Console.WriteLine("Admin's " + AdminName + " Admin's ID " + AdminID);
        }



    
    
    
    
    
    
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption
{
    public class User
    {
        protected string name;
        protected string password;
        protected int num;
        //protected Dog[] adoptd;
        //protected Cat[] adoptc;
        //protected Bird[] adoptb;
        protected static int count = 0;
        public User()
        {
            name = "";
            password = " ";
            count++;
        }
        public User(string pass, string name)
        {
            this.name = name;
            password = pass;

            count++;

        }
        public string Pass
        {
            get { return password; }
            set { password = value; }

        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void setNAME( string a )
        {
            name = a;
           
        }
        public string getNAME()
        {
            return name;
        }










    }
}



    

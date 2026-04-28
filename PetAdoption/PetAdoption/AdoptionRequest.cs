using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption
{
    public class AdoptionRequest : User
    {
        protected int RequestID;
        //protected Pet animal;
        protected Dog DOg;
        protected Cat CAt;
        protected Bird BIRd;
        protected User Human;
        protected string State;

        public AdoptionRequest() { RequestID = 0; DOG = null; CAt = null; BIRd = null; Human = null; State = "Pending"; }

        public AdoptionRequest(int requestID,Dog d,Cat c , Bird b, User human, string state)
        {
            if (requestID > 0)
                RequestID = requestID;
            else
            { RequestID = 0; Console.WriteLine("EROR in Request ID input"); }
            DOg = d;
            CAt = c;
            BIRd = b;
            Human = human;
            State = state;
        }

        public int REQUESTID {
            get { return RequestID; } 
        
            set { if (value > 0)
                { RequestID = value; }
                else
                { RequestID = 0; Console.WriteLine("EROR in Request ID input"); }
            }        
        }

        //public Pet ANIMAL 
        //    { get { return animal; } set { animal = value; } }

        public User HUMAN
        {
            get { return Human; }
            set { Human = value; }
        }

        public Dog DOG
        {
            get { return DOg; }
            set { DOg = value; }
        }
        public Cat CAT
        {
            get { return CAt; }
            set { CAt = value; }
        }
        public Bird BIRD
        {
            get { return BIRd; }
            set { BIRd = value; }
        }

        public string STATE { get { return State; } set { State = value; } }

        //public void setUserName(string name)
        //{
        //    Human.setNAME(name); 
        //}
        //public string getUserName()
        //{
        //    return Human.getNAME();
        //}





        //public void DisplayRequestInfo()
        //{
        //    Console.WriteLine("request id :" + RequestID + "Pet name : " + animal.Name + "user name : " + Human.Name + "pet state : " + State);
        //}













    }

}

using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.IO;
using System.ComponentModel.Design;

namespace PetAdoption
{

    public static class program
    {
        static Dog[] avdogs = new Dog[maxd];
        static Cat[] avcats = new Cat[maxc];
        static Bird[] avbirds = new Bird[maxb];
        const int maxd = 25;
        const int maxc = 25;
        const int maxb = 25;
        static int dog_count;
        static int cat_count;
        static int bird_count;
        static AdoptionRequest[] DogRq = new AdoptionRequest[400];
        static AdoptionRequest[] CatRq = new AdoptionRequest[400];
        static AdoptionRequest[] BirdRq = new AdoptionRequest[400];
        static User[] users = new User[20];
        static int user_count ; 
        static int dog_rq_count;
        static int cat_rq_count;
        static int bird_rq_count;
        const string file = " pet.txt";
        static string u;
        static Admin john = new Admin();
        static User gerges = new User();
        public static void Main(String[] args)
        {
            Load();
            john.Name = "john";john.Pass = "1234";
            if (users[0] != john)
            {
                users[0] = john;
                user_count++;
            }
            
            Console.Write("ENTER your username :");
            u = Console.ReadLine();
            Console.Write("ENTER your password : ");
            string p = Console.ReadLine();
            int choice;
            if (u.Equals("john") && p.Equals("1234"))
            {
                Console.WriteLine("WELCOME ADMIN");
                do
                {
                    try
                    {
                        Console.WriteLine("\n*****Admin accessabilties***** ");
                        Console.WriteLine("1-to add a pet press(1)");
                        Console.WriteLine("2-to delete a pet press(2)");
                        Console.WriteLine("3-to show requests press(3)");

                        Console.WriteLine("\n*****uesr accessabilties*****");
                        Console.WriteLine("4-view available pets press(4)");
                        Console.WriteLine("5-submit adoption request press(5)");
                        Console.WriteLine("6-Exit and save press(6)");
                        Console.Write("what do you want to do : ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                AddPet();
                                break;
                            case 2:
                                DeletePet();
                                break;
                            case 3:
                                ShowRq();
                                break;
                            case 4:
                                ViewAv();
                                break;
                            case 5:
                                Request();
                                break;
                            case 6:
                                Exit();
                                break;
                            default:
                                Console.WriteLine("invalid choice , enter number from 1 - 8 plz");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("invaild input , plz enter a valid number .");
                        choice = 0;
                    }
                }
                while (choice != 8);
            }
            else
            {
                bool userExists = false;

                //  index 1 to skip admin (users[0])
                for (int i = 1; i < user_count; i++)
                {
                    if (users[i] != null && users[i].Name != null && users[i].Pass != null)
                    {
                        if (users[i].Name.Equals(u) && users[i].Pass.Equals(p))
                        {
                            userExists = true;
                            break;
                        }
                    }
                }

                
                if (!userExists)
                {
                    gerges.Name = u;
                    gerges.Pass = p;
                    users[user_count] = gerges;
                    user_count++;
                    Console.WriteLine("New user created successfully.");
                }
                else
                {
                    Console.WriteLine("Welcome back!");
                }



                Console.WriteLine("Welcome user " + u);
                do
                {
                    try
                    {

                        Console.WriteLine("\n*****uesr accessabilties*****");
                        Console.WriteLine("1-view available pets press(1)");
                        Console.WriteLine("2-submit adoption request press(2)");
                        Console.WriteLine("3-Exit and save press(3)");
                        Console.Write("what do you want to do : ");
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                ViewAv();
                                break;
                            case 2:
                                Request();
                                break;
                            case 3:
                                Exit();
                                break;
                            default:
                                Console.WriteLine("invalid choice , enter number from 1 - 4 plz");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("invaild input , plz enter a valid number .");
                        choice = 0;
                    }
                }
                while (choice != 4);
            }

        }


        static void AddPet()
        {
            int c;
            do
            {
                try
                {
                    Console.WriteLine("*********************************************************************");
                    Console.WriteLine("What kind of Pet u wanna add !");
                    Console.WriteLine("1- press (1) to add Dog");
                    Console.WriteLine("2- press (2) to add cat");
                    Console.WriteLine("3- press (3) to add bird");
                    Console.WriteLine("4- press(4) to go back to the main menu");
                    Console.Write("Enter your choice : ");
                    c = int.Parse(Console.ReadLine());
                    switch (c)
                    {
                        case 1:
                            ADD_dog();
                            break;
                        case 2:
                            ADD_cat();
                            break;
                        case 3:
                            ADD_bird();
                            break;
                        case 4:
                            Console.WriteLine("going back to the main ...");
                            return;
                        default:
                            Console.WriteLine("EROR , chosse number 1 - 3");
                            break;
                    }

                }
                catch (FormatException) { Console.WriteLine("invalid input , enter number from 1 - 3"); c = 0; }
            }
            while (c != 4);
        }

        static void ADD_dog()
        {
            if (dog_count >= maxd)
            { Console.WriteLine("cannot add any more dogs, u have reached the limit"); return; }

            try
            {
                Dog x = new Dog();
                Console.WriteLine("========================================================================");
                Console.Write("Enter dog's ID : ");
                x.ID = int.Parse(Console.ReadLine());
                Console.Write("Enter dog's name : ");
                x.Name = Console.ReadLine();
                Console.Write("Enter dog's breed : ");
                x.Breed = Console.ReadLine();
                Console.Write("Enter dog's age : ");
                x.Age = int.Parse(Console.ReadLine());
                avdogs[dog_count] = x;
                dog_count++;

                Console.WriteLine("Dog added successfully");

            }
            catch (FormatException) { Console.WriteLine("EROR in input"); }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }

        static void ADD_cat()
        {
            if (cat_count >= maxd)
            { Console.WriteLine("cannot add any more cat, u have reached the limit"); return; }

            try
            {
                Cat y = new Cat();
                Console.WriteLine("========================================================================");
                Console.Write("Enter cat's ID : ");
                y.ID = int.Parse(Console.ReadLine());
                Console.Write("Enter cat's name : ");
                y.Name = Console.ReadLine();
                Console.Write("Enter cat's breed : ");
                y.Breed = Console.ReadLine();
                Console.Write("Enter cat's age : ");
                y.Age = int.Parse(Console.ReadLine());
                avcats[cat_count] = y;
                cat_count++;

                Console.WriteLine("cat added successfully");
            }
            catch (FormatException) { Console.WriteLine("EROR in input"); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        static void ADD_bird()
        {
            if (bird_count >= maxd)
            { Console.WriteLine("cannot add any more Bird, u have reached the limit"); return; }

            try
            {
                Bird z = new Bird();
                Console.WriteLine("========================================================================");
                Console.Write("Enter Bird's ID : ");
                z.ID = int.Parse(Console.ReadLine());
                Console.Write("Enter Bird's name : ");
                z.Name = Console.ReadLine();
                Console.Write("Enter Bird's breed : ");
                z.Breed = Console.ReadLine();
                Console.Write("Enter Bird's age : ");
                z.Age = int.Parse(Console.ReadLine());
                avbirds[bird_count] = z;
                bird_count++;

                Console.WriteLine("bird added successfully");
            }
            catch (FormatException) { Console.WriteLine("EROR in input"); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }


        static void ViewAv()
        {
            int c;
            do
            {
                try
                {
                    Console.WriteLine("**********************************************************************");
                    Console.WriteLine("1- press (1) to view available dogs ");
                    Console.WriteLine("2- press (2) to view available cats ");
                    Console.WriteLine("3- press (3) to view available birds ");
                    Console.WriteLine("4- press (4) to go back to the main menu ");
                    Console.Write("Enter your choice : ");
                    c = int.Parse(Console.ReadLine());

                    switch (c)
                    {
                        case 1:
                            for (int i = 0; i < dog_count; i++)
                            {
                                Console.WriteLine();
                                avdogs[i].DisplayInfo();
                            }
                            break;
                        case 2:
                            for (int i = 0; i < cat_count; i++)
                            {
                                avcats[i].DisplayInfo();
                            }
                            break;
                        case 3:
                            for (int i = 0; i < bird_count; i++)
                            {
                                avbirds[i].DisplayInfo();
                            }
                            break;
                        case 4:
                            Console.WriteLine("going back to main menu ...");
                            return;
                        default:
                            Console.WriteLine("invalid input enter number 1 - 4");
                            break;
                    }
                }
                catch (FormatException) { Console.WriteLine("EROR in input enter valid number "); c = 0; }

            }
            while (c != 4);
        }


        static void DeletePet()
        {
            int ch;
            Console.WriteLine();
            do
            {
                try
                {
                    Console.WriteLine("**********************************************************************");
                    Console.WriteLine("what type of pet you want to delete ?");
                    Console.WriteLine("1-press (1) to delete a dog .");
                    Console.WriteLine("2-press (2) to delete a cat . ");
                    Console.WriteLine("3-press (3) to delete a bird .");
                    Console.WriteLine("4-press (4) to go back to the main menu .");
                    Console.Write("Enter your choice : ");
                    ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            DeleteDog();
                            break;
                        case 2:
                            DeleteCat();
                            break;
                        case 3:
                            DeleteBird();
                            break;
                        case 4:
                            Console.WriteLine("going back to the main menu ...");
                            return;
                        default:
                            Console.WriteLine("Enter valid neumber plz !");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("EROR , plz enter number from 1 - 4 ");
                    ch = 0;
                }
            }
            while (ch != 4);
        }

        static void DeleteDog()
        {

            try
            {
                Console.WriteLine("========================================================================");
                Console.Write("Enter the Dog's ID you want to delete : ");
                int DD = int.Parse(Console.ReadLine());

                int DDindex = -1;

                for (int i = 0; i < dog_count; i++)
                {
                    if (avdogs[i].ID == DD)
                    {
                        DDindex = i;
                        break;
                    }
                }

                if (DDindex != -1)
                {
                    for (int i = DDindex; i < dog_count - 1; i++)
                    {
                        avdogs[i] = avdogs[i + 1];
                    }
                    dog_count--;
                    Console.WriteLine("Dog deleted successfully .");
                }
                else
                { Console.WriteLine("Dog not found try again "); }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return; }
        }




        static void DeleteCat()
        {
            try
            {
                Console.WriteLine("========================================================================");
                Console.Write("Enter the Cat's ID you want to delete : ");
                int DC = int.Parse(Console.ReadLine());

                int DCindex = -1;

                for (int i = 0; i < cat_count; i++)
                {
                    if (avcats[i].ID == DC)
                    {
                        DCindex = i;
                        break;
                    }
                }

                if (DCindex != -1)
                {
                    for (int i = DCindex; i < cat_count - 1; i++)
                    {
                        avcats[i] = avcats[i + 1];
                    }
                    cat_count--;
                    Console.WriteLine("Cat deleted successfully .");
                }
                else
                { Console.WriteLine("Cat not found try again "); }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return; }
        }



        static void DeleteBird()
        {
            try
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("Enter the Bird's ID you want to delete : ");
                int DB = int.Parse(Console.ReadLine());

                int DBindex = -1;

                for (int i = 0; i < bird_count; i++)
                {
                    if (avbirds[i].ID == DB)
                    {
                        DBindex = i;
                        break;
                    }
                }

                if (DBindex != -1)
                {
                    for (int i = DBindex; i < bird_count - 1; i++)
                    {
                        avbirds[i] = avbirds[i + 1];
                    }
                    dog_count--;
                    Console.WriteLine("Bird deleted successfully .");
                }
                else
                { Console.WriteLine("Bird not found try again "); }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return; }
        }



        static void Request()
        {
            int ch;
            Console.WriteLine();
            do
            {
                try
                {
                    Console.WriteLine("**********************************************************************");
                    Console.WriteLine("what type of pet you want to buy ?");
                    Console.WriteLine("1-press (1) to request buying a Dog .");
                    Console.WriteLine("2-press (2) to request buting a Cat . ");
                    Console.WriteLine("3-press (3) to request buying a bird .");
                    Console.WriteLine("4-press (4) to go back to the main menu .");
                    Console.Write("Enter your choice : ");
                    ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            RQDog();
                            break;
                        case 2:
                            RQCat();
                            break;
                        case 3:
                            RQBird();
                            break;
                        case 4:
                            Console.WriteLine("going back to the main menu ...");
                            return;
                        default:
                            Console.WriteLine("Enter valid neumber plz !");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("EROR , plz enter number from 1 - 4 ");
                    ch = 0;
                }
            }
            while (ch != 4);
        }

        static void RQDog() /////////////////////////////////
        {
            try
            {
                Console.WriteLine();
            if (avdogs.Length < 0 || avdogs == null)
            {
                Console.WriteLine("There is no dogs right now come check later ");
                return;
            }


            Console.WriteLine("======================================================");
            Console.WriteLine("this is the available Dogs we have :-");
            for (int i = 0; i < dog_count; i++)
            {
                Console.WriteLine();
                avdogs[i].DisplayInfo();
            }

            AdoptionRequest a = new AdoptionRequest();
            Console.Write("Enter the Dog's ID you want to buy : ");
            int y = int.Parse(Console.ReadLine());

            int userIndex = -1; //0
            for (int i = 0; i < user_count; i++) //i=0
            {
                if (users[i] != null && users[i].Name.Equals(u))//users[i].Name == u
                    {
                    userIndex = i;
                    break;
                }
            }

            int dogIndex = -1;
            for (int i = 0; i < dog_count; i++)
            {
                if (avdogs[i].ID == y)
                {
                    dogIndex = i;
                }
            }
            //a.setUserName(u);
            a.REQUESTID = y;
            a.DOG = avdogs[dogIndex]; //a.ANIMAl
            a.HUMAN = users[userIndex];
            DogRq[dog_rq_count] = a;
            dog_rq_count++;
            double b = avdogs[dogIndex].FeeCalculation();
            Console.WriteLine();
            Console.WriteLine("your request has been added successfully\n this dog will cost you " + b + "L.E");
        }
            catch (Exception e) { Console.WriteLine(e.Message); return; }


        }

        static void RQCat()///////////////////////////
        {
            try
            {
                Console.WriteLine();

                if (avcats.Length < 0 || avcats == null)
                {
                    Console.WriteLine("There is no cats right now come check later");
                    return;
                }

                Console.WriteLine("======================================================");
                Console.WriteLine("this is the available Cats we have :-");
                for (int i = 0; i < cat_count; i++)
                {
                    Console.WriteLine();
                    avcats[i].DisplayInfo();
                }

                AdoptionRequest a = new AdoptionRequest();
                Console.Write("Enter the Cat's ID you want to buy : ");
                int y = int.Parse(Console.ReadLine());

                int userIndex = -1; 
                for (int i = 0; i < user_count; i++)
                {
                    if (users[i] != null && users[i].Name.Equals(u))
                    {
                        userIndex = i;
                        break;
                    }
                }

                int catIndex = -1;
                for (int i = 0; i < cat_count; i++)
                {
                    if (avcats[i].ID == y)
                    {
                        catIndex = i;
                    }
                }
                //a.HUMAN.Name = u;
                a.REQUESTID = y;
                a.CAT = avcats[catIndex]; // a.ANIMAL
                a.HUMAN = users[userIndex];
                CatRq[cat_rq_count] = a;
                cat_rq_count++;

                double b = avcats[catIndex].FeeCalculation();
                Console.WriteLine();
                Console.WriteLine("your request has been added successfully\n this cat will cost you " + b + "L.E");
            }
            catch (Exception e) { Console.WriteLine(e.Message); return; }
        }


        static void RQBird()/////////////////////////
        {
            try
            {
                Console.WriteLine();

                if (avbirds.Length < 0 || avbirds == null)
                {
                    Console.WriteLine("There is no birds right now come check later");
                    return;
                }

                Console.WriteLine("======================================================");
                Console.WriteLine("this is the available Birds we have :-");
                for (int i = 0; i < bird_count; i++)
                {
                    Console.WriteLine();
                    avbirds[i].DisplayInfo();
                }

                AdoptionRequest a = new AdoptionRequest();
                Console.Write("Enter the Bird's ID you want to buy : ");
                int y = int.Parse(Console.ReadLine());

                int userIndex = -1; 
                for (int i = 0; i < user_count; i++)
                {
                    if (users[i] != null && users[i].Name.Equals(u))
                    {
                        userIndex = i;
                        break;
                    }
                }

                int birdIndex = -1;
                for (int i = 0; i < bird_count; i++)
                {
                    if (avbirds[i].ID == y)
                    {
                        birdIndex = i;
                    }
                }
                //a.HUMAN.Name = u;
                a.REQUESTID = y;
                a.BIRD = avbirds[birdIndex]; // a.ANIMAL
                a.HUMAN = users[userIndex];
                BirdRq[bird_rq_count] = a;
                bird_rq_count++;
                double b = avbirds[birdIndex].FeeCalculation();
                Console.WriteLine();
                Console.WriteLine("your request has been added successfully\n this bird will cost you " + b + "L.E");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return; }

        }

        static void ShowRq()
        {
            int c;
            do
            {
                try
                {
                    Console.WriteLine("1-press(1) to show Dog requests .");
                    Console.WriteLine("2-press(2) to show Cat requests .");
                    Console.WriteLine("3-press(3) to show Bird requests .");
                    Console.WriteLine("4-press(4) to go back to the main menu");
                    Console.Write("Enter your choice : ");
                    c = int.Parse(Console.ReadLine());
                    switch (c)
                    {
                        case 1:
                            ShowDRq();
                            break;
                        case 2:
                            ShowCRq();
                            break;
                        case 3:
                            ShowBRq();
                            break;
                        case 4:
                            Console.WriteLine("going back to main menu ...");
                            break;
                        default:
                            Console.WriteLine("Enter valid number 1 - 4");
                            break;
                    }
                }
                catch (FormatException) { Console.WriteLine("Enter number from 1 - 4"); c = 0; }

            }
            while (c != 4);
        }

        static void ShowDRq()////////////////////////////////////////
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Dog Requests");
                for (int i = 0; i < dog_rq_count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Request number " + (i + 1));
                    Console.WriteLine("Request details :\n" + "Request ID : " + DogRq[i].REQUESTID + "\n" + "User's name :" + DogRq[i].HUMAN.Name + "\n" + "Dog's details : " + "\n" + "Dog's name : " + DogRq[i].DOG.Name + "\n" + "Dog's ID : " + DogRq[i].DOG.ID + "\n" + "Dog's age : " + DogRq[i].DOG.Age + "\n" + "Dog's breed : " + DogRq[i].DOG.Breed);
                    Console.WriteLine("-------------------------------------------------------");

                }
                Console.WriteLine();
                Console.WriteLine("Enter the ID of the request you want to Approve or Reject : ");
                int b = int.Parse(Console.ReadLine());

                int a = -1;
                for (int i = 0; i < dog_rq_count; i++)
                {
                    if (DogRq[i].REQUESTID == b)
                    {
                        a = i; break;
                    }
                }
                if (a != -1)
                {

                    Console.WriteLine();
                    Console.WriteLine("press (true) to approve , press (false) to reject");
                    bool c = bool.Parse(Console.ReadLine());
                    if (c == true)
                    {
                        int DRindex = -1;
                        for (int i = 0; i < dog_rq_count; i++)
                        {
                            if (DogRq[i].REQUESTID == a)
                            {
                                DRindex = i; break;
                            }
                        }
                        if (DRindex != -1)
                        {
                            for (int i = DRindex; i < dog_rq_count - 1; i++)
                            {
                                DogRq[i] = DogRq[i + 1];
                            }

                        }
                        dog_rq_count--;
                        /////dog delete
                        int DDindex = -1;

                        for (int i = 0; i < dog_count; i++)
                        {
                            if (avdogs[i].ID == DogRq[a].REQUESTID)
                            {
                                DDindex = i;
                                break;
                            }
                        }

                        if (DDindex != -1)
                        {
                            for (int i = DDindex; i < dog_count - 1; i++)
                            {
                                avdogs[i] = avdogs[i + 1];
                            }
                            dog_count--;

                        }
                        Console.WriteLine();
                        Console.WriteLine("The request has been Approved successfully");
                    }
                    else
                    {
                        int DRindex = -1;
                        for (int i = 0; i < dog_rq_count; i++)
                        {
                            if (DogRq[i].REQUESTID == a)
                            {
                                DRindex = i; break;
                            }
                        }
                        if (DRindex != -1)
                        {
                            for (int i = DRindex; i < dog_rq_count - 1; i++)
                            {
                                DogRq[i] = DogRq[i + 1];
                            }
                        }
                        dog_rq_count--;
                        Console.WriteLine();
                        Console.WriteLine("The request has been Rejected successfully");
                    }

                }
                else { Console.WriteLine("wrong ID try again "); }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        static void ShowCRq()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Cat Requests");
                for (int i = 0; i < cat_rq_count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Request number " + (i + 1));
                    Console.WriteLine("Request details :\n" + "Request ID : " + CatRq[i].REQUESTID + "\n" + "User's name :" + CatRq[i].HUMAN.Name + "\n" + "Cat's details : " + "\n" + "Cat's name : " + CatRq[i].CAT.Name + "\n" + "Cat's ID : " + CatRq[i].CAT.ID + "\n" + "Cat's age : " + CatRq[i].CAT.Age + "\n" + "Cat's breed : " + CatRq[i].CAT.Breed);
                    Console.WriteLine("-------------------------------------------------------");

                }
                Console.WriteLine();
                Console.WriteLine("Enter the ID of the request you want to Approve or Reject : ");
                int b = int.Parse(Console.ReadLine());

                int a = -1;
                for (int i = 0; i < cat_rq_count; i++)
                {
                    if (CatRq[i].REQUESTID == b)
                    {
                        a = i; break;
                    }
                }
                if (a != -1)
                {
                    Console.WriteLine();
                    Console.WriteLine("press (true) to approve , press (false) to reject");
                    bool c = bool.Parse(Console.ReadLine());
                    if (c == true)
                    {
                        int DRindex = -1;
                        for (int i = 0; i < cat_rq_count; i++)
                        {
                            if (CatRq[i].REQUESTID == a)
                            {
                                DRindex = i; break;
                            }
                        }
                        if (DRindex != -1)
                        {
                            for (int i = DRindex; i < cat_rq_count - 1; i++)
                            {
                                CatRq[i] = CatRq[i + 1];
                            }

                        }
                        cat_rq_count--;
                        /////dog delete
                        int DDindex = -1;

                        for (int i = 0; i < cat_count; i++)
                        {
                            if (avcats[i].ID == CatRq[a].REQUESTID)
                            {
                                DDindex = i;
                                break;
                            }
                        }

                        if (DDindex != -1)
                        {
                            for (int i = DDindex; i < cat_count - 1; i++)
                            {
                                avcats[i] = avcats[i + 1];
                            }
                            cat_count--;

                        }
                        Console.WriteLine();
                        Console.WriteLine("The request has been Approved successfully");
                    }
                    else
                    {
                        int DRindex = -1;
                        for (int i = 0; i < cat_rq_count; i++)
                        {
                            if (CatRq[i].REQUESTID == a)
                            {
                                DRindex = i; break;
                            }
                        }
                        if (DRindex != -1)
                        {
                            for (int i = DRindex; i < cat_rq_count - 1; i++)
                            {
                                CatRq[i] = CatRq[i + 1];
                            }
                        }
                        cat_rq_count--;
                        Console.WriteLine();
                        Console.WriteLine("The request has been Rejected successfully");
                    }
                }
                else { Console.WriteLine("Wrong ID try again !"); }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }

        static void ShowBRq()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Bird Requests");
                for (int i = 0; i < bird_rq_count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Request number " + (i + 1));
                    Console.WriteLine("Request details :\n" + "Request ID" + BirdRq[i].REQUESTID + "\n" + "User's name :" + BirdRq[i].HUMAN.Name + "\n" + "Bird's details : " + "\n" + "Bird's name : " + BirdRq[i].BIRD.Name + "\n" + "Bird's ID : " + BirdRq[i].BIRD.ID + "\n" + "Bird's age : " + BirdRq[i].BIRD.Age + "\n" + "Bird's breed : " + BirdRq[i].BIRD.Breed);
                    Console.WriteLine("-------------------------------------------------------");

                }
                Console.WriteLine();
                Console.WriteLine("Enter the ID of the request you want to Approve or Reject : ");
                int b = int.Parse(Console.ReadLine());

                int a = -1;
                for (int i = 0; i < bird_rq_count; i++)
                {
                    if (BirdRq[i].REQUESTID == b)
                    {
                        a = i; break;
                    }
                }
                if (a != -1)
                {
                    Console.WriteLine();
                    Console.WriteLine("press (true) to approve , press (false) to reject");
                    bool c = bool.Parse(Console.ReadLine());
                    if (c == true)
                    {
                        int DRindex = -1;
                        for (int i = 0; i < bird_rq_count; i++)
                        {
                            if (BirdRq[i].REQUESTID == a)
                            {
                                DRindex = i; break;
                            }
                        }
                        if (DRindex != -1)
                        {
                            for (int i = DRindex; i < bird_rq_count - 1; i++)
                            {
                                BirdRq[i] = BirdRq[i + 1];
                            }

                        }
                        bird_rq_count--;
                        int DDindex = -1;

                        for (int i = 0; i < bird_count; i++)
                        {
                            if (avbirds[i].ID == BirdRq[a].REQUESTID)
                            {
                                DDindex = i;
                                break;
                            }
                        }

                        if (DDindex != -1)
                        {
                            for (int i = DDindex; i < bird_count - 1; i++)
                            {
                                avbirds[i] = avbirds[i + 1];
                            }
                            bird_count--;

                        }
                        Console.WriteLine();
                        Console.WriteLine("The request has been Approved successfully");
                    }
                    else
                    {
                        int DRindex = -1;
                        for (int i = 0; i < bird_rq_count; i++)
                        {
                            if (BirdRq[i].REQUESTID == a)
                            {
                                DRindex = i; break;
                            }
                        }
                        if (DRindex != -1)
                        {
                            for (int i = DRindex; i < bird_rq_count - 1; i++)
                            {
                                BirdRq[i] = BirdRq[i + 1];
                            }
                        }
                        bird_rq_count--;
                        Console.WriteLine();
                        Console.WriteLine("The request has been Rejected successfully");
                    }
                }
                else { Console.WriteLine("Wrong ID try again !"); }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
      

        static void Exit()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(file, false)) // false = overwrite
                {
                    writer.WriteLine("[DOG_REQUESTS]");
                    SaveRequests(DogRq, dog_rq_count, writer);

                    writer.WriteLine("[CAT_REQUESTS]");
                    SaveRequests(CatRq, cat_rq_count, writer);

                    writer.WriteLine("[BIRD_REQUESTS]");
                    SaveRequests(BirdRq, bird_rq_count, writer);

                    writer.WriteLine("[DOGS]");
                    SaveAnimals(avdogs, dog_count, writer);

                    writer.WriteLine("[CATS]");
                    SaveAnimals(avcats, cat_count, writer);

                    writer.WriteLine("[BIRDS]");
                    SaveAnimals(avbirds, bird_count, writer);

                    writer.WriteLine("[USERS]");
                    SaveUsers(users, user_count, writer);
                }

                Console.WriteLine("All data saved successfully to " + file);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving data: " + ex.Message);
            }
        }

        static void SaveRequests(dynamic[] requests, int rq_count, StreamWriter writer)
        {
            for (int i = 0; i < rq_count; i++)
            {
                if (requests[i] is AdoptionRequest dog && dog.DOG != null)
                {
                    writer.WriteLine($"{dog.HUMAN.Name},{dog.HUMAN.Pass},{dog.DOG.ID},{dog.DOG.Name},{dog.DOG.Breed},{dog.DOG.Age},{dog.REQUESTID}");
                }
                else if (requests[i].CAT != null)
                {
                    writer.WriteLine($"{requests[i].HUMAN.Name},{requests[i].HUMAN.Pass},{requests[i].CAT.ID},{requests[i].CAT.Name},{requests[i].CAT.Breed},{requests[i].CAT.Age},{requests[i].REQUESTID}");
                }
                else if (requests[i].BIRD != null)
                {
                    writer.WriteLine($"{requests[i].HUMAN.Name},{requests[i].HUMAN.Pass},{requests[i].BIRD.ID},{requests[i].BIRD.Name},{requests[i].BIRD.Breed},{requests[i].BIRD.Age},{requests[i].REQUESTID}");
                }
                writer.WriteLine("END");
            }
        }

        static void SaveAnimals(object[] animals, int count, StreamWriter writer)
        {
            for (int i = 0; i < count; i++)
            {
                if (animals[i] is Dog dog)
                {
                    writer.WriteLine($"{dog.ID},{dog.Name},{dog.Age},{dog.Breed}");
                }
                else if (animals[i] is Cat cat)
                {
                    writer.WriteLine($"{cat.ID},{cat.Name},{cat.Age},{cat.Breed}");
                }
                else if (animals[i] is Bird bird)
                {
                    writer.WriteLine($"{bird.ID},{bird.Name},{bird.Age},{bird.Breed}");
                }
                writer.WriteLine("END");
            }
        }

        static void SaveUsers(User[] uusers, int count, StreamWriter writer)
        {
            for (int i = 0; i < count; i++) // i = 1 ;
            {
                if (uusers[i] != null)
                {
                    writer.WriteLine($"{uusers[i].Name},{uusers[i].Pass}");
                }
                writer.WriteLine("END");
            }
        }
        static void Load()
        {
            try
            {
                if (File.Exists(file))
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        string line;
                        string section = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.StartsWith("[") && line.EndsWith("]"))
                            {
                                section = line;
                                continue;
                            }

                            if (line == "END") continue;

                            string[] parts = line.Split(',');

                            switch (section)
                            {
                                case "[DOGS]":
                                    if (dog_count < 25)
                                    {
                                        Dog dog = new Dog
                                        {
                                            ID = int.Parse(parts[0]),
                                            Name = parts[1],
                                            Age = int.Parse(parts[2]),
                                            Breed = parts[3]
                                        };
                                        avdogs[dog_count++] = dog;
                                    }
                                    break;

                                case "[CATS]":
                                    if (cat_count < 25)
                                    {
                                        Cat cat = new Cat
                                        {
                                            ID = int.Parse(parts[0]),
                                            Name = parts[1],
                                            Age = int.Parse(parts[2]),
                                            Breed = parts[3]
                                        };
                                        avcats[cat_count++] = cat;
                                    }
                                    break;

                                case "[BIRDS]":
                                    if (bird_count < 25)
                                    {
                                        Bird bird = new Bird
                                        {
                                            ID = int.Parse(parts[0]),
                                            Name = parts[1],
                                            Age = int.Parse(parts[2]),
                                            Breed = parts[3]
                                        };
                                        avbirds[bird_count++] = bird;
                                    }
                                    break;

                                case "[USERS]":
                                    if (user_count < 20)
                                    {
                                        User user = new User
                                        {
                                            Name = parts[0],
                                            Pass = parts[1],
                                        };
                                        users[user_count++] = user;
                                    }
                                    break;

                                case "[DOG_REQUESTS]":
                                    if (dog_rq_count < 25)
                                    {
                                        AdoptionRequest rq = new AdoptionRequest();
                                        rq.HUMAN = new User { Name = parts[0], Pass = parts[1] };
                                        rq.DOG = new Dog
                                        {
                                            ID = int.Parse(parts[2]),
                                            Name = parts[3],
                                            Breed = parts[4],
                                            Age = int.Parse(parts[5])
                                        };
                                        rq.REQUESTID = int.Parse(parts[6]);
                                        DogRq[dog_rq_count++] = rq;
                                    }
                                    break;

                                case "[CAT_REQUESTS]":
                                    if (cat_rq_count < 25)
                                    {
                                        AdoptionRequest rq = new AdoptionRequest();
                                        rq.HUMAN = new User { Name = parts[0], Pass = parts[1] };
                                        rq.CAT = new Cat
                                        {
                                            ID = int.Parse(parts[2]),
                                            Name = parts[3],
                                            Breed = parts[4],
                                            Age = int.Parse(parts[5])
                                        };
                                        rq.REQUESTID = int.Parse(parts[6]);
                                        CatRq[cat_rq_count++] = rq;
                                    }
                                    break;

                                case "[BIRD_REQUESTS]":
                                    if (bird_rq_count < 25)
                                    {
                                        AdoptionRequest rq = new AdoptionRequest();
                                        rq.HUMAN = new User { Name = parts[0], Pass = parts[1] };
                                        rq.BIRD = new Bird
                                        {
                                            ID = int.Parse(parts[2]),
                                            Name = parts[3],
                                            Breed = parts[4],
                                            Age = int.Parse(parts[5])
                                        };
                                        rq.REQUESTID = int.Parse(parts[6]);
                                        BirdRq[bird_rq_count++] = rq;
                                    }
                                    break;
                            }
                        }
                    }

                    Console.WriteLine("Data loaded successfully from " + file);
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading data: " + ex.Message);
            }
        }
    }
}
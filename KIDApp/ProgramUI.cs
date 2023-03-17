
using System.Xml;
using System.Security.Cryptography;
namespace KIDApp
{
    public class ProgramUI
    {
        private readonly DeveloperRepo _devRepo = new DeveloperRepo();

        public void Run()
        {
            // AccessTheProgram();
            Menu();

        }


        private void Menu()
        {
            bool keepRunning= true;
            while(keepRunning)
            {
                Console.Clear();
                System.Console.WriteLine("Welcome to the menu. Please select an option by number:\n" +
                "1. Show all developers\n"+
                "2. Show all developer teams\n" +
                "3. Find a developer\n" +
                "4. Add a developer\n" +
                "5. Update developer info\n" +
                "6. Remove a developer\n" +
                "7. Exit program");

                string input = Console.ReadLine() ?? "";

                switch(input)
                    {
                         case "1":
                           DisplayAllDevelopers();
                            break;

                        case "2":

                        case "3":
                            Console.Clear();

                            System.Console.WriteLine("How would you would like to find a developer?\n" +
                            "1. Find by name\n" +
                            "2. Find by NOI\n" +
                            "3. All developers with access to Pluralsight\n");

                            string input2 = Console.ReadLine() ?? "";
                            switch (input2)
                            {
                                case "1":
                                    devByName();
                                    break;

                                case "2":
                                    devByNOI();
                                
                                    break;
                                case "3":
                                    //devByAccess
                                    break;
                            }
                            break;

                        case "4":
                            AddDeveloper();
                            break;
                        case "5":
                            UpdateDeveloper();
                            break;
                        case "6":
                            RemoveDeveloper();
                            break;
                        case "7":
                            System.Console.WriteLine("Goodbye");
                            keepRunning = false;
                            break;

                        default:
                            System.Console.WriteLine("Please type a valid number");
                            continueButton();
                            break;
                    }
            }
        }
            public void DisplayAllDevelopers()
            {
                Console.Clear();
                List<Developer> allDevelopers = _devRepo.GetAllDevelopers();

                int index=1;
                foreach (Developer developer in allDevelopers)
                {
                   DisplayDeveloper(developer);
                }
                continueButton();

            }

            public void devByName()
            {
                Console.Clear();

                System.Console.Write("Enter a name: ");

                string nameInput = Console.ReadLine() ?? "";

                Developer developer = _devRepo.FindDeveloperName(nameInput);

                if (developer == default)
                {
                    System.Console.WriteLine("Developer not found");
                   
                }
                else
                {
                    DisplayDeveloper(developer);
                }
                 continueButton();
            
            }


            public void devByNOI()
            {
                Console.Clear();

                System.Console.Write("Enter employee ID(6 digits): ");

                string nOIInput = Console.ReadLine() ?? "";

                int nOIInput1 = int.Parse(nOIInput);

                Developer developer = _devRepo.FindDeveloperNOI(nOIInput1);

                if (developer == default)
                {
                    System.Console.WriteLine("Developer not found");
                   
                }
                else
                {
                    DisplayDeveloper(developer);
                }
                 continueButton();
            
            }


// UPDATE DEVELOPER
            public void UpdateDeveloper ()
            {
                DisplayAllDevelopers();
                System.Console.WriteLine("What is the employee ID of the person you wish to update?");
                string oldDevInfo = Console.ReadLine();
                int oldDevInfoParsed = int.Parse(oldDevInfo);
                Developer developer= _devRepo.FindDeveloperNOI(oldDevInfoParsed);
                Console.Clear();
                System.Console.WriteLine("What would you like to change?\n"+
                "\n" +
                $"1. Name:{developer.DevName}\n"+
                $"2. Employee ID:{developer.NOI}\n" +
                $"3. Access to Pluralsight: {developer.HasPSAccess}\n" +
                "4. Cancel changes"
                );

                string userInput = Console.ReadLine();
                if (userInput != "4")
                {
                    System.Console.WriteLine("");
                    System.Console.WriteLine("What is the updated information?");
                    string newDevInfo = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            developer.DevName = newDevInfo;
                            break;
                        case "2":
                            developer.NOI = int.Parse(newDevInfo);
                            break;
                        case "3":
                            developer.HasPSAccess = newDevInfo.ToLower() == "y";
                            break;
                        
                    }
                }
                
            }

//helper method
            public void continueButton()
            {
                System.Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }


            public void DisplayDeveloper(Developer developer)
            {
                 System.Console.WriteLine($"Name: {developer.DevName}\n" +
                    $"Employee ID: {developer.NOI}\n" +
                    $"Access to Pluralsight: {developer.HasPSAccess}\n");
            }


           public void AddDeveloper()
            {
                Developer newDev = new Developer();

                System.Console.WriteLine("Enter a name: ");
                string personName =  System.Console.ReadLine(); 
                newDev.DevName = GetValidStringInput(personName);
                
                System.Console.WriteLine("Enter employee ID: ");
                newDev.NOI = int.Parse(Console.ReadLine());

                System.Console.WriteLine("Does this employee have access to Pluralsight? (y or n)");
                string personHasAccess = System.Console.ReadLine().ToLower();
                if (personHasAccess == "y")
                {
                    newDev.HasPSAccess = true;
                }
                else 
                {
                    newDev.HasPSAccess = false;
                }
                _devRepo.AddMembersToList(newDev);

            }

           public string GetValidStringInput (string InputItem)
           {
                while (string.IsNullOrWhiteSpace(InputItem))
                {
                    System.Console.WriteLine($"Please enter a valid full name");
                    InputItem = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(InputItem))
                    {
                        System.Console.WriteLine("Cannot enter blank");
                        continueButton();

                    }

                }

                return InputItem;
           }

            public void RemoveDeveloper()
            {
                Console.Clear();

                DisplayAllDevelopers();
                
                System.Console.WriteLine("Type the employee ID of the developer being deleted: ");
                
                int nOIParse = int.Parse(System.Console.ReadLine());
                bool wasRemoved = _devRepo.DeletePerson(nOIParse);
                if (wasRemoved)
                {System.Console.WriteLine("Deletion successful");}
                else{System.Console.WriteLine("Deleteion failed");}


            }



    }
}
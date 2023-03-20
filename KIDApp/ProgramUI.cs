
namespace KIDApp
{
    public class ProgramUI
    {
        private readonly DeveloperRepo _devRepo = new DeveloperRepo();
        private readonly DevTeamRepo _DevTeamRepo = new DevTeamRepo();

        public void Run()
        {
            // AccessTheProgram();
            Menu();

        }


        private void Menu()
        {
            Seed();
            bool keepRunning= true;
            while(keepRunning)
            {
                Console.Clear();
                System.Console.WriteLine("Welcome to the menu. Please select an option by number:\n" +
                "1. Open teams menu\n" +
                "2. Show all developers\n" +
                "3. Find a developer\n" +
                "4. Add a developer\n" +
                "5. Update developer info\n" +
                "6. Remove a developer\n" +
                "7. Exit program");

                string input = Console.ReadLine() ?? "";

                switch(input)
                    {
                        case "1":
                            bool teamMenuRunning = true;
                            while (teamMenuRunning)
                            {
                                Console.Clear();

                                System.Console.WriteLine("Welcome to the teams menu\n" +
                                "Select an option\n" +
                                "1. Display all teams\n" +
                                "2. Find team by NOI\n" +
                                "3. Create a new team\n" +
                                "4. Update a team\n"+
                                "5. Delete a team\n"+
                                "6. Add a developer to a team\n"+
                                "7. Remove a developer from a team\n"+
                                "8. Exit teams menu\n"
                                );

                                string input5 = Console.ReadLine() ?? "";
                                switch (input5)
                                {
                                    case "1":
                                        DisplayAllTeams();
                                        break;

                                    case "2":
                                       DisplayTeamByID();
                                        break;

                                    case "3":
                                        CreateNewTeam();
                                        break;

                                    case "4":
                                        UpdateTeamInfo();
                                        break;
                                        
                                    case "5":
                                        RemoveDevTeam();
                                        break;

                                    case "6":
                                        AddDevToTeam();
                                        break;

                                    case "7":
                                        RemoveDevFromTeam();
                                        break;

                                    case "8":
                                        System.Console.WriteLine("Exiting teams menu");
                                        teamMenuRunning =false;
                                        continueButton();
                                        break;
                                }
                            }    
                            break;
                            
                        case "2":
                            DisplayAllDevelopers();
                            break;

                        case "3":
                            bool menu2Running = true;

                            while(menu2Running)
                            {
                                Console.Clear();
                                System.Console.WriteLine("How would you would like to find a developer?\n" +
                                "1. Find by name\n" +
                                "2. Find by NOI\n" +
                                "3. All developers with access to Pluralsight\n" +
                                "4. Cancel");

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
                                        DisplayMembersWithAccess();
                                        break;
                                    case "4":
                                        menu2Running = false;
                                        break;

                                    default:
                                    System.Console.WriteLine("Please type a valid number");
                                    continueButton();
                                    break;
                                }
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

                foreach (Developer developer in allDevelopers)
                {
                   DisplayDeveloper(developer);
                }

                continueButton();
            }

            public void DisplayAllTeams()
            {
                Console.Clear();
                List<DevTeam> allDevTeams =  _DevTeamRepo.GetTeamList();

                foreach (DevTeam devTeam in allDevTeams)
                {
                    DisplayDevTeam(devTeam);
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

                string userInput = GetValidStringInput(Console.ReadLine());
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
                        case "4":
                            break;
                        Default:
                            System.Console.WriteLine("Please type a valid number");
                            continueButton();
                            break;
                        
                    }
                }
                
            }

            public void UpdateTeamInfo()
            {
                Console.Clear();
                DisplayAllTeams();
                System.Console.WriteLine("What is the ID of the team you wish to update?");
                string oldTeamNOI = Console.ReadLine();
                int oldTeamNOIParsed = int.Parse(oldTeamNOI);
                DevTeam devTeam = _DevTeamRepo.GetTeamByNOI(oldTeamNOIParsed);
                Console.Clear();
                System.Console.WriteLine("What would you like to change?\n"+
                "\n" +
                $"1. Team Name:{devTeam.TeamName}\n"+
                $"2. Team ID:{devTeam.TeamNOI}\n" +
                "3. Cancel changes"
                );

                string UserInput2 = GetValidStringInput(Console.ReadLine());
                int UserInput3 = int.Parse(UserInput2);
                if(UserInput3 < 4)
                {

                    System.Console.WriteLine("");
                    System.Console.WriteLine("What is the updated information?");
                    bool keepRunningUpdate = true;
                    while(keepRunningUpdate)
                    {
                        string newTeamInfo2 = Console.ReadLine();
                        switch (UserInput2)
                        {
                            case "1":
                                devTeam.TeamName = newTeamInfo2;
                                System.Console.WriteLine("Team name has been changed");
                                continueButton();
                                keepRunningUpdate = false;
                                break;

                            case "2":
                                devTeam.TeamNOI = int.Parse(newTeamInfo2);
                                System.Console.WriteLine("Team ID has been changed");
                                continueButton();
                                keepRunningUpdate = false;
                                break;

                            case "3":
                                System.Console.WriteLine("Changes Canceled");
                                keepRunningUpdate = false;
                                break;

                            default:
                                System.Console.WriteLine("Please type a valid input");
                                continueButton();
                                break;
                        }
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

            public void DisplayDevTeam(DevTeam devTeam)
            {
                System.Console.WriteLine($"Team Name: {devTeam.TeamName}\n" +
                $"Team ID: {devTeam.TeamNOI}\n" +
                "Members: ");
                System.Console.WriteLine($"{DisplayListOfTeamMembers(devTeam)}");
            }

            public void DisplayTeamByID()
            {
                Console.Clear();
                System.Console.WriteLine("Enter the ID of the team you wish to find: ");
                string inputTeamID = Console.ReadLine() ?? "";
                int inputTeamID2 = int.Parse(inputTeamID);
                DevTeam devTeam = _DevTeamRepo.GetTeamByNOI(inputTeamID2);
                if (devTeam == default)
                {
                    System.Console.WriteLine("Team not found");
                    continueButton();
                } 
                else 
                {
                    DisplayDevTeam(devTeam);    
                }
                
                continueButton();
            }


           public void AddDeveloper()
            {
                Developer newDev = new Developer();

                System.Console.WriteLine("Enter a name: ");
                string personName =  System.Console.ReadLine(); 
                newDev.DevName = GetValidStringInput(personName);
                Console.Clear();
                System.Console.WriteLine("Enter employee ID: ");
                newDev.NOI = int.Parse(Console.ReadLine());
                Console.Clear();
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

                _devRepo.AddToDevList(newDev);
                System.Console.WriteLine("\n" + 
                "Developer has been added");
                continueButton();

            }

            public void CreateNewTeam()
            {
                Console.Clear();
                DevTeam newTeam = new DevTeam();

                System.Console.WriteLine("Enter team name:");
                string inputTeamName = Console.ReadLine();
                newTeam.TeamName = GetValidStringInput(inputTeamName);
                

                System.Console.WriteLine("Enter team ID:");
                newTeam.TeamNOI = int.Parse(Console.ReadLine());
                _DevTeamRepo.AddTeamToList(newTeam);
                System.Console.WriteLine("New team has been created");
                continueButton();

            }


            public void AddDevToTeam()
            {
                Console.Clear();
                DisplayAllTeams();

                System.Console.WriteLine("What is the ID of the team would you like to add a developer to?");
                int inputTeamID3 = int.Parse(Console.ReadLine());
                if (_DevTeamRepo.VerifyTeam(inputTeamID3))
                {
                    Console.Clear();
                    DisplayAllDevelopers();
                    System.Console.WriteLine("Type the ID of the developer you would like to add");
                    int devToAdd = int.Parse(Console.ReadLine());
                    if (_devRepo.VerifyDev(devToAdd))
                    {
                        DevTeam teamSelect = _DevTeamRepo.GetTeamByNOI(inputTeamID3);
                        Developer addDev = _devRepo.FindDeveloperNOI(devToAdd);
                        teamSelect.AddDevToTeam(addDev);
                        System.Console.WriteLine("Developer has been added to team");
                        continueButton();
                    }
                    else{System.Console.WriteLine("ID does not belong to a developer");}
                }
                else{System.Console.WriteLine("ID does not belong to a team");}
            }

           public string GetValidStringInput (string InputItem)
           {
                while (string.IsNullOrEmpty(InputItem))
                {
                    System.Console.WriteLine($"Please enter a valid input");
                    InputItem = Console.ReadLine();

                    if (string.IsNullOrEmpty(InputItem))
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

            public void RemoveDevTeam()
            {
                Console.Clear();
                DisplayAllTeams();
                System.Console.WriteLine("Type the team ID of the team you wish to delete: ");

                int teamToDelete = int.Parse(Console.ReadLine());
                bool teamWasRemoved = _DevTeamRepo.RemoveTeam(teamToDelete);
                if (teamWasRemoved)
                {
                    System.Console.WriteLine("Deletion successful");
                }
                else {System.Console.WriteLine("Deletion failed");}
                continueButton();
            }

            public void RemoveDevFromTeam()
            {
                Console.Clear();
                DisplayAllTeams();
                System.Console.WriteLine("Type the ID of the team you wish to remove a developer from");
                int inputTeamID4 = int.Parse(Console.ReadLine());
                if (_DevTeamRepo.VerifyTeam(inputTeamID4))
                {
                    Console.Clear();
                    
                    DevTeam teamSelect = _DevTeamRepo.GetTeamByNOI(inputTeamID4);
                    DisplayListOfTeamMembers(teamSelect);
                    System.Console.WriteLine("Type the ID of the developer you would like to delete from the team: ");
                    int devToRemove = int.Parse(Console.ReadLine());
                    if (_devRepo.VerifyDev(devToRemove))
                    {
                        Developer removeDev = _devRepo.FindDeveloperNOI(devToRemove);
                        teamSelect.RemoveDevFromTeam(removeDev);
                        System.Console.WriteLine("Developer has been removed from the team");
                        continueButton();


                    }
                    else{System.Console.WriteLine("ID does not belong to a developer");}
                }
                
                else
                {
                    System.Console.WriteLine("ID does not belong to a team");
                }
                
            }

            public string DisplayListOfTeamMembers(DevTeam devTeam) 
            {
                foreach(Developer developer in devTeam.Members)
                {
                    System.Console.WriteLine("\n"+
                    $"Name:{developer.DevName}\n" +
                    $"Employee ID: {developer.NOI}\n" +
                    $"Access to Pluralsight: {developer.HasPSAccess}\n"
                    
                    );
                }
                return null;
            }

            public string DisplayMembersWithAccess() 
            {
                foreach(Developer developer in _devRepo.membersWithAccess)
                {
                    System.Console.WriteLine("\n"+
                    $"Name:{developer.DevName}\n" +
                    $"Employee ID: {developer.NOI}\n" +
                    $"Access to Pluralsight: {developer.HasPSAccess}\n"
                    
                    );
                }
                return null;

                continueButton();
            }

            private void Seed()
        {
            Developer john = new Developer("John Doe", 123456, true);
            Developer jane = new Developer("Jane Doe", 789012, false);
            _devRepo.AddToDevList(john);
            _devRepo.AddToDevList(jane);

            DevTeam alpha = new DevTeam("Alpha", 1234);
            DevTeam bravo = new DevTeam("Bravo", 5678);
            _DevTeamRepo.AddTeamToList(alpha);
            _DevTeamRepo.AddTeamToList(bravo);
            alpha.AddDevToTeam(john);
            bravo.AddDevToTeam(jane);
        }



    }
}
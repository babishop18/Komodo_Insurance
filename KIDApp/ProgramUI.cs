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
                "4. Remove a developer\n" +
                "5. Exit program");

                string input = Console.ReadLine();

                // switch(input)
                // {
                //     case "1":
                // }
            }


        }




    }
}
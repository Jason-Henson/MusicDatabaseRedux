using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;


namespace MusicDatabaseRedux.UI
{
    public class ProgramUI
    {
        public void Run()
        {
            ShowMenu();
        }

        private void resetScreen()
        {
            Console.Clear();
            ShowMenu();
        }
        
        private void ShowMenu()
        {
            Console.WriteLine
               (
                "Air Nomads Music Database API\n" +
                "Enter the number for the function you want to perform\n" +
                "\n" +
                "1. Add a new artist.\n" +
                "2. Get a list of all artists.\n" +
                "3. View a singe artist.\n" +
                "4. Edit a single artist.\n" +
                "5. Delete a single artist.\n" +
                "6. End the program."
                );

            bool continueToRun = true;
            while (continueToRun)
            {
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddArtist();
                        break;
                    case "2":
                        ViewAllArtists();
                        break;
                    case "3":
                        ViewArtistById();
                        break;
                    case "4":
                        EditArtistById();
                        break;
                    case "5":
                        DeleteArtistById();
                        break;
                    case "6":
                        EndProgram();
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 6");
                        resetScreen();
                        break;
                }
            }
        }

        private void AddArtist()
        {
            bool isAlive;
            Console.WriteLine(
                "Add new artist\n" +
                "--------------\n" +
                "Please enter the artist name.");
            string artistName = Console.ReadLine();
            Console.WriteLine("Please 1 for a solo artist or the number of artist in the group.");
            int numberOfMembers = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Pres 1 if the artist is living or 2 if they are deceased.");
            string isAliveReponse = Console.ReadLine();
            if (isAliveReponse == "2") isAlive = true;
            else isAlive = false;
        }

        private void ViewAllArtists()
        {
            
        }

        private void ViewArtistById()
        {
            
        }

        private void EditArtistById()
        {
            
        }

        private void DeleteArtistById()
        {
            
        }

        private void EndProgram()
        {
            
        }
    }
}

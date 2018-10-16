using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab8
{
    class Program
    {
        static void Main()
        {
            string goAgain;
            Console.WriteLine("Welcome to our C# class!");
            do
            {
                Console.Write("Which student would you like to learn about? (Enter a number 1-15): ");
                int studentNumber = GetStudentChoice();
                GetTownFoodChoice(studentNumber);
                goAgain = GoAgain();
            } while (goAgain == "yes" || goAgain == "y");

            Console.WriteLine("\nThanks!");
            Console.ReadKey();
        }

        static string GetStudentInfo(int row, int col)
        {
            string[,] students = new string[15, 3] {
            { "Michael Hern", "Canton, MI", "Chicken Wings"},
            { "Taylor Everts", "Caro, MI", "Cordon Bleu"},
            { "Joshua Zimmerman", "Taylor, MI", "Turkey"},
            { "Lin-Z Chang", "Toledo, OH", "Ice Cream"},
            { "Madelyn Hilty", "Oxford, MI", "Croissents"},
            { "Nana Banahene", "Guana", "Empanadas"},
            { "Rochelle Toles", "Mars", "Space Cheese"},
            { "Shah Shahid", "Newark, NJ", "Chicken Wings"},
            { "Tim Broughton", "Detroit, MI", "Chicken Parm"},
            { "Abby Wessels", "Traverse City, MI", "Soup"},
            { "Blake Shaw", "Los Angeles, CA", "Cannolis"},
            { "Bob Valentic", "St. Clair Shores, MI", "Pizza"},
            { "Jordan Owiesny", "Warren, MI", "Burgers"},
            { "Jay Stiles", "Macomb, MI", "Pickles"},
            { "Jon Shaw", "Huntington Woods, MI", "Ribs"} };

            return students[row, col];
        }

        static int GetStudentChoice()
        {
            while (true)
            {
                try
                {
                    int studentNumber = int.Parse(Console.ReadLine())-1;
                    Console.WriteLine("Student " + (studentNumber + 1) + " is " + Name(studentNumber) + ". What would you like to know about " + Name(studentNumber).Split()[0] + "? (enter \"hometown\" or \"favorite food\"): ");
                    return studentNumber;
                }
                catch(FormatException)  //Catches Format Exception for the int.Parse method call if the user provides a non-integer number.
                {
                    Console.Write("Only integer choices please. Try again. Enter a number 1-15: ");
                }
                catch(IndexOutOfRangeException)  //Catches Index Out Of Range Exception if the user picks a number too big or too small.
                {
                    Console.Write("That student does not exist. Please try again. Enter a number 1-15: ");
                }
            }
        }
        static void GetTownFoodChoice(int studentNumber)  //Method that determines if the user wants to know the student's hometown or fav food and writes the appropriate response to the console.
        {
            string choice = Console.ReadLine().ToLower().Trim();
            while(choice != "hometown" && choice != "town" && choice != "favorite food" && choice != "food")
            {
                Console.WriteLine("That data does not exist.  Please try again. Enter \"hometown\" or \"favorite food\"): ");
                choice = Console.ReadLine().ToLower().Trim();
            }
            if (choice == "hometown" || choice == "town")
            {               
                Console.Write(Name(studentNumber).Split()[0] + " is from " + Hometown(studentNumber) + ". Would you like to know more? (enter \"yes\" or \"no\"): ");
            }
            else
            {
                Console.Write(Name(studentNumber).Split()[0] + "'s favorite food is " + FavFood(studentNumber) + ". Would you like to know more? (enter \"yes\" or \"no\"): ");
            }
        }
        static string GoAgain()  //Method that determines if the user wants to make another selection
        {
            string goAgain = Console.ReadLine().ToLower().Trim();
            while(goAgain != "yes" && goAgain != "y" && goAgain != "no" && goAgain != "n")
            {
                Console.WriteLine("Invalid choice.  Would you like to know more? (enter \"yes\" or \"no\"): ");
                goAgain = Console.ReadLine().ToLower();
            }
            return goAgain;
        }
        static string Name(int studentNumber)
        {
            return GetStudentInfo(studentNumber, 0);  //Returns element in column 1 which houses the student name for the given student number.
        }
        static string Hometown(int studentNumber)
        {
            return GetStudentInfo(studentNumber, 1);  //Returns element in column 2 which houses student's hometown for the given student number.
        }
        static string FavFood(int studentNumber)     
        {
            return GetStudentInfo(studentNumber, 2);  //Returns element in column 3 which houses student's favorite food for the given student number.
        }
    }
}

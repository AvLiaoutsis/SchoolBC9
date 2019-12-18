using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1st
{
    class Function : Data
    {
        public static bool CheckToContinue()
        {
            Console.Clear();
            string answer;
            List<string> answers = new List<string> { "yes", "YES", "NO", "no"};
            Console.WriteLine("Do you wanna continue?");
            answer = Console.ReadLine();
            while (!answers.Contains(answer))
            {
                Console.WriteLine("You entered an invalid value");
                Console.Write("Please enter yes or no to continue: ");
                answer = Console.ReadLine();
            }
            if (answer == "yes" || answer == "YES" || answer == "Yes")
            {
                Console.Clear();
                return true;
            }
            else
            {
                Console.Clear();
                return false;
            }
        }
        public static string CheckStrNull()
        {
            string text = "";
            text = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("You entered empty value!");
                Console.Write("Give an valid value: ");
                text = Console.ReadLine();
            }
            return text;
        }
        public static string CheckEmpty(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                return value;
            }
            else
            {
                throw new Exception("You have entered empty value!");
            }
        }
        public static DateTime CheckDate()
        {
            DateTime date = new DateTime();
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("You entered an invalid Date");
                Console.Write("Give an valid Date: ");
            }
            return date;
        }
        public static DateTime CheckDateToday()
        {
            DateTime date = CheckDate();
            DateTime now = DateTime.Now;
            while (now >= date)
            {
                Console.WriteLine("You have to live for tommorow!");
                Console.Write($"Give an Date after today: ");
                date = CheckDate();
            }
            return date;
        }
        public static DateTime CheckDateMonToFriday()
        {
            DateTime date = CheckDateToday();
            while (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("The Date have to be Monday to Friday!");
                Console.Write($"Give an another Date: ");
                date = CheckDateToday();
            }
            return date;
        }
        public static string TakeAction(string answer)
        {
            Console.Clear();
            InitiliazeScreen();
            answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Selection.ShowStudentsDB();
                    break;
                case "2":
                    Selection.ShowTrainersDB();
                    break;
                case "3":
                    Selection.ShowAssignmnetsDB();
                    break;
                case "4":
                    Selection.ShowCoursesDB();
                    break;
                case "5":
                    Selection.ShowStudentsPerCourseDB();
                    break;
                case "6":
                    Selection.ShowTrainersPerCourseDB();
                    break;
                case "7":
                    Selection.ShowAssignmentPerCourseDB();
                    break;
                case "8":
                    Selection.ShowStudentPerAssignmentPerCourseDB();
                    break;
                case "9":
                    Selection.ShowStudentMoreCourseDB();
                    break;
                case "10":
                    Insertion.StudentInsertDB();
                    break;
                case "11":
                    Insertion.TrainerInsertDB();
                    break;
                case "12":
                    Insertion.AssignmentInsertDB();
                    break;
                case "13":
                    Insertion.CourseInsertDB();
                    break;
                case "14":
                    Insertion.StudentPerCourseInsertDB();
                    break;
                case "15":
                    Insertion.TrainerPerCourseInsertDB();
                    break;
                case "16":
                    Insertion.AssignmentPerStudentPerCourseInsertDB();
                    break;
                case "Q":
                    break;
                default:
                    Console.WriteLine("You have to choose 1 to 16 or Q to exit:");
                    TakeAction(answer);
                    break;
            }
            Console.Clear();
            return answer;
        }
        public static void ContinueToMain()
        {
            Console.WriteLine("Redirecting to Main Page..\nType to continue to Main Page....");
            Console.ReadKey();
        }
        
        public static void InitiliazeScreen()
        {
            Console.Clear();

            Console.WriteLine(" ____   _____ ___    ____   ____   ____ _______ _____          __  __ _____     _____  _  _   ");
            Console.WriteLine("|  _ \\ / ____/ _ \\  |  _ \\ / __ \\ / __ \\__   __/ ____|   /\\   |  \\/  |  __ \\   / ____|| || |_ ");
            Console.WriteLine("| |_) | |   | (_) | | |_) | |  | | |  | | | | | |       /  \\  | \\  / | |__) | | |   |_  __  _|");
            Console.WriteLine("|  _ <| |    \\__, | |  _ <| |  | | |  | | | | | |      / /\\ \\ | |\\/| |  ___/  | |    _| || |_ ");
            Console.WriteLine("| |_) | |____  / /  | |_) | |__| | |__| | | | | |____ / ____ \\| |  | | |      | |___|_  __  _|");
            Console.WriteLine("|____/ \\_____|/_/   |____/ \\____/ \\____/  |_|  \\_____/_/    \\_\\_|  |_|_|       \\_____||_||_|\n");

            Console.WriteLine("1.Show all Students.\t\t\t\t10.Make a new Student.");
            Console.WriteLine("2.Show all Trainers.\t\t\t\t11.Make a new Trainer.");
            Console.WriteLine("3.Show all Assignments.\t\t\t\t12.Make a new Assignment.");
            Console.WriteLine("4.Show all Courses.\t\t\t\t13.Make a new Course.");
            Console.WriteLine("5.Show all Students Per Course.\t\t\t14.Assign A Student to a Course.");
            Console.WriteLine("6.Show all Trainers Per Course.\t\t\t15.Assign A Trainer to a  Course.");
            Console.WriteLine("7.Show all Assignments Per Course.\t\t16.Assign A Student to an Assignment and to a Course.");
            Console.WriteLine("8.Show all Assignment Per Student Per Course.");
            Console.WriteLine("9.Show all Students that have more than one Course.\n");
            Console.WriteLine("\t\t\t\tType 1 to 16 or Q to Quit:");
        }
    }
}

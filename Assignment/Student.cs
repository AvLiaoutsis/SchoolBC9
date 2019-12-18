using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1st
{
    class Student
    {
        public int ID { get; set; }

        private string firstName;
        public string FirstName 
        {
            get
            {
                return firstName;     
            }
            set
            {
                firstName = Function.CheckEmpty(value);
            }
        }
        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = Function.CheckEmpty(value);
            }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get 
            { 
                return dateOfBirth;
            }
            set
            {
                if (value < DateTime.Now.AddYears(-18))
                {
                    dateOfBirth = value;
                }
                else
                {
                    throw new Exception("Wrong BirthDay Date!");
                }
            }
        }
        public double TuitionFees { get; set; }

        public List<Assignment> assignments;

        public List<Course> courses;
        public Student(int id ,string firstName, string lastName, DateTime dateOfBirth, double tuitionFees)
        {
            assignments = new List<Assignment>();
            courses = new List<Course>();

            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TuitionFees = tuitionFees;
        }
        public static double CheckFees()
        {
            double num;
            while (!double.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("You entered an invalid number!");
                Console.Write("Give an valid number: ");
            }
            return num;
        }
        public static DateTime CheckBirthDate()
        {
            DateTime date = Function.CheckDate();
            DateTime now = DateTime.Now;
            while (now.AddYears(-18) < date)
            {
                Console.WriteLine("Are you from Future???\nYou have to be at least 18 years old!\n");
                Console.Write($"Give an Valid Date: ");
                date = Function.CheckDate();
            }
            return date;
        }
        public override string ToString()
        {
            return $"Student:\nFirst Name : {FirstName}\nLast Name : {LastName}\nDate Of Birth : {DateOfBirth.Date}\nTuition Fees : {TuitionFees}\nID : {ID}\n";
        }
    }
}

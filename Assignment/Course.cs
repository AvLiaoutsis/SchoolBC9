using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1st 
{
    class Course 
    {
        public int ID { get; set; }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = Function.CheckEmpty(value);
            }
        }
        private string stream;
        public string Stream
        {
            get
            {
                return stream;
            }
            set
            {
                stream = Function.CheckEmpty(value);
            }
        }
        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = Function.CheckEmpty(value);
            }
        }

        private DateTime start_Date;
        public DateTime Start_Date
        {
            get
            {
                return start_Date;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    start_Date = value;
                }
                else
                {
                    throw new Exception("Wrong Date,You have to enter a Future Date!");
                }
            }
        }

        private DateTime end_Date;
        public DateTime End_Date
        {
            get
            {
                return end_Date;
            }
            set
            {
                if (value > Start_Date)
                {
                    end_Date = value;
                }
                else
                {
                    throw new Exception("Wrong Date,You have to enter a Date after than first!");
                }
            }
        }
        public List<Student> students;

        public List<Assignment> assignments;

        public List<Trainer> trainers;
        public Course(int id, string title,string stream,string type, DateTime start_date , DateTime end_date)
        {
            assignments = new List<Assignment>();
            students = new List<Student>();
            trainers = new List<Trainer>();

            ID = id;
            Title = title;
            Stream = stream;
            Type = type;
            Start_Date = start_date;
            End_Date = end_date;
        }
        public static DateTime CheckSecondDate(DateTime firstDate)
        {
            DateTime secondDate = Function.CheckDateMonToFriday();
            while (firstDate >= secondDate)
            {
                Console.WriteLine("You have enter a Date what is earlier from the previous Date!");
                Console.Write($"Give an Date after than {firstDate.Date}: ");
                secondDate = Function.CheckDateMonToFriday();
            }
            return secondDate;
        }
        public override string ToString()
        {
            return $"Course : {Title}\nStream : {Stream}\nStart Date : {Start_Date.Date}\nEnd Date : {End_Date.Date}\n";
        }
    }
}

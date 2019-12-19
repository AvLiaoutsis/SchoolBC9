using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1st
{
    class Data
    {
        //Variables for Courses
        public static string courseTitle;
        public static string courseType;
        public static string courseStream;
        public static DateTime courseDateStart;
        public static DateTime courseDateEnd;

        //Variables for Students and Trainers
        public static string name;
        public static string lastname;
        public static string subject;
        public static DateTime birthDate;
        public static double fees;

        //Variables for Assignment
        public static string title;
        public static string description;
        public static DateTime subDateTime;
        public static double oralMark;
        public static double totalMark;

        //Variable DateTime
        public static DateTime userDate;

        public static List<Student> students = new List<Student>();
        public static List<Assignment> assignments = new List<Assignment>();
        public static List<Trainer> trainers = new List<Trainer>();
        public static List<Course> courses = new List<Course>();
        public static List<Student> studentMoreCourse = new List<Student>();
        public static List<Student> studentAssignmentGivenWeek = new List<Student>();


    }
}

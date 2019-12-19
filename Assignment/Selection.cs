using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1st
{
    class Selection : Function
    {
        public static void ShowStudentsDB()
        {
            int counter = 0;
            Console.Clear();
            SqlConnection sqlConnection = Database.ConnectDb();
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    //1st Query 
                    //A List Of Students
                    SqlCommand cmdStudents = new SqlCommand("SELECT * FROM Student", sqlConnection);
                    SqlDataReader readerStudents = cmdStudents.ExecuteReader();

                    while (readerStudents.Read())
                    {
                        counter++;
                        int id = readerStudents.GetInt32(0);
                        string firstName = readerStudents.GetString(1);
                        string lastName = readerStudents.GetString(2);
                        DateTime dateOfBirth = readerStudents.GetDateTime(3);
                        Double tuitionFees = readerStudents.GetDouble(4);
                        Student student = new Student(id,firstName, lastName, dateOfBirth, tuitionFees);
                        students.Add(student);
                    }
                    if (counter>0)
                    {
                        foreach (var student in students)
                        {
                            Console.WriteLine(student);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no Students Registered in Database!");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    ContinueToMain();
                }
            }
        }
        public static void ShowTrainersDB()
        {
            int counter = 0;
            SqlConnection sqlConnection = Database.ConnectDb();
            Console.Clear();

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdTrainers = new SqlCommand("SELECT * FROM Trainer", sqlConnection);
                    SqlDataReader readerTrainers = cmdTrainers.ExecuteReader();


                    while (readerTrainers.Read())
                    {
                        counter++;
                        int id = readerTrainers.GetInt32(0);
                        string firstName = readerTrainers.GetString(1);
                        string lastName = readerTrainers.GetString(2);
                        string subject = readerTrainers.GetString(3);
                        Trainer trainer = new Trainer(id,firstName, lastName, subject);
                        trainers.Add(trainer);
                    }
                    if (counter>0)
                    {
                        foreach (var trainer in trainers)
                        {
                            Console.WriteLine(trainer);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no Trainers Registered in Database!");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    ContinueToMain();
                }
            }
        }
        public static void ShowAssignmnetsDB()
        {
            int counter = 0;
            SqlConnection sqlConnection = Database.ConnectDb();
            Console.Clear();

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    //3rd Query 
                    //A List Of Assignments
                    SqlCommand cmdAssignments = new SqlCommand("SELECT * FROM Assignment", sqlConnection);
                    SqlDataReader readerAssignments = cmdAssignments.ExecuteReader();

                    while (readerAssignments.Read())
                    {
                        counter++;
                        int id = readerAssignments.GetInt32(0);
                        string title = readerAssignments.GetString(1);
                        string description = readerAssignments.GetString(2);
                        DateTime subDateTime = readerAssignments.GetDateTime(3);
                        Assignment assignment = new Assignment(id,title, description, subDateTime);
                        assignments.Add(assignment);
                    }
                    if(counter > 0)
                    {
                        foreach (var assignment in assignments)
                        {
                            Console.WriteLine(assignment);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no Assignments Registered in Database!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    ContinueToMain();
                }
            }
        }
        public static void ShowCoursesDB()
        {
            int counter = 0;
            SqlConnection sqlConnection = Database.ConnectDb();
            Console.Clear();
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    //4th Query 
                    //A List Of Courses
                    SqlCommand cmdCourses = new SqlCommand("SELECT * FROM Course", sqlConnection);
                    SqlDataReader readerCourses = cmdCourses.ExecuteReader();

                    while (readerCourses.Read())
                    {
                        counter++;
                        int id = readerCourses.GetInt32(0);
                        string title = readerCourses.GetString(1);
                        string stream = readerCourses.GetString(2);
                        string type = readerCourses.GetString(3);
                        DateTime startDate = readerCourses.GetDateTime(4);
                        DateTime endDate = readerCourses.GetDateTime(5);
                        Course course = new Course(id,title, stream, type, startDate, endDate);
                        courses.Add(course);
                    }
                    if (counter > 0)
                    {
                        foreach (var course in courses)
                        {
                            Console.WriteLine(course);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no Courses Registered in Database!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    ContinueToMain();
                }
            }
        }
        public static void ShowStudentsPerCourseDB()
        {
            SqlConnection sqlConnection = Database.ConnectDb();
            Console.Clear();
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    //5th Query 
                    //All the students per course
                    SqlCommand cmdStudentsCourses = new SqlCommand
                        (
                        "SELECT Student.FirstName As Student_Name,Course.title AS Course_Title " +
                        "FROM Student " +
                        "INNER JOIN StudentTakingCourse " +
                        "ON Student.ID = StudentTakingCourse.StudentID " +
                        "INNER JOIN Course " +
                        "ON StudentTakingCourse.CourseID = Course.ID", sqlConnection
                        );
                    var checker = cmdStudentsCourses.ExecuteNonQuery();
                    SqlDataReader readerStudentsCourses = cmdStudentsCourses.ExecuteReader();
                    if (checker != 0)
                    {
                        while (readerStudentsCourses.Read())
                        {
                            Console.WriteLine($"Student Name: {readerStudentsCourses.GetString(0)}\nCourse Title: {readerStudentsCourses.GetString(1)} \n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no Student Per Course Entry Registered in Database!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    ContinueToMain();
                }
            }
        }
        public static void ShowTrainersPerCourseDB()
        {
            SqlConnection sqlConnection = Database.ConnectDb();
            Console.Clear();
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    //6th Query 
                    //All the trainers per course
                    SqlCommand cmdTrainersCourses = new SqlCommand
                        (
                        "SELECT Trainer.FirstName As Trainer_Name,Course.Title AS Course_Title " +
                        "FROM Trainer INNER " +
                        "JOIN TrainerTakingCourse " +
                        "ON Trainer.ID = TrainerTakingCourse.TrainerID " +
                        "INNER JOIN Course " +
                        "ON TrainerTakingCourse.CourseID = Course.ID", sqlConnection
                        );
                    var checker = cmdTrainersCourses.ExecuteNonQuery();
                    SqlDataReader readerTrainersCourses = cmdTrainersCourses.ExecuteReader();
                    if (checker != 0)
                    {
                        while (readerTrainersCourses.Read())
                        {
                            Console.WriteLine($"Trainer Name: {readerTrainersCourses.GetString(0)}\nCourse Title: {readerTrainersCourses.GetString(1)} \n");
                        }
                    }
                    else 
                    {
                        Console.WriteLine("There are no Trainer Per Course Entry Registered in Database!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    ContinueToMain();
                }
            }
        }
        public static void ShowAssignmentPerCourseDB()
        {
            SqlConnection sqlConnection = Database.ConnectDb();
            Console.Clear();
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    //7th Query
                    //All the assignments per course
                    SqlCommand cmdAssignmentCourses = new SqlCommand
                        (
                        "SELECT Assignment.Title As Assignment_Title,Course.Title AS Course_Title " +
                        "FROM Assignment " +
                        "INNER JOIN AssignmentRelation " +
                        "ON Assignment.ID = AssignmentRelation.AssignmentID " +
                        "INNER JOIN Course " +
                        "ON AssignmentRelation.CourseID = Course.ID ", sqlConnection);
                    var checker = cmdAssignmentCourses.ExecuteNonQuery();
                    SqlDataReader readerAssignmentCourses = cmdAssignmentCourses.ExecuteReader();
                    if (checker > 0)
                    {
                        while (readerAssignmentCourses.Read())
                        {
                            Console.WriteLine($"Assignment Title: {readerAssignmentCourses.GetString(0)}\nCourse Title: {readerAssignmentCourses.GetString(1)} \n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no Assignment Per Course Entry Registered in Database!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    ContinueToMain();
                }
            }
        }
        public static void ShowStudentPerAssignmentPerCourseDB()
        {
            SqlConnection sqlConnection = Database.ConnectDb();
            Console.Clear();
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    //8th Query 
                    //All the assignments per course per student
                    SqlCommand cmdStudentAssignmentCourses = new SqlCommand
                        (
                        "SELECT Student.FirstName As Student_Name,Assignment.Title As Assignment_Title,Course.Title AS Course_Title " +
                        "FROM Assignment " +
                        "INNER JOIN AssignmentRelation " +
                        "ON Assignment.ID = AssignmentRelation.AssignmentID " +
                        "INNER JOIN Course " +
                        "ON AssignmentRelation.CourseID = Course.ID " +
                        "INNER JOIN Student " +
                        "ON AssignmentRelation.StudentID = StudentID", sqlConnection
                        );
                    var checker = cmdStudentAssignmentCourses.ExecuteNonQuery();
                    SqlDataReader readerStudentsAssignmentCourse = cmdStudentAssignmentCourses.ExecuteReader();
                    if (checker > 0)
                    {
                        while (readerStudentsAssignmentCourse.Read())
                        {
                            Console.WriteLine($"Student Name: {readerStudentsAssignmentCourse.GetString(0)}\n Assignment Title:{readerStudentsAssignmentCourse.GetString(1)}\n Course Title:{readerStudentsAssignmentCourse.GetString(2)} \n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no Student Per Assignment Per Course Entry Registered in Database!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    ContinueToMain();
                }
            }
        }
        public static void ShowStudentMoreCourseDB()
        {
            SqlConnection sqlConnection = Database.ConnectDb();

            using (sqlConnection)
            {
                try
                {
                    Console.Clear();
                    sqlConnection.Open();
                    //9th Query 
                    SqlCommand cmdStudentCoursesMore = new SqlCommand
                        (
                        "SELECT Student.FirstName As Student_Name,COUNT(course.id) As Number_Of_Courses " +
                        "FROM Student " +
                        "INNER JOIN StudentTakingCourse " +
                        "ON Student.ID = StudentTakingCourse.StudentID " +
                        "INNER JOIN Course " +
                        "ON StudentTakingCourse.CourseID = Course.ID " +
                        "GROUP BY Student.FirstName " +
                        "HAVING COUNT(Course.ID) > 1; ", sqlConnection
                        );
                    var checker = cmdStudentCoursesMore.ExecuteNonQuery();

                    SqlDataReader readerStudentCoursesMore = cmdStudentCoursesMore.ExecuteReader();
                    if (checker > 0)
                    {
                        while (readerStudentCoursesMore.Read())
                        {
                            Console.WriteLine("Student Name: " + readerStudentCoursesMore.GetString(0) + "\n" + "Number of Courses: " + readerStudentCoursesMore.GetInt32(1) + "\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    ContinueToMain();
                }
            }
        }
    }
}

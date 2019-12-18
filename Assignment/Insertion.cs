using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1st
{
    class Insertion : Function
    {
        public static void StudentInsertDB()
        {
            if (CheckToContinue())
            {
                SqlConnection sqlConnection = Database.ConnectDb();
                using (sqlConnection)
                {
                    try
                    {
                        sqlConnection.Open();
                        //Create A new Trainer
                        Console.WriteLine("Student Creation Process:");
                        Console.WriteLine("Give name: ");
                        name = CheckStrNull();
                        Console.WriteLine("Give Surname: ");
                        lastname = CheckStrNull();
                        Console.WriteLine("Give BirthDate with format year/month/day: ");
                        birthDate = Student.CheckBirthDate();
                        Console.WriteLine("Give Tuition Fees: ");
                        fees = Student.CheckFees();

                        //Insert in DB Without Checking For Duplicates
                        SqlCommand insertCommand = new SqlCommand("INSERT INTO STUDENT VALUES(@name,@lastname,@birthDate,@fees)", sqlConnection);
                        insertCommand.Parameters.AddWithValue("@name", name);
                        insertCommand.Parameters.AddWithValue("@lastname", lastname);
                        insertCommand.Parameters.AddWithValue("@birthDate", birthDate);
                        insertCommand.Parameters.AddWithValue("@fees", fees);
                        //Executing query 
                        int result = insertCommand.ExecuteNonQuery();
                        if (result > 0)
                        {
                            Console.WriteLine("Student Creation Succeed!");
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
            else
            {
                ContinueToMain();
            }
        }
        public static void TrainerInsertDB()
        {
            if (CheckToContinue())
            {
                SqlConnection sqlConnection = Database.ConnectDb();
                using (sqlConnection)
                {
                    try
                    {
                        sqlConnection.Open();

                        //Create a new Trainer
                        Console.WriteLine("Trainer Creation Process:");
                        Console.WriteLine("Give name: ");
                        name = CheckStrNull();
                        Console.WriteLine("Give Surname: ");
                        lastname = CheckStrNull();
                        Console.WriteLine("Give Subject: ");
                        subject = CheckStrNull();

                        //Insert in DB Without Checking For Duplicates

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TRAINER VALUES(@name,@lastname,@subject)", sqlConnection);
                        insertCommand.Parameters.AddWithValue("@name", name);
                        insertCommand.Parameters.AddWithValue("@lastname", lastname);
                        insertCommand.Parameters.AddWithValue("@subject", subject);
                        //Executing query and storing rows affected
                        int result = insertCommand.ExecuteNonQuery();
                        if (result > 0)
                        {
                            Console.WriteLine("Trainer Creation Succeed!");
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
            else
            {
                ContinueToMain();
            }
        }
        public static void CourseInsertDB()
        {
            if (CheckToContinue())
            {
                SqlConnection sqlConnection = Database.ConnectDb();
                using (sqlConnection)
                {
                    try
                    {
                        sqlConnection.Open();

                        //Make a new Course
                        Console.WriteLine("Course Creation Process: ");
                        Console.WriteLine("Give title: ");
                        courseTitle = CheckStrNull();
                        Console.WriteLine("Give Start date with format year/month/day: ");
                        courseDateStart = CheckDateMonToFriday();
                        Console.WriteLine("Give end date with format year/month/day: ");
                        courseDateEnd = Course.CheckSecondDate(courseDateStart);
                        Console.WriteLine("Give type: ");
                        courseType = CheckStrNull();
                        Console.WriteLine("Give stream: ");
                        courseStream = CheckStrNull();

                        //Check if Course is already created
                        SqlCommand checkCourse = new SqlCommand
                        (
                        "SELECT *" +
                        "FROM Course " +
                        "WHERE Title=@courseTitle", sqlConnection
                        );
                        checkCourse.Parameters.AddWithValue("@courseTitle", courseTitle);

                        var checkerCourse = (int?)checkCourse.ExecuteScalar();
                        if (checkerCourse < 0)
                        {
                            SqlCommand insertCommand = new SqlCommand("INSERT INTO COURSE(Title,Stream,Type,StartDate,EndDate) VALUES(@title,@stream,@type,@startDate,@endDate)", sqlConnection);
                            insertCommand.Parameters.AddWithValue("@title", courseTitle);
                            insertCommand.Parameters.AddWithValue("@stream", courseStream);
                            insertCommand.Parameters.AddWithValue("@type", courseType);
                            insertCommand.Parameters.AddWithValue("@startDate", courseDateStart);
                            insertCommand.Parameters.AddWithValue("@endDate", courseDateEnd);

                            int result = insertCommand.ExecuteNonQuery();
                            if (result > 0)
                            {
                                Console.WriteLine("Course Creation Succeed!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This Course is already in Database");
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
            else
            {
                ContinueToMain();
            }
        }
        public static void AssignmentInsertDB()
        {
            if (CheckToContinue())
            {
                Console.Clear();
                SqlConnection sqlConnection = Database.ConnectDb();
                using (sqlConnection)
                {
                    try
                    {
                        sqlConnection.Open();
                        Console.Clear();
                        //Create a new Assignment
                        Console.WriteLine("Assignment Creation Process:");
                        Console.WriteLine("Give Title: ");
                        title = CheckStrNull();
                        Console.WriteLine("Give Description: ");
                        description = CheckStrNull();
                        Console.WriteLine("Give Submission Date with format year/month/day: ");
                        subDateTime = CheckDateMonToFriday();

                        //Check if Assignment is already created
                        SqlCommand checkAssignment = new SqlCommand
                        (
                        "SELECT *" +
                        "FROM Assignment " +
                        "WHERE Title=@assignmentTitle", sqlConnection
                        );
                        checkAssignment.Parameters.AddWithValue("@assignmentTitle", title);

                        var checkerAssignment = (int?)checkAssignment.ExecuteScalar();
                        if (checkerAssignment < 0)
                        {
                            SqlCommand insertCommand = new SqlCommand("INSERT INTO ASSIGNMENT(Title,Description,SubDate) VALUES(@title,@description,@submissionDate)", sqlConnection);
                            insertCommand.Parameters.AddWithValue("@title", title);
                            insertCommand.Parameters.AddWithValue("@description", description);
                            insertCommand.Parameters.AddWithValue("@submissionDate", subDateTime);

                            int result = insertCommand.ExecuteNonQuery();
                            if (result > 0)
                            {
                                Console.WriteLine("Assignment Creation Succeed!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This Assignment is already in Database");
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
            else
            {
                ContinueToMain();
            }
        }
        public static void StudentPerCourseInsertDB()
        {
            if (CheckToContinue())
            {
                SqlConnection sqlConnection = Database.ConnectDb();
                Console.Clear();
                using (sqlConnection)
                {
                    try
                    {
                        sqlConnection.Open();
                        Console.WriteLine("Please type the First Name of the Student");
                        name = CheckStrNull();
                        Console.WriteLine("Please type the Last Name of the Student");
                        lastname = CheckStrNull();

                        SqlCommand checkStudent = new SqlCommand
                        ("SELECT *" +
                        "FROM Student " +
                        "WHERE FirstName = @name AND LastName = @LastName", sqlConnection);
                        checkStudent.Parameters.AddWithValue("@name", name);
                        checkStudent.Parameters.AddWithValue("@LastName", lastname);

                        var checkerStudent = (int?)checkStudent.ExecuteScalar();

                        Console.WriteLine("Please type the Title of the Course ");
                        courseTitle = CheckStrNull();
                        SqlCommand checkCourse = new SqlCommand
                        (
                        "SELECT *" +
                        "FROM Course " +
                        "WHERE Title=@courseTitle", sqlConnection
                        );
                        checkCourse.Parameters.AddWithValue("@courseTitle", courseTitle);

                        var checkerCourse = (int?)checkCourse.ExecuteScalar();

                        if (checkerStudent > 0 && checkerCourse > 0)
                        {
                            var checkDb = new StringBuilder();
                            checkDb
                                .AppendLine("SELECT * FROM StudentTakingCourse")
                                .AppendLine($"WHERE STUDENTID =(Select TOP 1  Student.ID from Student where FirstName = '{name}' and LastName = '{lastname}') AND ")
                                .AppendLine($"COURSEID = (select TOP 1 Course.ID from Course where Course.Title = '{courseTitle}')");
                            SqlCommand checkInsert = new SqlCommand(checkDb.ToString(), sqlConnection);
                            var checkForAlreadyAssigned = (int?)checkInsert.ExecuteScalar();

                            if (checkForAlreadyAssigned < 0)
                            {
                                //Building query to run
                                var insertdb = new StringBuilder();
                                insertdb
                                    .AppendLine("Insert into StudentTakingCourse(StudentID,CourseID)")
                                    .AppendLine($"Values((Select TOP 1  Student.ID from Student where FirstName = '{name}' and LastName = '{lastname}'),")
                                    .AppendLine($"(select TOP 1 Course.ID from Course where Course.Title = '{courseTitle}'))");

                                //Check if is already assigned
                                SqlCommand insertCommand = new SqlCommand(insertdb.ToString(), sqlConnection);
                                int result = insertCommand.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Insertion Succeed!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("This Course is already Assigned to this Student");
                            }
                        }
                        else
                        {
                            Console.WriteLine("These entries are not in database");
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
            else
            {
                ContinueToMain();
            }
        }
        public static void TrainerPerCourseInsertDB()
        {
            if (CheckToContinue())
            {
                SqlConnection sqlConnection = Database.ConnectDb();
                using (sqlConnection)
                {
                    try
                    {
                        sqlConnection.Open();
                        Console.WriteLine("Please type the First Name of the trainer");
                        name = CheckStrNull();
                        Console.WriteLine("Please type the Last Name of the trainer");
                        lastname = CheckStrNull();

                        SqlCommand checkTrainer = new SqlCommand
                        ("SELECT *" +
                        "FROM Trainer " +
                        "WHERE FirstName = @name AND LastName = @LastName", sqlConnection);
                        checkTrainer.Parameters.AddWithValue("@name", name);
                        checkTrainer.Parameters.AddWithValue("@LastName", lastname);
                        var checkerTrainer = (int?)checkTrainer.ExecuteScalar();

                        Console.WriteLine("Please type the Title of the Course.");
                        courseTitle = CheckStrNull();
                        SqlCommand checkCourse = new SqlCommand
                        (
                        "SELECT *" +
                        "FROM Course " +
                        "WHERE Title=@courseTitle", sqlConnection
                        );
                        checkCourse.Parameters.AddWithValue("@courseTitle", courseTitle);

                        var checkerCourse = (int?)checkCourse.ExecuteScalar();
                        if (checkerCourse > 0 && checkerTrainer > 0)
                        {
                            var checkDb = new StringBuilder();
                            checkDb
                                .AppendLine("SELECT * FROM TrainerTakingCourse")
                                .AppendLine($"WHERE TrainerID =(Select TOP 1  Trainer.ID from Trainer where FirstName = '{name}' and LastName = '{lastname}') AND ")
                                .AppendLine($"COURSEID = (select TOP 1 Course.ID from Course where Course.Title = '{courseTitle}')");
                            SqlCommand checkInsert = new SqlCommand(checkDb.ToString(), sqlConnection);
                            var checkForAlreadyAssigned = (int?)checkInsert.ExecuteScalar();

                            if (checkForAlreadyAssigned < 0)
                            {
                                var insertdb = new StringBuilder();
                                insertdb
                                    .AppendLine("Insert into TrainerTakingCourse(TrainerID,CourseID)")
                                    .AppendLine($"Values((Select TOP 1 Trainer.ID from Trainer where FirstName = '{name}' and LastName = '{lastname}'),")
                                    .AppendLine($"(select TOP 1 Course.ID from Course where Course.Title = '{courseTitle}'))");

                                //Building query command and passing values above into parameteres of the query
                                SqlCommand insertCommand = new SqlCommand(insertdb.ToString(), sqlConnection);
                                int result = insertCommand.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Insertion Succeed!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("This Course is already Assigned to this Trainer.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("These entries are not in database.");
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
            else
            {
                ContinueToMain();
            }
        }
        public static void AssignmentPerStudentPerCourseInsertDB()
        {
            if (CheckToContinue())
            {
                SqlConnection sqlConnection = Database.ConnectDb();
                using (sqlConnection)
                {
                    try
                    {
                        sqlConnection.Open();
                        Console.WriteLine("Please type the Title of the Assignnment");
                        title = CheckStrNull();

                        SqlCommand checkAssignment = new SqlCommand
                        ("SELECT *" +
                        "FROM Assignment " +
                        "WHERE Title =@title", sqlConnection);
                        checkAssignment.Parameters.AddWithValue("@title", title);

                        var checkerAssignment = (int?)checkAssignment.ExecuteScalar();

                        Console.WriteLine("Please type the First Name of the Student.");
                        name = CheckStrNull();
                        Console.WriteLine("Please type the Last Name of the Student.");
                        lastname = CheckStrNull();


                        SqlCommand checkStudent = new SqlCommand
                        ("SELECT *" +
                        "FROM Student " +
                        "WHERE FirstName = @name AND LastName = @LastName", sqlConnection);
                        checkStudent.Parameters.AddWithValue("@name", name);
                        checkStudent.Parameters.AddWithValue("@LastName", lastname);

                        var checkerStudent = (int?)checkStudent.ExecuteScalar();

                        Console.WriteLine("Please type the Title of the Course to include this Assignment.");
                        courseTitle = CheckStrNull();
                        SqlCommand checkCourse = new SqlCommand
                        (
                        "SELECT *" +
                        "FROM Course " +
                        "WHERE Title=@courseTitle", sqlConnection
                        );
                        checkCourse.Parameters.AddWithValue("@courseTitle", courseTitle);

                        var checkerCourse = (int?)checkCourse.ExecuteScalar();

                        //Check Course, student, assigned if exist
                        if (checkerCourse > 0 && checkerStudent > 0 && checkerAssignment > 0)
                        {
                            var checkDb = new StringBuilder();
                            checkDb
                                .AppendLine("SELECT * FROM AssignmentRelation")
                                .AppendLine($"WHERE AssignmentID =(Select TOP 1 Assignment.ID from Assignment where title = '{title}') AND ")
                                .AppendLine($"COURSEID = (select TOP 1 Course.ID from Course where Course.Title = '{courseTitle}') AND")
                                .AppendLine($"StudentID = (Select TOP 1 Student.ID from Student where FirstName = '{name}' and LastName = '{lastname}')");

                            SqlCommand checkInsert = new SqlCommand(checkDb.ToString(), sqlConnection);
                            var checkForAlreadyAssigned = (int?)checkInsert.ExecuteScalar();

                            if (checkForAlreadyAssigned < 0)
                            {
                                var insertdb = new StringBuilder();
                                insertdb
                                    .AppendLine("Insert into AssignmentRelation (AssignmentID,CourseID,StudentID)")
                                    .AppendLine($"Values((Select TOP 1 Assignment.ID from Assignment where title = '{title}'),")
                                    .AppendLine($"(Select TOP 1 Student.ID from Student where FirstName = '{name}' and LastName = '{lastname}'),")
                                    .AppendLine($"(select TOP 1 Course.ID from Course where Course.Title = '{courseTitle}'))");

                                //Building query command and passing values above into parameteres of the query
                                SqlCommand insertCommand = new SqlCommand(insertdb.ToString(), sqlConnection);
                                int result = insertCommand.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Insertion Succeed!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("These are already assigned.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("These entries are not in database.");
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
            else
            {
                ContinueToMain();
            }
        }
    }
}

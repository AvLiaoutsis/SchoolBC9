-- 1st Query A list of all the students
SELECT * 
FROM Student;
-- 2nd Query A list of all the trainers
SELECT * 
FROM Trainer;
-- 3rd Query A list of all the assignments
SELECT * 
FROM Assignment;
-- 4th Query A list of all the courses
SELECT * 
FROM Course;
-- 5th Query All the students per course
SELECT Student.FirstName As Student_Name,Course.Title AS Course_Title
FROM Student 
INNER JOIN StudentTakingCourse 
ON Student.ID = StudentTakingCourse.StudentID 
INNER JOIN Course
ON StudentTakingCourse.CourseID = Course.ID
-- 6th Query All the trainers per course
SELECT Trainer.FirstName As Trainer_Name,Course.Title AS Course_Title
FROM Trainer 
INNER JOIN TrainerTakingCourse 
ON Trainer.ID = TrainerTakingCourse.TrainerID
INNER JOIN Course
ON TrainerTakingCourse.CourseID = Course.ID
-- 7th Query All the assignments per course
SELECT Assignment.Title As Assignment_Title,Course.Title AS Course_Title
FROM Assignment 
INNER JOIN AssignmentRelation 
ON Assignment.ID = AssignmentRelation.AssignmentID
INNER JOIN Course
ON AssignmentRelation.CourseID = Course.ID
GROUP BY Assignment.Title,Course.Title
-- 8th Query All the assignments per course per student
SELECT Student.FirstName As Student_Name,Assignment.Title As Assignment_Title,Course.Title AS Course_Title
FROM Assignment 
INNER JOIN AssignmentRelation 
ON Assignment.ID = AssignmentRelation.AssignmentID
INNER JOIN Course
ON AssignmentRelation.CourseID = Course.ID
INNER JOIN Student
ON AssignmentRelation.StudentID = StudentID
-- 9th Query A list of students that belong to more than one courses
SELECT Student.FirstName As Student_Name,COUNT(course.id) As Number_Of_Courses
FROM Student 
INNER JOIN StudentTakingCourse 
ON Student.ID = StudentTakingCourse.StudentID 
INNER JOIN Course
ON StudentTakingCourse.CourseID = Course.ID
GROUP BY Student.FirstName
HAVING COUNT(Course.ID)>1;

using EFCoreAssi3.DBContext;
using EFCoreAssi3.Models;
using Microsoft.EntityFrameworkCore;
class Program
{
    static void Main(string[] args)
    {
        using ITIDBContext context = new ITIDBContext();


        #region Create

        var newDepartment = new Department { Name = "Computer Science", HiringDate = DateTime.Now, Ins_ID = null };
        context.Departments.Add(newDepartment);
        context.SaveChanges();
        Console.WriteLine("Department added successfully.");

        var newStudent = new Student { FName = "Mohamed", LName = "Shosha", Address = "Giza", Age = 23, Dep_ID = 1 };
        context.Students.Add(newStudent);
        context.SaveChanges();
        Console.WriteLine("Student added successfully.");


        var newTopic = new Topic { Name = "Programming" };
        context.Topics.Add(newTopic);
        context.SaveChanges();
        Console.WriteLine("Topic added successfully.");


        var newCourse = new Course { Name = "C# Basics", Description = "Introduction to C#", Duration = 3, Top_ID = 1 };
        context.Courses.Add(newCourse);
        context.SaveChanges();
        Console.WriteLine("Course added successfully.");

        var newInstructor = new Instructor
            { Name = "Aliaa", Bonus = 500, Salary = 5000, Address = "Giza", HourRate = 50, Dept_ID = 1 };
        context.Instructors.Add(newInstructor);
        context.SaveChanges();
        Console.WriteLine("Instructor added successfully.");

        #endregion


        #region Read
        
        // Lazy Loading

        var student = context.Students.FirstOrDefault(s => s.ID == newStudent.ID);
        var course = context.Courses.FirstOrDefault(c => c.ID == newCourse.ID);
        var instructor = context.Instructors.FirstOrDefault(i => i.ID == newInstructor.ID);
        var department = context.Departments.FirstOrDefault(d => d.ID == newDepartment.ID);
        var topic = context.Topics.FirstOrDefault(t => t.ID == newTopic.ID);

        Console.WriteLine("\nLazy Loading:");
        Console.WriteLine($"Student: {student?.FName} {student?.LName}, Age: {student?.Age}");
        Console.WriteLine($"Course: {course?.Name}, Duration: {course?.Duration}");
        Console.WriteLine($"Instructor: {instructor?.Name}, Salary: {instructor?.Salary}");
        Console.WriteLine($"Department: {department?.Name}, Hiring Date: {department?.HiringDate}");
        Console.WriteLine($"Topic: {topic?.Name}");
        
        // Eager Loading
        var eagerStudent = context.Students
            .Include(s => s.Department)
            .FirstOrDefault(s => s.ID == newStudent.ID);

        var eagerCourse = context.Courses
            .Include(c => c.Topic)
            .FirstOrDefault(c => c.ID == newCourse.ID);

        var eagerInstructor = context.Instructors
            .Include(i => i.Department)
            .FirstOrDefault(i => i.ID == newInstructor.ID);

        var eagerDepartment = context.Departments
            .Include(d => d.Instructors)
            .Include(d => d.Students)
            .FirstOrDefault(d => d.ID == newDepartment.ID);

        var eagerTopic = context.Topics
            .Include(t => t.Courses)
            .FirstOrDefault(t => t.ID == newTopic.ID);

        Console.WriteLine("\nEager Loading:");
        Console.WriteLine($"Student: {eagerStudent?.FName} {eagerStudent?.LName}, Age: {eagerStudent?.Age}, Department: {eagerStudent?.Department?.Name}");
        Console.WriteLine($"Course: {eagerCourse?.Name}, Duration: {eagerCourse?.Duration}, Topic: {eagerCourse?.Topic?.Name}");
        Console.WriteLine($"Instructor: {eagerInstructor?.Name}, Salary: {eagerInstructor?.Salary}, Department: {eagerInstructor?.Department?.Name}");
        Console.WriteLine($"Department: {eagerDepartment?.Name}, Hiring Date: {eagerDepartment?.HiringDate}, Instructor Count: {eagerDepartment?.Instructors.Count}");
        Console.WriteLine($"Topic: {eagerTopic?.Name}, Courses Count: {eagerTopic?.Courses.Count}");

        #endregion


        #region Update

        if (student != null)
        {
            student.Age = 23;
            context.Students.Update(student);
        }

        if (course != null)
        {
            course.Description = "Updated C# Course";
            context.Courses.Update(course);
        }

        if (instructor != null)
        {
            instructor.Bonus = 600;
            context.Instructors.Update(instructor);
        }

        if (department != null)
        {
            department.Name = "Updated CS Department";
            context.Departments.Update(department);
        }

        if (topic != null)
        {
            topic.Name = "Updated Programming";
            context.Topics.Update(topic);
        }

        context.SaveChanges();

        #endregion

        #region Delete

        if (student != null)
        {
            context.Students.Remove(student);
        }

        if (course != null)
        {
            context.Courses.Remove(course);
        }

        if (instructor != null)
        {
            context.Instructors.Remove(instructor);
        }

        if (department != null)
        {
            context.Departments.Remove(department);
        }

        if (topic != null)
        {
            context.Topics.Remove(topic);
        }

        context.SaveChanges();

        #endregion
    }
}
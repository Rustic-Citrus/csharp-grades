using System.ComponentModel;

namespace Project
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                switch (args[0])
                {
                    case "gradebook":
                        Console.WriteLine("~~ Gradebook ~~\n");
                        Gradebook.Main();
                        break;
                    case "gpa":
                        Console.WriteLine("~~ GPA ~~\n");
                        GPA.Main();
                        break;
                    default:
                        Console.WriteLine("Error: Invalid argument.");
                        break;
                }
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("Error: Too many arguments.");
            }
            else
            {
                Console.WriteLine("Error: No arguments passed.");
            }
        }
    }
    class Gradebook
    {
        public string name;
        public int[] grades;
        public int sum = 0;
        public decimal score;
        public string letterScore = "unassigned";
        public Gradebook(string nameString, int[] gradeArray)
        {
            name = nameString;
            grades = gradeArray;
        }
        public static void Main()
        {
            int[][] grades = new int[][] {
                new int[] {93, 87, 98, 95, 100},
                new int[] {80, 83, 82, 88, 85},
                new int[] {84, 96, 73, 85, 79},
                new int[] {90, 92, 98, 100, 97}
            };
            string[] letterGrades = new string[] { "A+", "A", "A-", "B+", "B" };
            string[] names = new string[] { "Sophia", "Nicolas", "Zahirah", "Jeong" };
            decimal currentAssignments = 5.0m;
            Console.WriteLine("Student Grade\n");
            Console.WriteLine("Student\t\tGrade\n");
            for (int i = 0; i < grades.Length; i++)
            {
                Gradebook student = new Gradebook(names[i], grades[i]);
                for (int j = 0; j < student.grades.Length; j++)
                {
                    student.sum += student.grades[j];
                }
                student.score = student.sum / currentAssignments;
                if (student.score >= 97)
                {
                    student.letterScore = "A+";
                }
                else if (student.score >= 93)
                {
                    student.letterScore = "A";
                }
                else if (student.score >= 90)
                {
                    student.letterScore = "A-";
                }
                else if (student.score >= 87)
                {
                    student.letterScore = "B+";
                }
                else if (student.score >= 83)
                {
                    student.letterScore = "B";
                }
                if (student.name.Length > 6)
                {
                    Console.WriteLine($"{student.name}:\t{student.score}\t{student.letterScore}");
                }
                else if (student.name.Length > 0)
                {
                    Console.WriteLine($"{student.name}:\t\t{student.score}\t{student.letterScore}");
                }
            }
        }
    }
    class GPA
    {
        public string studentName;
        public decimal score = 0;
        public GPA(string studentNameString, string[][] coursesArray)
        {
            studentName = studentNameString;
            int sumOfProducts = 0;
            int totalCreditHours = 0;
            Console.WriteLine($"Student: {studentName}\n");
            Console.WriteLine($"Course\t\t\tGrade\tCredit Hours\n");
            for (int i = 0; i < coursesArray.Length; i++)
            {
                Course course = new Course(coursesArray[i]);
                int courseProduct = course.grade * course.creditHours;
                totalCreditHours += course.creditHours;
                sumOfProducts += courseProduct;
                string tabs = "";
                if (course.name.Length < 8)
                {
                    tabs = "\t\t\t";
                }
                else if (course.name.Length < 16)
                {
                    tabs = "\t\t";
                }
                else if (course.name.Length < 24)
                {
                    tabs = "\t";
                }
                Console.WriteLine($"{course.name}{tabs}{course.grade}\t{course.creditHours}");
            }
            score = Math.Round((decimal)sumOfProducts / totalCreditHours, 2);
            Console.WriteLine($"\nFinal GPA:\t\t{score}");
        }
        public static void Main()
        {
            string studentNameString = "Sophia Johnson";
            string[][] courses = new string[][] {
                new string[] {"English 101", "A"}, 
                new string[] {"Algebra 101", "B"}, 
                new string[] {"Biology 101", "B"}, 
                new string[] {"Computer Science I", "B"}, 
                new string[] {"Psychology 101", "A"}
            };
            GPA gpa = new GPA(studentNameString, courses);
        }
    }
    class Course
    {
        public string name;
        public int grade;
        public int creditHours;
        public Course(string[] coursesArray)
        {
            name = coursesArray[0];
            switch (coursesArray[0])
            {
                case "English 101":
                case "Algebra 101":
                case "Psychology 101":
                    creditHours = 3;
                    break;
                case "Biology 101":
                case "Computer Science I":
                    creditHours = 4;
                    break;
                default:
                    creditHours = 0;
                    break;
            }
            switch (coursesArray[1])
            {
                case "A":
                    grade = 4;
                    break;
                case "B":
                    grade = 3;
                    break;
                default:
                    grade = 0;
                    break;
            }
        }
    }
}

namespace ConsoleApp5
{
    class Instructor
    {
        public int InstructorId;
        public string Name;
        public string Specialization;
        public Instructor(int InstructorId, string Name, string Specialization)
        {
            this.InstructorId = InstructorId;
            this.Name = Name;
            this.Specialization = Specialization;
        }
        public string PrintDetails()
        {
            return $"InstructorId : {InstructorId}, Name : {Name},Specialization : {Specialization}";
        }


    }
    class Course
    {
        public int CourseId;
        public string Title;
        public Instructor Instructor;
        public Course(int courseId, string title, Instructor instructor)
        {
            this.CourseId = courseId;
            this.Title = title;
            this.Instructor = instructor;
        }

        public string PrintDetails()
        {
            return $"Course id : {CourseId},Title : {Title},Instructor : {Instructor} ";
        }
    }

    class Student
    {

        public int StudentId;
        public string Name;
        public int age;
        List<Course> Courses = new List<Course>();


        public Student(int studentId, string name, int age)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.age = age;
        }
        public bool Enroll(Course course)
        {
            Courses.Add(course);
            return true;
        }
        public string PrintDetails()
        {
            return $"Student id: {StudentId}, Name: {Name}, Age: {age}";
        }
    }
    class StudentManager
    {
        List<Student> Students = new List<Student>();
        List<Course> Courses = new List<Course>();
        List<Instructor> Instructors = new List<Instructor>();
        public bool AddStudent(Student student)
        {
            Students.Add(student); return true;
        }
        public bool AddCourse(Course course)
        {
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            Instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int studentId)
        {
            foreach (Student student in Students)
            {
                if (student.StudentId == studentId)
                {
                    return student;
                }
            }


            return null;
        }
        public Course FindCourse(int courseId)
        {
            foreach (Course course in Courses)
            {
                if (course.CourseId == courseId)
                {
                    return course;

                }
            }
            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            foreach (Instructor instructor in Instructors)
            {
                if (instructor.InstructorId == instructorId)
                {
                    return instructor;
                }
            }
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student == null || course == null)
            {
                return false;
            }

            return student.Enroll(course);
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            do
            {
                Console.WriteLine("=====================");
                Console.WriteLine("1 = Add Student");
                Console.WriteLine("2 = Add Instructor");
                Console.WriteLine("3 = Add Course");
                Console.WriteLine("4 = Enroll Student in Course");
                Console.WriteLine("5 = Show All Students");
                Console.WriteLine("6 = Show All Courses");
                Console.WriteLine("7 = Show All Instructors");
                Console.WriteLine("8 = Find the student by id or name");
                Console.WriteLine("9 = Fine the course by id or name");
                Console.WriteLine("10 = Exit");
                Console.WriteLine("=====================\n");
                Console.Write("==>  ");

                string choice = (Console.ReadLine());
                if (choice == "1")
                {

                    Console.Write("\nEnter Student ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Student Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.WriteLine("");

                    Student student = new Student(id, name, age);

                    manager.AddStudent(student);
                }
                else if (choice == "2")
                {
                    Console.Write("enter instructor iD: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("enter instructor name: ");
                    string name = Console.ReadLine();
                    Console.Write("enter instructor specialization: ");
                    string specialization = Console.ReadLine();
                    Instructor instructor = new Instructor(id, name, specialization);
                    manager.AddInstructor(instructor);
                }
                else if (choice=="3")
                {
                    Console.Write("enter course iD: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("enter course name: ");
                    string title = Console.ReadLine();
                    Console.Write("enter instructor iD: ");
                    int instructorId = int.Parse(Console.ReadLine());
                    Instructor instructor = manager.FindInstructor(instructorId);
                    if (instructor == null)
                    {
                        Console.WriteLine("instructor not found!");
                    }
                    else
                    {
                        Course course = new Course(id, title, instructor);
                        manager.AddCourse(course);
                        Console.WriteLine("Course added successfully!");
                    }
                }

                

            } while (true);
        }
    }
}
    

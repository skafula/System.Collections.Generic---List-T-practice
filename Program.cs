using System.Net.Cache;
using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        //searching for an property's value of an object
        List<Student> students = new List<Student>()
        {
            new Student() { Age = 10, Name = "john" },
            new Student() { Age = 20, Name = "andrew"},
            new Student() { Age = 12, Name = "marina"},
            new Student() { Age = 30, Name = "scott"}
        };

        foreach (Student student in students)
        {
            Console.WriteLine(student.Name + " " + student.Age);
        }

        students.RemoveAll(student => student.Age < 20);

        foreach (Student student in students)
        {
            Console.WriteLine("Student(s) after 'RemoveAll': ");
            Console.WriteLine(student.Name + " " + student.Age);
        }
        List<int> list = new List<int>() { 1, 3, 5, 2, 4, 5 };

        //practice index of
        int indexOf = list.IndexOf(1, 1);
        Console.WriteLine("IndexOf");
        Console.WriteLine(indexOf > -1 ? indexOf : "list doesn't contain the searched number");

        // for binary search (works faster at longer lists). it must be presorted
        List<int> listBinarySearch = new List<int>() { 1, 2, 3, 4, 5, 6 };
        Console.WriteLine("\nBinarySearch");
        int indexOfBinaryS = listBinarySearch.BinarySearch(3);
        Console.WriteLine(indexOfBinaryS > -1 ? indexOfBinaryS : "list doesn't contain the searched number");

        Console.WriteLine("\nContains");
        Console.WriteLine(list.Contains(4) ? list.IndexOf(4) : "list doesn't contain the searched number");

        Console.WriteLine("\nSort");
        Console.WriteLine("List before sorting: ");
        foreach (int i in list)
        {
            Console.Write(i + " ");
        }

        list.Sort();
        Console.WriteLine("\n\nList after sorting: ");

        foreach (int i in list)
        {
            Console.Write(i + " ");
        }

        list.Reverse();
        Console.WriteLine("\n\nReverse: ");

        foreach (int i in list)
        {
            Console.Write(i + " ");
        }

        // ToArray() method makes the object so only need to declare a refVariable to the array without creating instance object with new keyword
        Console.WriteLine("\n\nTo Array:");
        Student[] studentArray = students.ToArray();
        foreach (Student student in studentArray)
        {
            Console.WriteLine(student.Name);
        }
        // ForEach works with Action<T> 
        Console.WriteLine("\nForEach: ");
        students.ForEach(student => Console.WriteLine(student.Age + " " + student.Name));

        //Exists works with Predicate<T>. It iterates all element of the list whatever if value found before last element.
        Console.WriteLine("\nExists: ");
        Console.WriteLine(list.Exists(num => num > 4) ? "List contains number 4" : "List doesn't contain number 4");

        //Find is also a predicate but it returns the value of the first match, or default value if there's no match
        Console.WriteLine("\nFind: ");
        Student findFirstStudentOver20 = students.Find(student => student.Age > 20);
        Console.WriteLine(findFirstStudentOver20?.Age);

        //Find gives back in this example an Object so i could save the object in a Student typed reference variable to show the Age value (howevere 
        //here's no match so the refVariable would be null. As the example shows.
        Console.WriteLine(students.Find(student => student.Age > 30) == null ? "There's no match" : "There's at least one student over 30");

        //FindIndex(Predicate<T>) returns the first match's index. If there's no match returns -1
        Console.WriteLine("\nFindIndex: ");
        Console.WriteLine(list.FindIndex(number => number < 2));

        //FindLast is same as Find, but with the last match
        //FindLastIndex is same as FindIndex but with the last match's index

        //FindAll(Predicate<T>) makes a new List<T> object with every matching value/object
        students.AddRange(new List<Student>()
        {
            new Student() { Age = 19, Name = "emily" },
            new Student() { Age = 23, Name = "marcus"}
        });

        Console.WriteLine("\nFindAll: ");
        foreach (Student student in students.FindAll(student => student.Age > 20))
        {
            Console.WriteLine(student.Name + " " + student.Age);
        }

        //ConvertAll works with objects, but with upcast th original object may lost its accessability for some properties or methods. Downcast doesn't work directly
        //with this method. With value types it's easier
        Console.WriteLine("\nConvertAll with primitive");

        List<double> convertedList = list.ConvertAll(element => Convert.ToDouble(element));
        convertedList.ForEach(element => Console.Write(element + " "));

        Console.WriteLine("\n\nConvertAll with objects");
        List<Human> convertedStudents = students.ConvertAll(student => (Human)student);
        convertedStudents.ForEach(student => Console.Write(student.Age + " "));

        Console.WriteLine("\n\nAnother syntax");
        List<string> convertedStrings = list.ConvertAll<string>(n =>
        {
            switch (n)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
                case 10: return "Ten";
                default: return "";
            }
        });
        convertedStrings.ForEach(s => Console.Write(s + " "));

        Console.WriteLine();
    }

    public class Student : Human
    {
        public string Name { get; set; }
    }
    public class Human
    {
        public int Age { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFiveClaases
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating a list of students
            List<Student> team = new List<Student>();

            //populate(team); //hardcoding elements
            makeTeam(team); //taking in

            while (char.ToUpper(menu(team)) != 'N')
                Console.Clear();

            Console.WriteLine("\n\nGoodbye");
        }

        static void makeTeam(List<Student> team)  //user-driven team
        {
            int size = 0, level = 0;
            string name = "";

            //asking large user wants team to be
            Console.Write("How many students do you want to add? ");

            //error-handling concisely by putting tryparse as the while's condition
            while (!Int32.TryParse(Console.ReadLine(), out size) || size <= 0)
                Console.Write("Invalid input, please enter a positive integer for team size: ");

            Console.Clear();

            //setting input as the limiter for team ==> asking for name and level of each student
            for (int i = 0; i < size; i++)
            {
                Console.Write("\nEnter student #{0}'s name: ", i + 1);  //asking name
                name = Console.ReadLine();

                Console.Write("Enter student #{0}'s level (integer number): ", i + 1); //asking level

                //error-handling concisely by putting tryparse as the while's condition
                while (!Int32.TryParse(Console.ReadLine(), out level) || level < 0)
                    Console.Write("Invalid input, please enter a positive integer for student's level: ");

                team.Add(new Student(name, level)); //instantiating every member with input
            }
            Console.Clear();
        }
        static char menu(List<Student> team)
        {
            int student = 0;
            char input = 'Z';

            //printing out every student
            for (int i = 0; i < team.Count; i++)
            {
                team[i].print();
                Console.WriteLine("(Press {0})\n", i+1);
            }

            Console.Write("Please enter the number of the student you wish to modify >>");
            student = Int32.Parse(Console.ReadLine()) - 1;

            //showing selected student then modifying based on input
            team[student].print();
            team[student].doSomething();

            //asking to continue, if no, then while look in Main will break.
            Console.Write("\nWould you like to continue? (Y/N) >>");
            input = Console.ReadKey().KeyChar; //input will be if user wants to coninue

            return input;
        }
        static List<Student> populate(List<Student> team)  //hard-coded team
        {
            //hardcoding students, one test case per rank
            team.Add(new Student("Steve Jobs", 0));
            team.Add(new Student("Sally Mae", 7));
            team.Add(new Student("Charles Findlay", 12));
            team.Add(new Student("Paul Janiczek", 18));
            team.Add(new Student("Bob Tabor", 21));

            return team;
        }
    }
}
class Student
{
    public string name;
    public int level;
    string rank;

    public Student()
    {
        level = 0;
        rank = "";
        name = "";
    }
    public Student(string id, int pts)
    {
        name = id;
        level = pts;
    }
    public void print()
    {
        string msg = findRank(this.level);
        Console.WriteLine("\n{0} is level {1} and rank {2}\n {3}", name, level, rank, msg);
    }
    public void doSomething()
    {
        int action;

        Console.Write("\nSelect a number: \nDid the student (1) Code a program, (2) Assist another student,");
        Console.Write("(3) Do nothing?\n>>");
        action = int.Parse(Console.ReadLine());

        switch (action)
        {
            case 1:
                level++;
                Console.WriteLine("Student's level has increased by one!");
                break;
            case 2:
                level = level + 2;
                Console.WriteLine("Student's level has increased by two!!");
                break;

            case 3: return;

            default: Console.WriteLine("Invalid number.\n"); break;
        }
    }
    private string findRank(int pts)
    {
        int switchcase = pts / 5;
        string msg = "", tempRank = rank;

        switch (switchcase)
        {
            case 0:
                rank = "Beginner";
                msg = "You are but a mere beginner still.";
                break;
            case 1:
                rank = "Grasshopper";
                msg = "You are a fledgling grasshopper.";
                break;

            case 2:
                rank = "Journeyman";
                msg = "You're a capable journeyman now!";
                break;

            case 3:
                rank = "Rock Star";
                msg = "Looks like we have a programming rock star on our hands!";
                break;

            case 4:
                rank = "Ninja";
                msg = "What a programming ninja you are!";
                break;

            case 5:
                rank = "Jedi";
                msg = "With you, the force is. Youre a programming Jedi!";
                break;
        }

        return msg;
    }
}
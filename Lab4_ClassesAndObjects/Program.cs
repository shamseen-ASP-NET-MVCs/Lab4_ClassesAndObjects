using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_ClassesAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //print all students THEN menu
            //char input = 'Y';

            //creating a list of students and hardcoding elements
            List<Student> team = new List<Student>();
            //populate(team);
            main2(team);

            //repeatedly asking user to modify students until user is done
            //while (char.ToUpper(input) != 'N')
            //    input = menu(team);

            while (char.ToUpper(menu(team)) != 'N')
                Console.Clear();

            Console.WriteLine("\n\nGoodbye");
        }

        static void  main2(List<Student> team)  //user-driven team
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
                Console.Write("\nEnter student #{0}'s name: ", i+1);  //asking name
                name = Console.ReadLine();

                Console.Write("Enter student #{0}'s level (integer number): ", i+1); //asking level

                //error-handling concisely by putting tryparse as the while's condition
                while (!Int32.TryParse(Console.ReadLine(), out level) || level < 0)
                    Console.Write("Invalid input, please enter a positive integer for student's level: ");

                team.Add(new Student(name, level)); //instantiating every member with input
            }
            Console.Clear();
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
        
        static char menu(List<Student> team)
        {
            int student = 0;
            char input = 'Z';

            for (int i = 0; i < team.Count; i++)
                team[i].print();

            Console.Write("Please enter the number of the student you wish to modify: ");
            student = Int32.Parse(Console.ReadLine()) - 1;

            //showing selected student and askign if this is who they wanted
            team[student].print();
            Console.Write("\nIs this the correct student? (Y/N) ");
            input = Console.ReadKey().KeyChar; //input will be if user selected correct student
            Console.Clear();

            if (char.ToUpper(input) == 'N')  //if user selected wrong student, show them menu again
                menu(team);
            else
                return input; //keeping rest of function from running while in recursive call

            team[student].doSomething(); //modifying student's level based on user input

            //asking to continue, if no, then while look in Main will break.
            Console.Write("Would you like to continue? (Y/N) ");
            input = Console.ReadKey().KeyChar; //input will be if user wants to coninue

            return input;
        }
        
        public class Student
        {
            string name;
            int level;
            string rank;

            public void print()
            { Console.WriteLine(this.name); }

            public Student(string name, int level)
            {
                this.name = name;
                this.level = level;
            }

            public void doSomething() { Console.WriteLine("[Ask to do something then increment]"); }

        }
        
    }
}

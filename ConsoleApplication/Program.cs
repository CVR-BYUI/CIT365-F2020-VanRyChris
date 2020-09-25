using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void MyIntro()
        {
            // Store variables
            string name = "Chris Van Ry";
            string location = "Utah";
            string introName = $"Hi, my name is {name}.";
            string introLocation = $"I am from {location}.";
            string date = DateTime.Now.ToString("MM-dd-yyyy");

            // Display variables using string interpolation
            Console.WriteLine(introName);
            Console.WriteLine(introLocation);

            // Display current date, but not time
            Console.WriteLine("Today is {0}.", date);
        }
        static void DaysUntilChristmas()
        {
            // Calculate days until Christmas
            DateTime christmas = new DateTime(2020, 12, 25);
            double daysLeft = christmas.Subtract(DateTime.Today).TotalDays;

            // Display days until Christmas
            Console.WriteLine("There are {0} days until Christmas.", daysLeft);
        }

        static void ProgramExample()
        {
            double width, height, woodLength, glassArea;
            string widthString, heightString;

            // Prompt user input with correct label
            Console.Write("What is the width of the window in meters?  ");
            widthString = Console.ReadLine();
            width = double.Parse(widthString);

            // Prompt user input with correct label
            Console.Write("What is the height of the window in meters? ");
            heightString = Console.ReadLine();
            height = double.Parse(heightString);

            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);

            Console.WriteLine("The length of the wood is " + woodLength + " feet.");
            Console.WriteLine("The area of the glass is " + glassArea + " square meters.");
        }
        static void Main()
        {
            MyIntro();
            DaysUntilChristmas();
            ProgramExample();

            // Don't automatically terminate program
            Console.WriteLine("To exit, press any key.");
            Console.ReadKey();
        }
    }
}
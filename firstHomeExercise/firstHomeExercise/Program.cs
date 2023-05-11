using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstHomeExercise
{
    public class Program
    {     
        static void Main(string[] args)
        {
            bool keepLooping = true;
            while (keepLooping)
            {
                keepLooping = false;
                Console.WriteLine("Hello\r\nYou have reached the building construction system\r\nIf you want to build a square tower press 1\r\nIf you want to build a triangle tower press 2\r\nTo exit press 3 ");
                string value = Console.ReadLine();
                int parsedValue;
                int.TryParse(value, out parsedValue);

                switch (parsedValue)
                {
                    case 1:
                        {
                            int height, width;
                            InputValues(out height, out width);

                            Rectangle rectangle = new Rectangle(height, width);
                            rectangle.Print();
                        }
                        break;
                    case 2:
                        {
                            int height, width;
                            InputValues(out height, out width);

                            Console.WriteLine("enter 1 to get the perimeter or 2 in order to print stars");
                            string val3 = Console.ReadLine();
                            int choice;
                            int.TryParse(val3, out choice);

                            Triangle triangle = new Triangle(height, width);
                            triangle.Print(choice == 1);
                            if (choice == 2)
                            {
                                keepLooping = true;
                            }
                        }
                        break;
                    case 3:
                        Environment.Exit(3);
                        break;
                    default:
                        Console.WriteLine("Error on input, please press 1-3 number");
                        break;
                }
            }
            Console.ReadKey();

        }

        private static void InputValues(out int height, out int width)
        {
            Console.WriteLine("Enter the height of the tower greater than two: ");
            string val = Console.ReadLine();
            int.TryParse(val, out height);

            Console.WriteLine("Enter the width of the tower: ");
            string val2 = Console.ReadLine();
            int.TryParse(val2, out width);
        }
    }
}

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
        public static int OddsCalculation(int width)
        {
            int cnt = 0;
            for (int i = width - 2; i > 1; i -= 2)
            {
                cnt++;
            }
            return cnt;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello\r\nYou have reached the building construction system\r\nIf you want to build a square tower press 1\r\nIf you want to build a triangle tower press 2\r\nTo exit press 3 ");
            string value = Console.ReadLine();
            int parsedValue;
            int.TryParse(value, out parsedValue);

            switch (parsedValue)
            {
                case 1://מלבן
                    {
                        int height, width;
                        InputValues(out height, out width);

                        Rectangle rectangle = new Rectangle(height, width);
                        rectangle.Print();
                    }
                    break;
                case 2://משולש
                    {
                        int height, width;
                        InputValues(out height, out width);

                        Console.WriteLine("enter 1 to get the perimeter or 2 in order to print stars");
                        string val3 = Console.ReadLine();
                        int choice;
                        int.TryParse(val3, out choice);


                        Triangle triangle = new Triangle(height, width);
                        triangle.Print(choice == 1);
                                               

                    }
                    break;
                case 3://לבדוק אם נכון 
                    Environment.Exit(3);
                    break;
                default:
                    break;
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

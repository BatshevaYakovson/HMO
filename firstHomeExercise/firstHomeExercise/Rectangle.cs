using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstHomeExercise
{
    public class Rectangle : Polygon
    {
        public Rectangle(int height, int width) :base(height, width) 
        {
            
        }
        public override double CalcArea()
        {
            return height * width;
        }

        public override double CalcPerimeter()
        {
            return (height + width)*2;
        }

        public override void Print(bool? printPerimeter= null)
        {
            if(width == height || Math.Abs(width - height) > 5)
            {
                Console.WriteLine("your area is: " + CalcArea());
            }
            else
            {
                Console.WriteLine("your perimeter is: " + CalcPerimeter());
            }
        }
    }
}

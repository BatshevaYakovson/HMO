using System;

namespace firstHomeExercise
{
    public class Triangle : Polygon
    {
        public Triangle(int height,int width) :base(height, width) 
        {
        }
        public override double CalcArea()
        {
           throw new NotImplementedException();

        }

        public override double CalcPerimeter()
        {

            double baseTriangular = width / 2;
            double side = Math.Sqrt(Math.Pow(baseTriangular, 2) + Math.Pow(height, 2));
            double perimeterTriangular = side * 2 + width;
            return perimeterTriangular;
        }

        public override void Print(bool? printPerimeter)
        {
            if (printPerimeter.HasValue && printPerimeter.Value) {

                Console.WriteLine("your perimeter is: "+ CalcPerimeter());
                return;
            }
            if (Validate())
            {
                PrintStars();
            }

            else { Console.WriteLine("cannot print this triangle");  }

        }

        private void PrintStars()
        {
            throw new NotImplementedException();
        }

        private bool Validate()
        {
            return !(width % 2 == 0 || height * 2 < width);
            
        }
    }
}

using System;

namespace firstHomeExercise
{
    public class Triangle : Polygon
    {
        public Triangle(int height, int width) : base(height, width)
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
            if (printPerimeter.HasValue && printPerimeter.Value)
            {
                Console.WriteLine("your perimeter is: " + CalcPerimeter());
                return;
            }
            if (Validate())
            {
                PrintStars();
            }

            else { Console.WriteLine("cannot print this triangle"); }
        }

        private void PrintStars()
        {

            int j, starNumber, countOdds, repeatRows, remainder, repeatRowsCnt, spaceCnt;

            countOdds = CountOdds(width);
            repeatRows = (height - 2) / countOdds;
            remainder = (height - 2) % countOdds;
            repeatRowsCnt = repeatRows;
            spaceCnt = width / 2;

            PrintFirstRow(spaceCnt);

            starNumber = 3;
            for (int i = 0; i <= height - 2; i++)
            {
                if (remainder > 0)
                {
                    repeatRowsCnt += remainder;
                    remainder = 0;
                }

                if (repeatRowsCnt == 0 && starNumber < width)
                {
                    repeatRowsCnt = repeatRows;
                    starNumber += 2;
                    spaceCnt--;
                }
                for (j = 0; j < spaceCnt - 1; j++)
                {
                    Console.Write(" ");
                }
                for (j = 1; j <= starNumber; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
                repeatRowsCnt--;
            }
        }

        private void PrintFirstRow(int spaceCnt)
        {
            for (int i = 0; i < width; i++)
            {
                if (i < spaceCnt)
                    Console.Write(" ");
                if (i == width / 2)
                    Console.Write("*");
            }
            Console.WriteLine();
        }

        private bool Validate()
        {
            return !(width % 2 == 0 || height * 2 < width);

        }
        private int CountOdds(int width)
        {
            int cnt = 0;
            for (int i = width - 2; i > 1; i -= 2)
            {
                cnt++;
            }
            return cnt == 0? 1:cnt;//not return 0
        }
    }
}

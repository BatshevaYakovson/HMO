using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstHomeExercise
{
    public abstract class Polygon
    {
        public int height;
        public int width;
        public Polygon(int height, int width)
        {
            this.height = height;
            this.width = width;
        }
        public abstract double CalcPerimeter();

        public abstract double CalcArea();

        
        public abstract void Print(bool? printPerimeter = null);
        
    }
}

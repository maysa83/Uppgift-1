using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Point a = new Point(8, 0);
            Point b = new Point(0, 0);
            Point c = new Point(0, 5);

            //Testar om konstruktorn räknar rätt när den utgår från punkterna - FAIL
            Triangle tri = new Triangle(a, b, c);
            
        }
    }
}

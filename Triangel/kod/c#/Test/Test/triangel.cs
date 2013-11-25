using System;
using System.Linq;
using System.Collections.Generic;

public struct Point
{
    public int x, y;

    public Point(int a, int b)
    {
        x = a;
        y = b;
    }
}

public class Triangle
{
    double[] sides;

    //Egenskap
    private double[] MyProp
    {
        get { return sides; }
        set
        {
            if (value.Length != 3)
            {
                throw new ArgumentException("Du har antingen angett fler eller färre än 3 värden");
            }
            foreach (double item in value)
            {
                if (item <= 0)
                {
                    throw new ArgumentException("felaktigt inmatat värde");
                }
            }
            sides = value;
        }
    }

    public Triangle(double a, double b, double c)
    {
        MyProp = new double[] { a, b, c };
    }

    public Triangle(double[] s)
    {
        MyProp = s;
    }

    public Triangle(Point a, Point b, Point c)
    {
        sides = new double[3];
        sides[0] = Math.Sqrt(Math.Pow((double)(c.x - a.x), 2.0) + Math.Pow((double)(c.y - a.y), 2.0));
        sides[1] = Math.Sqrt(Math.Pow((double)(b.x - a.x), 2.0) + Math.Pow((double)(b.y - a.y), 2.0));
        sides[2] = Math.Sqrt(Math.Pow((double)(c.x - b.x), 2.0) + Math.Pow((double)(c.y - b.y), 2.0));
    }

    public Triangle(Point[] s)
    {
        if (s.Length != 3)
        {
            throw new ArgumentException("Arrayen innehåller inte 3 värden");
        }
        MyProp = FixedMethod(s);
    }

    public double[] FixedMethod(Point[] side)
    {
        sides = new double[3];
        sides[0] = Math.Sqrt(Math.Pow((double)(side[2].x - side[0].x), 2.0) + Math.Pow((double)(side[2].y - side[0].y), 2.0));
        sides[1] = Math.Sqrt(Math.Pow((double)(side[1].x - side[0].x), 2.0) + Math.Pow((double)(side[1].y - side[0].y), 2.0));
        sides[2] = Math.Sqrt(Math.Pow((double)(side[2].x - side[1].x), 2.0) + Math.Pow((double)(side[2].y - side[1].y), 2.0));
        return sides;
    }

    private int uniqueSides()
    {
        return sides.Distinct<double>().Count();
    }
    
    public bool isScalene()
    {
        if (uniqueSides() == 3)
            return true;
        return false;
    }
    //likbent
    public bool isEquilateral()
    {
        if (uniqueSides() == 1)
            return true;
        return false;
    }
    //liksidig
    public bool isIsosceles()
    {
        if (uniqueSides() == 2)
            return true;
        return false;
    }
}

/* Exempel på användning: */
/* class Program { */
/*   static void Main(string[] args) { */
/*     double[] input = new double[3]; */
/*     for(int i=0;i<3;i++) */
/*       input[i]=double.Parse(args[i]); */

/*     Triangle t = new Triangle(input); */

/*     if(t.isScalene()) Console.WriteLine("Triangeln har inga lika sidor"); */
/*     if(t.isEquilateral()) Console.WriteLine("Triangeln är liksidig"); */
/*     if(t.isIsosceles()) Console.WriteLine("Triangeln är likbent"); */
/*  } */
/* } */
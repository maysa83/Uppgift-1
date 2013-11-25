using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using System.Threading;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Test av liksidig triangel
        public void isIsoscelesTest()
        {
            //Test med 3 olika argument och borde returnera false - PASS
            Triangle tri = new Triangle(1, 3.5, 5);
            Assert.IsFalse(tri.isIsosceles());
        }
        
        [TestMethod]
        //Test av liksidig triangel
        public void isIsoscelesTest_1()
        {
            //Test med 3 lika argument och borde returnera false - PASS
            Triangle tri1 = new Triangle(4, 4, 4);
            Assert.IsFalse(tri1.isIsosceles());
        }
        
        [TestMethod]
        //Test av liksidig triangel
        public void isIsoscelesTest_2()
        {
            //Test med 2 lika argument och borde returnera true - PASS
            Triangle tri2 = new Triangle(4, 4, 5);
            Assert.IsTrue(tri2.isIsosceles());
        }
        
        [TestMethod]
        //Test av likbent triangel
        public void isEquilateralTest()
        {
            //Test med 3 olika argument och borde returnera false - FAIL
            Triangle equ = new Triangle(1, 3.5, 5);
            Assert.IsFalse(equ.isEquilateral());
        }
        
        [TestMethod]
        //Test av likbent triangel
        public void isEquilateralTest_1()
        {
            //Test med 3 lika argument och borde returnera true - FAIL
            Triangle equ2 = new Triangle(4, 4, 4);
            Assert.IsTrue(equ2.isEquilateral());
        }

        [TestMethod]
        //Test av likbent triangel
        public void isEquilateralTest_2()
        {
            //Test med 2 lika argument och borde returnera false - PASS
            Triangle equ1 = new Triangle(4, 4, 5);
            Assert.IsFalse(equ1.isEquilateral());
        }

        [TestMethod]
        //Test av triangel med olika sidor
        public void isScaleneTest()
        {
            //Test med 3 olika argument och borde returneara true - FAIL
            Triangle sca = new Triangle(1, 3.5, 5);
            Assert.IsTrue(sca.isScalene());
        }

        [TestMethod]
        //Test av triangel med olika sidor
        public void isScaleneTest_1()
        {
            //Test med 2 lika argument och borde returnera false - FAIL
            Triangle sca1 = new Triangle(3.5, 3.5, 5);
            Assert.IsFalse(sca1.isScalene());
        }

        [TestMethod]
        //Test av triangel med olika sidor
        public void isScaleneTest_2()
        {
            //Test med 3 lika argument och borde returnera false - FAIL
            Triangle sca2 = new Triangle(3.5, 3.5, 3.5);
            Assert.IsFalse(sca2.isScalene());
        }

        [TestMethod]
        //Test av konstruktor
        public void TriangleConstructorTest()
        {
            double[] sides = (double[])GetFieldValue(new Triangle(1, 1, 1), "sides");

            //Testar så att reflection fungerar och att fältet sides får ett värde - PASS
            Assert.IsTrue(sides[0] == 1 && sides[1] == 1 && sides[2] == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleConstructorTest_1()
        {
            //Testar att konstruktorn inte godkänner 0 och kastar ett undantag - FAIL
            double[] sides1 = (double[])GetFieldValue(new Triangle(0, 1, 1), "sides");
            CollectionAssert.AreEqual(new double[] { 0, 1, 1 }, sides1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleConstructorTest_2()
        {
            //Testar så att negativa värden inte fungerar och kastar ett undantag - FAIL
            double[] sides2 = (double[])GetFieldValue(new Triangle(-1, 1, 1), "sides");
            CollectionAssert.AreEqual(new double[] { -1, 1, 1 }, sides2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleConstructorTest_3()
        {
            //Testar så att den känner av om ett värde in stämmer och kastar ett undantag - FAIL
            double[] sides2 = (double[])GetFieldValue(new Triangle(-1, 1, 1), "sides");
            CollectionAssert.AreNotEqual(new double[] { 2, 1, 1 }, sides2);
        }
        [TestMethod]
        public void TriangleConstructArrayTest()
        {
            //Testar den andra konstruktorn så att sides får 3 värden, ett tal är ett flyttal - PASS
            double[] sides = (double[])GetFieldValue(new Triangle(new double[] { 1.2, 2, 3 }), "sides");
            Assert.IsTrue(sides[0] == 1.2 && sides[1] == 2 && sides[2] == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleConstrucArrayTest_1()
        {
            //Testar konstruktorn med enbart 2 värden - FAIL
            double[] sides1 = (double[])GetFieldValue(new Triangle(new double[] { 1, 2 }), "sides");
            Assert.IsFalse(sides1[0] == 1 && sides1[1] == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleConstrucArrayTest_2()
        {
            //Testar konstruktorn med fler än 3 värden - FAIL
            double[] sides2 = (double[])GetFieldValue(new Triangle(new double[] { 1, 2, 3, 4 }), "sides");
            Assert.IsFalse(sides2[0] == 1 && sides2[1] == 2 && sides2[2] == 3 && sides2[3] == 4);
        }

        [TestMethod]
        public void PointConstructTest()
        {
            //Välja sidan 8 och 5 så ska hypotenusan bli 10

            Point a = new Point(8, 0);
            Point b = new Point(0, 0);
            Point c = new Point(0, 5);

            //Testar om konstruktorn räknar rätt när den utgår från punkterna - FAIL
            double[] sides = (double[])GetFieldValue(new Triangle(a, b, c), "sides");
            Assert.IsTrue(sides[0] == Math.Sqrt(89) && sides[1] == 8 && sides[2] == 5);
        }
        [TestMethod]
        public void PointConstructArrayTest()
        {
            //Är sidorna 3 och 4 så ska hypotenusan bli 5
            Point a = new Point(-3, 0);
            Point b = new Point(0, 4);
            Point c = new Point(0, 0);

            //Testar att konstruktorn räknar rätt med dessa punkter - FAIL
            double[] sides = (double[])GetFieldValue(new Triangle(new Point[]{a, b, c}), "sides");
            Assert.IsTrue(sides[0] == 3);
            Assert.IsTrue(sides[1] == 5);
            Assert.IsTrue(sides[2] == 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PointConstructArrayTest_1()
        {
            //Skapar bara 2 punkter
            Point a = new Point(-3, 0);
            Point b = new Point(0, 4);

            //Testar att konstruktorn kastar ett undantag om man bara har 2 argument - FAIL
            double[] sides = (double[])GetFieldValue(new Triangle(new Point[] { a, b}), "sides");
            Assert.IsTrue(sides[0] == 3);
            Assert.IsTrue(sides[1] == 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PointConstructArrayTest_2()
        {
            //Skapar 4 punkter
            Point a = new Point(-3, 0);
            Point b = new Point(0, 4);
            Point c = new Point(0, 0);
            Point d = new Point(0, 0);

            //Testar att konstruktorn kastar ett undantag om man har 4 argument - FAIL
            double[] sides = (double[])GetFieldValue(new Triangle(new Point[] { a, b, c, d }), "sides");
            Assert.IsTrue(sides[0] == 3);
            Assert.IsTrue(sides[1] == 4);
            Assert.IsTrue(sides[2] == 5);
            Assert.IsTrue(sides[3] == 0);
        }
        
        //Kopierat av Mats Lock
        private static object GetFieldValue(object sn, string name)
        {
            var field = sn.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null)
            {
                throw new ApplicationException(String.Format("FEL! Det privata fältet {0} saknas.", name));
            }
            return field.GetValue(sn);
        }
    }
}

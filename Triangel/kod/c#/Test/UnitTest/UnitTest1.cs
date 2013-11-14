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
        //Test av likbent triangel
        public void isIsoscelesTest()
        {
            //Test med 3 olika argument och borde returnera false - PASS
            Triangle tri = new Triangle(1, 3.5, 5);
            Assert.IsFalse(tri.isIsosceles());

            //Test med 3 lika argument och borde returnera false - PASS
            Triangle tri1 = new Triangle(4, 4, 4);
            Assert.IsFalse(tri1.isIsosceles());

            //Test med 2 lika argument och borde returnera true - PASS
            Triangle tri2 = new Triangle(4, 4, 5);
            Assert.IsTrue(tri2.isIsosceles());
        }
        [TestMethod]
        //Test av liksidig triangel
        public void isEquilateralTest()
        {
            //Test med 3 olika argument och borde returnera false - FAIL
            Triangle equ = new Triangle(1, 3.5, 5);
            Assert.IsFalse(equ.isEquilateral());

            //Test med 2 lika argument och borde returnera false - PASS
            Triangle equ1 = new Triangle(3.5, 3.5, 5);
            Assert.IsFalse(equ1.isEquilateral());

            //Test med 3 lika argument och borde returnera true - FAIL
            Triangle equ2 = new Triangle(3.5, 3.5, 3.5);
            Assert.IsTrue(equ2.isEquilateral());

        }
        [TestMethod]
        //Test av triangel med olika sidor
        public void isScaleneTest()
        {
            //Test med 3 olika argument och borde returneara true - FAIL
            Triangle sca = new Triangle(1, 3.5, 5);
            Assert.IsTrue(sca.isScalene());

            //Test med 2 lika argument och borde returnera false - PASS
            Triangle sca1 = new Triangle(3.5, 3.5, 5);
            Assert.IsFalse(sca1.isScalene());

            //Test med 3 lika argument och borde returnera false - FAIL
            Triangle sca2 = new Triangle(3.5, 3.5, 3.5);
            Assert.IsFalse(sca2.isScalene());

        }
        [TestMethod]
        //Test av konstruktor
        public void TriangleTest()
        {
            double[] sides = (double[])GetFieldValue(new Triangle(1, 1, 1), "sides");

            //Testar så att reflection fungerar och att fältet sides får ett värde - PASS
            Assert.IsTrue(sides[0] == 1 && sides[1] == 1 && sides[2] == 1);

            ////Testar att konstruktorn inte godkänner 0 och det borde returnera false - PASS
            //double[] sides1 = (double[])GetFieldValue(new Triangle(0, 1, 1), "sides");
            //CollectionAssert.AreNotEqual(new double[] { 0, 1, 1 }, sides1);

            ////Testar så att negativa värden inte fungerar och borde returnera false - PASS
            //double[] sides2 = (double[])GetFieldValue(new Triangle(-1, 1, 1), "sides");
            //CollectionAssert.AreNotEqual(new double[] { -1, 1, 1 }, sides2);
        }
        [TestMethod]
        public void TriangleTest1()
        {
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

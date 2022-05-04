using NUnit.Framework;
using Square_.Shapes;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void CircleWrongRadiusTest() => Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));

        [Test]
        public async Task CircleSquareTest()
        {
            var circle = new Circle(1);

            Assert.AreEqual(circle.GetSquare(), 3.141592653589793);
            Assert.AreEqual(await circle.GetSquareAsync(), 3.141592653589793);
            Assert.AreEqual(circle.Square, 3.141592653589793);
        }

        [Test]
        public void TriangleWrongSidesTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2, 0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, -2, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 0, -2));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2, -2, -2));

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0.5, 0.5, 1));
        }

        [Test]
        public async Task TriangleSquareTest()
        {
            var triangle = new Triangle(4, 6, 8);

            Assert.AreEqual(triangle.GetSquare(), 11.61895003862225);

            Assert.AreEqual(triangle.Square, 11.61895003862225);

            Assert.AreEqual(await triangle.GetSquareAsync(), 11.61895003862225);
        }

        [Test]
        public void IsRightTriangleTest()
        {
            var triangle = new Triangle(3, 4, 5);

            Assert.IsTrue(triangle.IsRightTriangle);
        }

        [Test]
        public void IsNotRightTriangle()
        {
            var triangle = new Triangle(1, 1, 1);

            Assert.IsFalse(triangle.IsRightTriangle);
        }

    }
}
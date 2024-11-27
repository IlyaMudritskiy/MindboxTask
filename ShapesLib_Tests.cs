using NUnit.Framework;
using GeometryLibrary;
using System;

namespace ShapesLibTests
{
    [TestFixture]
    public class ShapesLibTests
    {
        // Тесты для круга
        [Test]
        public void Circle_GetArea_ShouldReturnCorrectValue()
        {
            var circle = ShapeFactory.CreateCircle(10);
            double area = circle.GetArea();
            Assert.AreEqual(Math.PI * 100, area, 0.0001);
        }

        [Test]
        public void Circle_Constructor_ShouldThrowException_IfRadiusIsNegativeOrZero()
        {
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateCircle(0));
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateCircle(-5));
        }

        // Тесты для треугольника
        [Test]
        public void Triangle_GetArea_ShouldReturnCorrectValue()
        {
            var triangle = ShapeFactory.CreateTriangle(3, 4, 5);
            double area = triangle.GetArea();
            Assert.AreEqual(6, area, 0.0001);
        }

        [Test]
        public void Triangle_Constructor_ShouldThrowException_ForInvalidSides()
        {
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateTriangle(1, 1, 10));
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateTriangle(-3, 4, 5));
        }

        [Test]
        public void Triangle_IsRightAngled_ShouldReturnTrueForRightTriangle()
        {
            var triangle = ShapeFactory.CreateTriangle(3, 4, 5);
            Assert.IsTrue(((Triangle)triangle).IsRightAngled());
        }

        [Test]
        public void Triangle_IsRightAngled_ShouldReturnFalseForNonRightTriangle()
        {
            var triangle = ShapeFactory.CreateTriangle(3, 4, 6);
            Assert.IsFalse(((Triangle)triangle).IsRightAngled());
        }

        // Интеграционные тесты
        [Test]
        public void ShapeAreaCalculator_ShouldCalculateCorrectAreas_ForDifferentShapes()
        {
            var circle = ShapeFactory.CreateCircle(10);
            var triangle = ShapeFactory.CreateTriangle(3, 4, 5);

            double circleArea = ShapeAreaCalculator.GetArea(circle);
            double triangleArea = ShapeAreaCalculator.GetArea(triangle);

            Assert.AreEqual(Math.PI * 100, circleArea, 0.0001);
            Assert.AreEqual(6, triangleArea, 0.0001);
        }

        [Test]
        public void ShapeAreaCalculator_ShouldThrowArgumentNullException_WhenShapeIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => ShapeAreaCalculator.GetArea(null));
        }
    }
}

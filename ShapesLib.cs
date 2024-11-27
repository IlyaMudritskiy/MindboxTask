using System;

namespace GeometryLibrary
{
    // Интерфейс для всех геометрических фигур
    public interface IShape
    {
        double GetArea();
    }

    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус должен быть больше нуля.", nameof(radius));
            
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString() => $"Circle, R = {Radius}";
    }

    public class Triangle : IShape
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("Все стороны треугольника должны быть больше нуля.");
            
            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
                throw new ArgumentException("Стороны не могут образовать треугольник.");
            
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double GetArea()
        {
            double halfPerimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));
        }

        public bool IsRightAngled()
        {
            double[] sides = { SideA, SideB, SideC };
            Array.Sort(sides); 
            return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 0.0001;
        }

        public override string ToString() => $"Triangle (Sides = {SideA}, {SideB}, {SideC})";
    }

    // Фабрика для простого создания фигур и добавления новых
    public static class ShapeFactory
    {
        public static IShape CreateCircle(double radius)
        {
            return new Circle(radius);
        }

        public static IShape CreateTriangle(double sideA, double sideB, double sideC)
        {
            return new Triangle(sideA, sideB, sideC);
        }
    }

    // Вычисление площади фигуры без знания типа фигуры
    public static class ShapeAreaCalculator
    {
        public static double CalculateArea(IShape shape)
        {
            if (shape == null) throw new ArgumentNullException(nameof(shape));
            return shape.GetArea();
        }
    }
}

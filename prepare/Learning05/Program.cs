using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("red", 5);

        string color = square.GetColor();
        Console.WriteLine("Color: " + color);

        double area = square.GetArea();
        Console.WriteLine("Area: " + area);
        Console.WriteLine("");

        Rectangle rectangle = new Rectangle("Blue", 10, 5);
        string rectangleColor = rectangle.GetColor();
        Console.WriteLine("Color: " + rectangleColor);

        double rectangleArea = rectangle.GetArea();
        Console.WriteLine("Area: " + rectangleArea);
        Console.WriteLine("");

        Circle circle = new Circle("Pink", 3);
        string circleColor = circle.GetColor();
        Console.WriteLine("Color: " + circleColor);

        double circleArea = circle.GetArea();
        Console.WriteLine("Area: " + circleArea);
    }
}
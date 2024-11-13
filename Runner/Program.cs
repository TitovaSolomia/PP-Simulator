using Simulator.Maps;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

internal class Program
{
    static void Lab5a()
    {
        try
        {
            Rectangle rect1 = new Rectangle(5, 1, 5, 1); // rzuca wyjątek
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Wyjatek prostokata num1: {ex.Message}");
        }

        try
        {
            Rectangle rect2 = new Rectangle(1, 1, 5, 5);
            Console.WriteLine($"Tworzenie zwyklego prostokata num2: {rect2}");

            // Przestawiania współrzędnych
            Rectangle rect3 = new Rectangle(5, 5, 1, 1);
            Console.WriteLine($"Prostokat num3 z przestawianymi wspolrzednymi: {rect3}");

            // Tworzenie prostokąta z punktów
            Point p1 = new Point(2, 3);
            Point p2 = new Point(7, 8);
            Rectangle rect4 = new Rectangle(p1, p2);
            Console.WriteLine($"Prostokat utworzony z punktow num4: {rect4}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Wyjatek: {ex.Message}");
        }

        // Testowanie zawierania punktów
        Rectangle rect = new Rectangle(0, 0, 10, 10);
        Point insidePoint = new Point(5, 5);
        Point outsidePoint = new Point(15, 15);

        Console.WriteLine($"\nRectangle: {rect}");
        Console.WriteLine($"Contains {insidePoint}: {rect.Contains(insidePoint)}");
        Console.WriteLine($"Contains {outsidePoint}: {rect.Contains(outsidePoint)}");

    }

    static void Lab5b()
    {
        SmallSquareMap squareMap = new SmallSquareMap(10);

        Point currentPos = new Point(0, 0);
        Console.WriteLine(currentPos);

        currentPos = squareMap.Next(currentPos, Direction.Up);
        currentPos = squareMap.NextDiagonal(currentPos, Direction.Up);

        Console.WriteLine(currentPos);

        for (int i = 0; i < 10; i++)
        {
            currentPos = squareMap.NextDiagonal(currentPos, Direction.Up);
            Console.WriteLine(currentPos);
        }

        try
        {
            SmallSquareMap squareMap1 = new SmallSquareMap(2);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    static void Main(string[] args)
    {
        Lab5a();
        Lab5b();
    }

}
    


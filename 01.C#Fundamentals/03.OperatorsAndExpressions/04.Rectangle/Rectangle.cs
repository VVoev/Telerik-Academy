﻿using System;

class Rectangle
{
    static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Console.WriteLine("{0:F2} {1:F2}", width * height, 2 * (width + height));
    }
}

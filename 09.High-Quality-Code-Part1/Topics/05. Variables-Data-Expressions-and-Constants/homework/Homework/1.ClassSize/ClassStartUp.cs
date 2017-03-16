using System;

public class Size
{
    private double width;
    private double height;

    public Size(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public double Width
    {
        get
        {
            return this.width;
        }

        set
        {
            this.CheckValue(value);
            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }

        set
        {
            this.CheckValue(value);
            this.height = value;
        }
    }

    public static Size GetRotatedSize(Size currentSize, double angleOfTheFigureThatWillBeRotaed)
    {
        return new Size(
            (Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * currentSize.Width) +
            (Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * currentSize.Height),
            (Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * currentSize.Width) +
            (Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * currentSize.Height));
    }

    private void CheckValue(double value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException($@"{value} cannot be less than 0");
        }
    }
}
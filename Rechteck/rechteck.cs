namespace Rechteck;

public class rechteck
{
    public double height {get; set;}
    public double width {get; set;}

    public rechteck(double height, double width)
    {
        this.height = height;
        this.width = width;
    }

    internal double GetArea()
    {
        return height * width;
    }
}
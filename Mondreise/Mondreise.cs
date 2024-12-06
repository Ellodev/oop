namespace Mondreise;

public class mondreise
{
    private double speedKmh;

    public mondreise(double speedKmh)
    {
        this.speedKmh = speedKmh;
    }

    internal double GetTravelDurationDays()
    {
        return 384400 / speedKmh * 24;
    }

    internal double GetTravelDurationHours()
    {
        return 384400 / speedKmh;
    }

}
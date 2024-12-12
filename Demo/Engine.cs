namespace Demo;

public class Engine
{
    public double AmountLiter { get; }
    public int HorsePower { get; }
    public bool IsStarted { get; set; }

    public Engine(double amountLiter, int horsePower)
    {
        AmountLiter = amountLiter;
        HorsePower = horsePower;
        IsStarted = false;
    }

    public override string ToString()
    {
        return $"AmountLiter: {AmountLiter}, HorsePower: {HorsePower}, IsStarted: {IsStarted}";
        
    }

    protected bool Equals(Engine other)
    {
        return AmountLiter.Equals(other.AmountLiter) && HorsePower == other.HorsePower;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Engine)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(AmountLiter, HorsePower);
    }
}
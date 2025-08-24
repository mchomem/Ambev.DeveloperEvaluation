namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class Rating
{
    public Rating(decimal rate, int count)
    {
        Rate = rate;
        Count = count;
    }

    public decimal Rate { get; private set; }
    public int Count { get; private set; }

    // TODO: verificar se será possível utilizar no CRQS
    public Rating Update(decimal newRate, int newCount)
    {
        return new Rating(newRate, newCount);
    }
}

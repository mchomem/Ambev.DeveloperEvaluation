namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class Geolocation
{
    public Geolocation(string latitude, string longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Latitude { get; private set; }
    public string Longitude { get; private set; }
}

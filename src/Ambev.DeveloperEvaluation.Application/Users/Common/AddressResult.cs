namespace Ambev.DeveloperEvaluation.Application.Users.Common;

public class AddressResult
{
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int Number { get; set; }
    public string Zipcode { get; set; } = string.Empty;
    public GeolocationResult Geolocation { get; set; } = new GeolocationResult();
}
 
namespace Ambev.DeveloperEvaluation.Application.Users.Common;

public class AddressCommand
{
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int Number { get; set; }
    public string Zipcode { get; set; } = string.Empty;
    public GeolocationCommand Geolocation { get; set; } = new ();
}

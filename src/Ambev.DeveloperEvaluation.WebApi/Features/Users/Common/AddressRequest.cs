﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.Common
{
    public class AddressRequest
    {
        public Guid Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; }
        public string Zipcode { get; set; } = string.Empty;
        public GeolocationRequest Geolocation { get; set; } = new GeolocationRequest();
    }
}

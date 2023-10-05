using Katas.ContractTestingJBrains.Contract;

namespace Katas.ContractTestingJBrains.Server;

class WeatherServerTests
{
    [Test]
    public void RandomWeatherServiceReturnsRandomWeatherByDefault()
    {
        var service = new RandomWeatherService(1);
        var location = new LocationSpec
        {
            Postcode = "anywhere"
        };
        service.GetWeatherFor(location).Description.ShouldBe("Sunny");
        service.GetWeatherFor(location).Description.ShouldBe("Sunny");
        service.GetWeatherFor(location).Description.ShouldBe("Raining");
        service.GetWeatherFor(location).Description.ShouldBe("Windy");
    }
    
    [Test]
    public void RandomWeatherServiceAlwaysSaysRainingForManchesterReturnsRandomWeatherByDefault()
    {
        var service = new RandomWeatherService(1);
        var location = new LocationSpec
        {
            City = "Manchester"
        };
        service.GetWeatherFor(location).Description.ShouldBe("Raining");
        service.GetWeatherFor(location).Description.ShouldBe("Raining");
        service.GetWeatherFor(location).Description.ShouldBe("Raining");
        service.GetWeatherFor(location).Description.ShouldBe("Raining");
    }
}
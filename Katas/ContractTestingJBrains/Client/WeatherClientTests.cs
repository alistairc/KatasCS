namespace Katas.ContractTestingJBrains.Client;

class WeatherClientTests
{
    [Test]
    public void ClientReportsWeather()
    {
        var console = new StringWriter();

        var weatherService = new FixedWeatherService("Sunny");
        WeatherClient.CheckTheWeather(weatherService, console);

        console.ToString().ShouldStartWith("The weather at home is Sunny");
    }
}
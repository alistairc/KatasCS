using Katas.ContractTestingJBrains.Contract;

namespace Katas.ContractTestingJBrains.Client;

class FixedWeatherService : IWeatherService
{
    readonly string weatherDescription;

    public FixedWeatherService(string weatherDescription)
    {
        this.weatherDescription = weatherDescription;
    }

    public WeatherInfo GetWeatherFor(LocationSpec location)
    {
        return new WeatherInfo(weatherDescription);
    }
}
namespace Katas.ContractTestingJBrains.Contract;

public interface IWeatherService
{
    WeatherInfo GetWeatherFor(LocationSpec location);
}
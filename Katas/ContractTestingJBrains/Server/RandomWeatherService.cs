using Katas.ContractTestingJBrains.Contract;

namespace Katas.ContractTestingJBrains.Server;

public class RandomWeatherService : IWeatherService
{
    public RandomWeatherService()
    {
        Random = new Random();
    }
    
    public RandomWeatherService(int seed)
    {
        Random = new Random(seed);
    }
    
    Random Random { get; }

    public WeatherInfo GetWeatherFor(LocationSpec location)
    {
        if (location.City == "Manchester") { return new WeatherInfo("Raining"); }
        
        var choice = Random.Next(3);
        var description = choice switch
        {
            0 => "Sunny",
            1 => "Raining",
            2 => "Windy"
        };
        return new WeatherInfo(description);
    }
}
using Katas.ContractTestingJBrains.Contract;
using Katas.ContractTestingJBrains.Server;

namespace Katas.ContractTestingJBrains.Client;

class WeatherClient
{
    public static void WeatherMain()
    {
        var console = Console.Out;
        var service = new RandomWeatherService();
        CheckTheWeather(service, console);
    }

    public static void CheckTheWeather(IWeatherService service, TextWriter console)
    {
        var response = service.GetWeatherFor(new LocationSpec
            {
                Postcode = "ls17 5bt"
            }
        );
        console.WriteLine($"The weather at home is {response.Description}");
    }
}
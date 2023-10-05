using Katas.ContractTestingJBrains.Client;

namespace Katas.ContractTestingJBrains;

class EndToEndTests
{
    [Test]
    public void RunEndToEnd()
    {
        //DeployAndRunAllTheStuff
        //we'd prefer not to have to do this, slow, unreliable, etc
        WeatherClient.WeatherMain();
    }
}
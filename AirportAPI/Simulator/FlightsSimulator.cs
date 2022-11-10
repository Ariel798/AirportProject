using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Json;
using AirportAPI.Logic;
Random rand = new Random();
int Unique = 2;
Timer timer = new Timer(Landing, Unique, 2000, 8000);
Console.ReadKey();
async void Landing(object? state)
{
    try
    {
        WebClient webClient = new WebClient();
        var flight = RandomFlightGenerator();
        string jsonFlight = JsonConvert.SerializeObject(flight);
        HttpClient client = new HttpClient();
        var responseLanding = await client.PostAsJsonAsync("http://localhost:5176/api/Landing", jsonFlight);
        Thread.Sleep(2000);
        var result = client.GetStringAsync("http://localhost:5176/api/Landing/getstatus/?id=stam").Status;
        var target = flight.Target == 0 ? "landing" : "takeoff";
        if (result == TaskStatus.WaitingForActivation)
            Console.WriteLine($"Flight {flight.FlightName} was sent succcessfully for {target}");
    }
    catch (Exception ex)
    {
        throw ex;
    }
}
FlightLogic RandomFlightGenerator()
{
    return new FlightLogic { FlightId = Unique++, FlightName = RandomString(6), Target = (Interfaces.Target)rand.Next(2), PassangersCount = rand.Next(100) };
};
string RandomString(int length)
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[rand.Next(s.Length)]).ToArray());
}
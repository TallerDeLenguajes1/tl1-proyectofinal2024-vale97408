using System.Text.Json;

namespace Proyecto

{
    public class PlanetasAPI
    {
        public static async Task<Planetas> GetWeatherAsync()
        {

            var url = "https://swapi.dev/api/planets/";

              try
            {
                HttpClient Client = new HttpClient();
                HttpResponseMessage response = await Client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Planetas planeta = JsonSerializer.Deserialize<Planetas>(responseBody);
                return planeta;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("ERROR CON LA API");
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }

        }

        // public static Planetas PlanetaObtenidoDeApi()
        // {
        //     var planeta= GetWeatherAsync().Result;
        //     return planeta;
        // }
    }     


}
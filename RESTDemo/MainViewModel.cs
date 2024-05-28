using System.Text.Json;
using System.Windows.Input;

namespace RESTDemo;

public class MainViewModel
{
    HttpClient client;
    JsonSerializerOptions _serializerOptions;

    string baseUrl = "https://6655ef543c1d3b60293ba6fb.mockapi.io";

    public MainViewModel()
    {
        client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
    }

    public ICommand AddUserCommand => 
        new Command(async () => 
            {
                string? url = $"{baseUrl}/users";
                HttpResponseMessage? response = await client.GetAsync(url);

                if(response.IsSuccessStatusCode)
                {
                    //string content = await response.Content.ReadAsStringAsync();
                    using(var responseStream = 
                        await response.Content.ReadAsStreamAsync())
                    {
                        var data = await JsonSerializer.DeserializeAsync<List<User>>(responseStream, _serializerOptions);
                    }
                }
            });
}

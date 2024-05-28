using System.Text;
using System.Text.Json;
using System.Windows.Input;

namespace RESTDemo;

public class MainViewModel
{
    HttpClient client;
    JsonSerializerOptions _serializerOptions;

    string baseUrl = "https://6655ef543c1d3b60293ba6fb.mockapi.io";

    private List<User> Users;

    public MainViewModel()
    {
        client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
    }

    public ICommand GetAllUsersCommand =>
        new Command(async () =>
            {
                string? url = $"{baseUrl}/users";
                HttpResponseMessage? response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //string content = await response.Content.ReadAsStringAsync();
                    using (Stream? responseStream =
                        await response.Content.ReadAsStreamAsync())
                    {
                        List<User>? data = await JsonSerializer.DeserializeAsync<List<User>>(responseStream, _serializerOptions);
                        Users = data;
                    }
                }
            });

    public ICommand GetSingleUserCommand =>
        new Command(async () =>
            {
                string? url = $"{baseUrl}/users/25";
                HttpResponseMessage? response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    using (Stream? responseStream =
                        await response.Content.ReadAsStreamAsync())
                    {
                        User? data = await JsonSerializer.DeserializeAsync<User>(responseStream, _serializerOptions);
                    }
                }
            });

    public ICommand AddUserCommand =>
        new Command(async () =>
            {
                string? url = $"{baseUrl}/users";

                User? user = new User
                {
                    createdAt = DateTime.Now,
                    name = "José Quiñónez",
                    avatar = "https://fakeimg.pl/350x200/?text=MAUI"
                };

                string json = JsonSerializer.Serialize<User>(user, _serializerOptions);

                StringContent? content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage? response = await client.PostAsync(url, content);
            });

    public ICommand UpdateUserCommand =>
        new Command(async () =>
        {
            User? user = Users.FirstOrDefault(x => x.id == "1");

            string? url = $"{baseUrl}/users/1";

            user.name = "Jose";

            string json = 
                JsonSerializer.Serialize<User>(user, _serializerOptions);

            StringContent? content = 
                new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage? response = await client.PutAsync(url, content);
        });

    public ICommand DeleteUserCommand =>
        new Command(async () =>
        {
            var url = $"{baseUrl}/users/52";

            var response = await client.DeleteAsync(url);
        });
}

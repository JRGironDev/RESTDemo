using System.Text.Json;
using System.Windows.Input;

namespace RESTDemo;

public class MainViewModel
{
    HttpClient client;
    JsonSerializerOptions _serializerOptions;

    public MainViewModel()
    {
        client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
    }

    public ICommand AddUserCommand => 
        new Command(() => 
            {

            });
}

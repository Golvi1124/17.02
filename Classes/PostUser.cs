using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _17._02.Classes;

public class PostUser
{
    private readonly HttpClient client = new HttpClient();
    /* Creates a single reusable HTTP client to make web requests.
        readonly means the variable can’t be reassigned after initialization. */


    public async Task PostUserAsync(GetResponse newUser)
    {
        try
        {
            string jsonContent = JsonSerializer.Serialize(newUser);
            // Converts the newUser C# object into a JSON string so it can be sent in a POST request.
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            /* Converts the JSON string into an HTTP request body.
                Specifies UTF-8 encoding and application/json as the content type. 
                When sending a POST request, the API expects properly formatted JSON.
                StringContent ensures the data is encoded correctly.*/

            HttpResponseMessage response = await client.PostAsync("https://jsonplaceholder.typicode.com/users", content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"POST request failed! Status Code: {response.StatusCode}");
                return;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine("User successfully created: ");
            Console.WriteLine(responseContent);
        }
        catch (HttpRequestException error)
        {
            Console.WriteLine($"HTTP error occurred: {error.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
using System.Text.Json;

namespace _17._02.Classes;

public class ClientClass
{
    public HttpClient client = new HttpClient();
    public CreateFile createFile = new CreateFile();

    public async Task Run()
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

            if (!response.IsSuccessStatusCode) // instead of manually checking status codes. Convert.ToInt32(response.StatusCode) != 200
            {
                Console.WriteLine($"A HTTP error occured! {response.Headers}");
                return;
            }

            string content = await response.Content.ReadAsStringAsync();
            List<GetResponse>? users = JsonSerializer.Deserialize<List<GetResponse>>(content);

            if (users != null)
            {
                string output = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                createFile.WriteToFile("test.json", output);
                Console.WriteLine(output);
            }

        }
        catch (HttpRequestException error)
        {
            Console.WriteLine($"A HTTP error occured: {error.Message}");
        }
        //to check othet errors
        catch (JsonException jsonError) 
        {
            Console.WriteLine($"JSON processing error: {jsonError.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}

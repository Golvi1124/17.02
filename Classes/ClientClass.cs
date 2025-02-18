using System.Text;
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
            /* reads the HTTP response body as a string.
                await ensures we wait for the response to fully download before continuing.
                The response contains JSON data (a string representation of users). */
            List<GetResponse>? users = JsonSerializer.Deserialize<List<GetResponse>>(content);
            /* Reads the JSON response (content).
                Converts it into a list of GetResponse objects. 
                 After deserialization, we get a List<GetResponse> containing multiple user objects.*/
            if (users != null)
            {
                string output = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                /* Converts the list of users back into a JSON string.
                    WriteIndented = true makes the JSON pretty-printed (easy to read). */
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

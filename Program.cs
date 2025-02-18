// https://tutorials.eu/how-to-call-get-api-in-csharp/#:~:text=Creating%20an%20HttpClient%20Object%20and,that%20handles%20the%20API%27s%20connection.

using System.Text;
using System.Text.Json;
using _17._02.Classes;
using System.Threading.Tasks;
namespace _17._02;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

        /* 
        Next, we will make the actual GET request by calling the HttpClient’s “GetAsync” method. 
        This method takes in the endpoint of the API as its parameter. 
        This step is necessary to send the request to the API and retrieve the data we want.*/

        var response = await client.GetAsync("users");

        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var getResponse = JsonSerializer.Deserialize<List<GetResponse>>(responseContent);
            Console.WriteLine("Get successful!");
           
if (getResponse != null)
{
    foreach (var user in getResponse)
    {
        Console.WriteLine($"Id: {user.id}");
        Console.WriteLine($"Name: {user.name}");
        Console.WriteLine($"Username: {user.username}");
        Console.WriteLine($"Email: {user.email}");
    }
}

            else
            {
                Console.WriteLine("Error: Unable to deserialize the response.");
            }
        }
        else
        {
            Console.WriteLine("Error: " + response.StatusCode);
        }
    }
}


/*  



    /*  var postData = new PostData
        {
            Name = "John Doe",
            Age = 30,
            Address = "123 Main St"
        };

        var client = new HttpClient();
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

        var json = System.Text.Json.JsonSerializer.Serialize(postData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = client.PostAsync("posts", content).Result;

        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var postResponse = System.Text.Json.JsonSerializer.Deserialize<PostResponse>(responseContent, options);
            if (postResponse != null)
            {
                Console.WriteLine("Post successful! ID: " + postResponse.Id);
            }
            else
            {
                Console.WriteLine("Error: Unable to deserialize the response.");
            }

        }
        else
        {
            Console.WriteLine("Error: " + response.StatusCode);
        } */
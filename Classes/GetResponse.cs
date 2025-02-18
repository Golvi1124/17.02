// Wanted to Get out specific fields

namespace _17._02.Classes;

// Represents the data we want to receive from the API as a JSON object.
// This step is necessary to define the structure of the data we will receive from the API.
public class GetResponse
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? username { get; set; }
    public string? email { get; set; }
}
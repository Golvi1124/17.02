using System;

namespace _17._02.Classes;

// Represents the data we want to receive from the API as a JSON object.
// This step is necessary to define the structure of the data we will receive from the API.
public class GetResponse
{
    public int UserID { get; set; }
    public int Id { get; set; }
    public string? Title { get; set; }
} 

/* class PostData
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
}

class PostResponse
{
    public int Id { get; set; }
} */


/*  "id": 1,
    "name": "Leanne Graham",
    "username": "Bret",
    "email": "Sincere@april.biz",
    "address": {
      "street": "Kulas Light",
      "suite": "Apt. 556",
      "city": "Gwenborough",
      "zipcode": "92998-3874",
      "geo": {
        "lat": "-37.3159",
        "lng": "81.1496" 
        
        
        
        userId": 1,
    "id": 1,
    "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
    "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
  },*/

        
// used different data to make it more learning expierience
// Everything is a mix from different learning sources.

using _17._02.Classes;
namespace _17._02;

class Program
{
    static async Task Main(string[] args) // The async keyword allows the method to use await.
    // Since Run() and PostUserAsync() are asynchronous, Main also needs to be async.
    // This prevents blocking the main thread, making the program more efficient.
    {
        ClientClass clientClass = new ClientClass();
        await clientClass.Run();
        /*  This calls the Run() method from ClientClass, which fetches data from the API.
            The await keyword waits for the API response before continuing execution.
            Without await, the program might continue running before the request completes, which could cause errors.*/

        // Create a new instance of PostUser
        PostUser postUser = new PostUser();

        // Creating a new user to send via POST request
        GetResponse newUser = new GetResponse
        {
            id = 11, // JSONPlaceholder ignores this
            name = "John Doe",
            username = "johndoe",
            email = "johndoe@example.com"
        };

        await postUser.PostUserAsync(newUser);

        GetResponse newUser2 = new GetResponse
        {
            /* The reason "id": 11 or "id": 12 appears in the terminal output is that JSONPlaceholder 
            returns a fake response that includes an id field. 
            However, the API does not actually store the new user. */
            id = 12,
            name = "Emily Doe",
            username = "emilydoe",
            email = "something@sdc.com"
        };
        await postUser.PostUserAsync(newUser2);
        /* Each object (newUser, newUser2) represents a different user.
            The API expects a full user object when creating a new entry, so you must specify each value.
            Without unique names (newUser, newUser2), the second call would overwrite the first one. */
    }
}
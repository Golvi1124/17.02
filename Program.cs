// used different data to make it more learning expierience
// Everything is a mix from different learning sources.

using _17._02.Classes;
namespace _17._02;

class Program
{
    static async Task Main(string[] args)
    {
        ClientClass clientClass = new ClientClass();
        await clientClass.Run();
    }
}
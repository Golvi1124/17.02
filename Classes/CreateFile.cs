namespace _17._02.Classes;

public class CreateFile
{
    public void WriteToFile(string filePath, string content)
    {
        try
        {
            File.WriteAllText(filePath, content);
            Console.WriteLine($"File successfully written to {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }
}

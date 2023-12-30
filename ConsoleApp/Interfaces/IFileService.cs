namespace ConsoleApp.Interfaces
{
    public interface IFileService
    {        
        bool SaveContentToFile(string content, string filepath);
        string GetContentFromFile(string filePath);
    }
}
namespace Laba3;

class FileReader
{
    public string ReadFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}
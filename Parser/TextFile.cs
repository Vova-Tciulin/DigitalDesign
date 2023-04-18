using Parser.Interfaces;

namespace Parser;

public class TextFile:IGetText,ISaveText
{
    private readonly string _pathRead;
    private readonly string _pathWrite;

    public TextFile(string pathRead,string pathWrite)
    {
        _pathRead = pathRead;
        _pathWrite = pathWrite;
    }

    public string GetText()
    {
        try
        {
            return File.ReadAllText(_pathRead);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public void SaveReport(string report)
    {
        try
        {
            File.WriteAllText(_pathWrite, report);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
using Parser.Algorithms;

namespace Parser;

public class WordsReport
{
    public string Report { get; private set; }=String.Empty;
    private readonly string _text;
    private IGetText _getText;
    
    public WordsReport(IGetText getText)
    {
        _getText = getText;
        _text=_getText.GetText();
    }
    
    
    public void CreateSortedReport(IConstructReport constructor)
    {
        Report=constructor.GetSortedReport(_text);
    }

    public void SaveSortedReport(ISaveText file)
    {
        file.SaveReport(Report);
    }

}
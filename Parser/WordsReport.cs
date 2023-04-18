

using Parser.Interfaces;

namespace Parser;

public class WordsReport
{
    public string Report { get; private set; }
    public string Text { get; set; }
    
    private readonly IGetText _getText;
    private readonly IConstructReport _alg;
    private readonly ISaveText _saveText;
    
    public WordsReport(IGetText getText,IConstructReport alg,ISaveText saveText)
    {
        _getText = getText;
        _alg = alg;
        _saveText = saveText;
    }

    public void ExtractText()
    {
        Text = _getText.GetText();
    }
    public void CreateSortedReport()
    {
        Report=_alg.GetSortedReport(Text);
    }

    public void SaveSortedReport()
    {
        _saveText.SaveReport(Report);
    }

}
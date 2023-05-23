

using System.Reflection;
using System.Text;
using Parser.Interfaces;

namespace Parser;

public class WordsReport
{
    public string Report { get; private set; }
    public string Text { get; set; }
    
    private readonly IGetText _getText;
    private readonly ISaveText _saveText;
    
    public WordsReport(IGetText getText,ISaveText saveText)
    {
        _getText = getText;
        _saveText = saveText;
    }

    public void ExtractText()
    {
        Text = _getText.GetText();
    }
    public void CreateSortedReport()
    {
        
        ParserDll.DictionaryAlgorithm alg = new ParserDll.DictionaryAlgorithm();
        
        var type = alg.GetType();

        var privateMethod=type.GetMethod("GetWordsDictionary", BindingFlags.NonPublic | BindingFlags.Instance);

        var sortedWords=privateMethod.Invoke(alg, new []{Text}) as Dictionary<string,int>;
        StringBuilder report = new StringBuilder();
        
        foreach (var pair in sortedWords)
        {
            report.Append($"{pair.Key} {new string(' ',Math.Abs(25-pair.Key.Length))} {pair.Value}\n");
        }
        Report = report.ToString();
    }

    public void SaveSortedReport()
    {
        _saveText.SaveReport(Report);
    }

}
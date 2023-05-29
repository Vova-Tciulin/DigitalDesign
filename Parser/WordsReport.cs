

using System.Diagnostics;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using Parser.Interfaces;
using ParserDll;

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

    public async Task CreateSortedReportFomWeb()
    {
        HttpClient client = new HttpClient();
        RequestText text = new RequestText();

        text.Text = Text;
        
        //отпрвака текста
        using var response = await client.PostAsJsonAsync("http://localhost:5209/text", text);
        
        //получение ответа
        Dictionary<string, int>? words = await response.Content.ReadFromJsonAsync<Dictionary<string, int>>();
        
        StringBuilder report = new StringBuilder();
        
        foreach (var pair in words)
        {
            report.Append($"{pair.Key} {new string(' ',Math.Abs(25-pair.Key.Length))} {pair.Value}\n");
        }
        Report = report.ToString();
    }
    public void CreateSortedReport()
    {
        Stopwatch time = new Stopwatch();
        DictionaryAlgorithm alg = new DictionaryAlgorithm();
        
        var type = alg.GetType();

        var privateMethod=type.GetMethod("GetWordsDictionary", BindingFlags.NonPublic | BindingFlags.Instance);
        time.Start();
        var sortedWords=privateMethod.Invoke(alg, new []{Text}) as Dictionary<string,int>;
        time.Stop();
        Console.WriteLine($"время в миллисекундах: {time.ElapsedMilliseconds}");
        
        StringBuilder report = new StringBuilder();
        
        foreach (var pair in sortedWords)
        {
            report.Append($"{pair.Key} {new string(' ',Math.Abs(25-pair.Key.Length))} {pair.Value}\n");
        }
        Report = report.ToString();
    }

    public void CreateSortedReportAsParallel()
    {
        StringBuilder report = new StringBuilder();
        
        Stopwatch time = new Stopwatch();
        time.Start();
        var words = new DictionaryAlgorithm().GetWordsDictionaryAsParrallel(Text);
        time.Stop();
        Console.WriteLine($"время в миллисекундах: {time.ElapsedMilliseconds}");
        
        
        foreach (var pair in words)
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

public class RequestText
{
    public string Text { get; set; }
}
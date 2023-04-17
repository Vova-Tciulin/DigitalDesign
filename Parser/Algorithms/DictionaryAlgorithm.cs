using System.Text;
using System.Text.RegularExpressions;

namespace Parser.Algorithms;

public class DictionaryAlgorithm:IConstructReport
{
    private Dictionary<string, int> _words = new Dictionary<string, int>();

    public string GetSortedReport(string text)
    {
        StringBuilder report = new StringBuilder();
        var wordsCollection=Parse(text);
        
        FillDictionary(wordsCollection);
        
        var sortedPair = _words.OrderByDescending(u => u.Value);
        
        foreach (var pair in sortedPair)
        {
            report.Append($"{pair.Key} {new string(' ',Math.Abs(25-pair.Key.Length))} {pair.Value}\n");
        }

        return report.ToString();
    }

    private MatchCollection Parse(string text)
    {
        Regex regex = new Regex(@"\b[^\d\W]+\b");
        return regex.Matches(text);
    }
    
    private void FillDictionary(MatchCollection wordsCollection)
    {
        for (int i = 0; i < wordsCollection.Count; i++)
        {
            if (!_words.TryAdd(wordsCollection[i].Value, 1))
            {
                _words[wordsCollection[i].Value]++;
            }
        }
    }
    
}
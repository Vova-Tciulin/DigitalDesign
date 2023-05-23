using System.Text;
using System.Text.RegularExpressions;

namespace ParserDll;

public class DictionaryAlgorithm
{
    
    private Dictionary<string, int> GetWordsDictionary(string text)
    {
        
        Dictionary<string, int> words=new Dictionary<string, int>();
        
        var wordsCollection=Parse(text);
        
        FillDictionary(wordsCollection,words);
        var sortedWord = new Dictionary<string, int>();
        sortedWord=words.OrderByDescending(u => u.Value).ToDictionary(u=>u.Key, u=>u.Value);
        
        return sortedWord;
    }
    private MatchCollection Parse(string text)
    {
        Regex regex = new Regex(@"\b[^\d\W]+\b");
        return regex.Matches(text);
    }
    
    private void FillDictionary(MatchCollection wordsCollection, Dictionary<string,int> words)
    {
        for (int i = 0; i < wordsCollection.Count; i++)
        {
            if (!words.TryAdd(wordsCollection[i].Value, 1))
            {
                words[wordsCollection[i].Value]++;
            }
        }
    }
}
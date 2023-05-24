using System.Collections.Concurrent;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace ParserDll;

public class DictionaryAlgorithm
{
    public Dictionary<string, int> GetWordsDictionaryAsParrallel(string text)
    {
        ConcurrentDictionary<string, int> words = new ConcurrentDictionary<string, int>();
        var wordsCollection=Parse(text);
        
        //парралельное добавление слов в словарь из коллекций слов wordsCollection
        Parallel.ForEach(
            wordsCollection,
            (Match word) =>
            {
                if (!words.TryAdd(word.Value, 1))
                {
                    words[word.Value]++;
                }
            }
        );
        
        return words.OrderByDescending(u=>u.Value).ToDictionary(u=>u.Key,u=>u.Value);
    }

  
    private Dictionary<string, int> GetWordsDictionary(string text)
    {
        
        Dictionary<string, int> words=new Dictionary<string, int>();
        
        var wordsCollection=Parse(text);
        
        for (int i = 0; i < wordsCollection.Count; i++)
        {
            if (!words.TryAdd(wordsCollection[i].Value, 1))
            {
                words[wordsCollection[i].Value]++;
            }
        }
        
       
        return words.OrderByDescending(u => u.Value).ToDictionary(u=>u.Key, u=>u.Value);
    }
    
    
    private MatchCollection Parse(string text)
    {
        Regex regex = new Regex(@"\b[^\d\W]+\b");
        return regex.Matches(text);
    }
    
   
}
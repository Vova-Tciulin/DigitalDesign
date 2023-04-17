using System.Threading.Channels;
using Parser;
using Parser.Algorithms;

//путь к файлу для чтения текста
string pathRead ="testRead.txt";
//путь к файлу для записи отчета
string pathWrite="testWrite.txt";

TextFile file = new TextFile(pathRead, pathWrite);

WordsReport report = new WordsReport(file);

report.CreateSortedReport(new DictionaryAlgorithm());
report.SaveSortedReport(file);


using System.Threading.Channels;
using Parser;
using Parser.Algorithms;
/*
 * класс TextFile в данном случае считывает текст и сохраняет отчет в .txt файл
 * класс DictionaryAlgorithm парсит текст на слова и сохраняет их в словарь, после чего генерирует отсортированный отчет
 * класс WordsReport реализует всю необходимую логику для генерации отчета 
 */

//ввести сюда путь к файлу для чтения текста
string pathRead ="testRead.txt";

//ввести сюда путь к файлу для записи отчета
string pathWrite="testWrite.txt";

TextFile file = new TextFile(pathRead, pathWrite);

WordsReport report = new WordsReport(file);

report.CreateSortedReport(new DictionaryAlgorithm());
report.SaveSortedReport(file);


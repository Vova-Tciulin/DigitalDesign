using System.Diagnostics;
using Parser;

/*
 * класс TextFile в данном случае считывает текст и сохраняет отчет в .txt файл(перезаписывает или создает новый файл)
 * класс DictionaryAlgorithm парсит текст на слова и сохраняет их в словарь, после чего генерирует отсортированный отчет
 * класс WordsReport реализует всю необходимую логику для для данной задачи
 * одинаковые слова, но с разным регистром являются разными словами
 */

//ввести сюда путь к файлу для чтения текста
string pathRead ="testRead.txt";

//ввести сюда путь к файлу для записи отчета
string pathWrite="testWrite.txt";

TextFile file = new TextFile(pathRead, pathWrite);
WordsReport report = new WordsReport(file,new DictionaryAlgorithm(),file);

report.ExtractText();
report.CreateSortedReport();
report.SaveSortedReport();



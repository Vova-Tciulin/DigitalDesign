using System.Diagnostics;
using System.Net.Http.Json;
using Parser;

/*
 * метод CreateSortedReport из класс WordsReport вызывает private метод из dll из которого получает словарь слов.
 * 
 * метод CreateSortedReportAsParallel из класса WordsReport вызывает public метод из dll, который перебирает коллекцию слов
 * парралельно и добавляет их в словарь
 * 
 * класс TextFile в данном случае считывает текст и сохраняет отчет в .txt файл(перезаписывает или создает новый файл)
  * класс WordsReport реализует всю необходимую логику для для данной задачи
  */

//ввести сюда путь к файлу для чтения текста
string pathRead ="testRead.txt";

//ввести сюда путь к файлу для записи отчета
string pathWrite="testWrite.txt";



TextFile file = new TextFile(pathRead, pathWrite);



WordsReport report = new WordsReport(file,file);

report.ExtractText();

//метод, который вызывает web-сервис и принимает Dictionary<string,int>
await report.CreateSortedReportFomWeb();

//метод с парралельным выполненим
//report.CreateSortedReportAsParallel();

//метод с последовательным выполнением
//report.CreateSortedReport();

report.SaveSortedReport();

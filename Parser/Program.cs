using System.Diagnostics;
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

Stopwatch time = new Stopwatch();

TextFile file = new TextFile(pathRead, pathWrite);
WordsReport report = new WordsReport(file,file);

report.ExtractText();

//время при парралельном выполнении
time.Start();
report.CreateSortedReportAsParallel();
time.Stop();
Console.WriteLine($"время в миллисекундах: {time.ElapsedMilliseconds}");
time.Reset();

//время при обычном проходе коллекции слов
time.Start();
report.CreateSortedReport();
time.Stop();
Console.WriteLine($"время в миллисекундах: {time.ElapsedMilliseconds}");


report.SaveSortedReport();



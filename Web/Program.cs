
using ParserDll;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

//принимает текст и вызывает метод из dll. После возвращает результат в виде json

app.MapPost("/text", (TextRequest text) =>
{
    var words = new DictionaryAlgorithm().GetWordsDictionaryAsParrallel(text.Text);
    return Results.Json(words);
});

app.Run();

class TextRequest
{
    public string Text { get; set; }
}
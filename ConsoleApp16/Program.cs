using System.Text.Json;
using System.Text.Json.Serialization;
using Spectre.Console;

internal class Program
{
    public static void Main()
    {
        var game = new Game();
        game.StartGame();
    }
}

internal class Game
{
    public List<Message> Messages { get; set; }
    public Message CurrentMessage { get; set; }

    public Game()
    {
        Messages = JsonSerializer.Deserialize<List<Message>>(File.ReadAllText("../../../structure.json"));
        CurrentMessage = Messages[0];
    }

    public void StartGame()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.Write(new Markup($"\n[bold yellow]{CurrentMessage.Description}[/]\n\n"));

            if (CurrentMessage.Choices is not null)
            {
                string[] titles = new string[CurrentMessage.Choices.Count];

                for (var i = 0; i < CurrentMessage.Choices.Count; i++)
                {
                    var choiceTitle = Messages.FirstOrDefault(item => item.Id == CurrentMessage.Choices[i]);
                    titles[i] = choiceTitle.Title;
                }

                var newChoices = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .PageSize(10)
                        .AddChoices(titles));

                CurrentMessage = Messages.FirstOrDefault(item => item.Title == newChoices);
            }
            else
            {
                AnsiConsole.Write(new Markup("[bold purple]Конец вашей истории[/]"));
                break;
            }
        }
    }
}

internal class Message
{
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    [JsonPropertyName("choices")] public List<string>? Choices { get; set; }
}
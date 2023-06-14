namespace Api.Api;

public class Program
{
    static void Main(string[] args)
    {
        var app = AppBuilder.GetApp(args);

        app.Run();
    }
}



using AngleSharp;
using AngleSharp.Html.Parser;
using System.Text;
namespace ria_ru;



class Ria_ru {

    private static string GetHttpHtml()
    {
        using(var client = new HttpClient())
        {
            var endpoint = new Uri("https://www.mk.ru/news/");
            var result = client.GetAsync(endpoint).Result;
            var json = result.Content.ReadAsStringAsync().Result;

            return json;
        }
    }

    private static void WriteInFile(string Name, string Content= "Some Content", string DateTime = "2023-02-02 00:00:08")
    {
        string path = @"output/News.txt";
        string final_text = Name + "#" + Content + "#" + DateTime;

        using (StreamWriter Writer = new StreamWriter(path, true, Encoding.Default))
        {
            Writer.WriteLine(final_text);
 
            Writer.Close();
        }
    }

    public async Task Parse() 
    {
        IConfiguration config = Configuration.Default;

        IBrowsingContext context = BrowsingContext.New(config);

        var source = GetHttpHtml();;

        var document = await context.OpenAsync(req => req.Content(source));

        Console.WriteLine("\n\n");
        var items = document.QuerySelectorAll("li").Where(item => item.ClassName != null && item.ClassName.Contains("news-listing__item "));
        
        string NameOfNews = "";

        foreach (var item in items)
        {
            NameOfNews = item.TextContent;

            NameOfNews = NameOfNews.Replace("\n","");
            NameOfNews = NameOfNews.Replace("                            ","");
            NameOfNews = NameOfNews.Replace("                    ","");
            NameOfNews = NameOfNews.Replace("                ","");
            NameOfNews = NameOfNews.Remove(0,5);
            WriteInFile(NameOfNews);
            
        } 
       
    }
    
    
}
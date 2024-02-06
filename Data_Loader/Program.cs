using System;
using System.Net;
using System.IO;
//using System.Text.Json;

using News_Database;

internal class Program
{
    private static void Main(string[] args)
    {
        void Download_BBC()
        {
            using (var web = new WebClient())
            {
                web.DownloadFile("https://www.bbc.com/russian/news-54752552", Path.Combine("html", "BBC.html"));
            }
        }


        void Remake_And_Load_Into_Database_File_BBC()
        {
            var html = File.ReadAllText("html/BBC.html");
            html = html.Split("<main role=\"main\">")[1];
            html = html.Split("</main>")[0];
            html = html.Replace("style=\"padding-bottom:56.25%", "");

            string Name = html.Split("h1")[1].Split(">")[1].Split("<")[0];
            System.Console.WriteLine(Name);

            string img = html.Split("img")[1].Split("src=\"")[1].Split("\"")[0];
            System.Console.WriteLine(img);





            List<string[]> LoadData()
            {
                var data = new List<string[]> ();
                string[] a = new string[] {$"{Name}",$"{img}",$"{html}","BBC","0"};
                data.Add(a);
                return data; 
            }


            Database db = new Database();
            db.PostData(LoadData());

        }


        Download_BBC();
        Remake_And_Load_Into_Database_File_BBC();
    }
}

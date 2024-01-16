using System;
using System.Net;
using System.IO;


void Download_BBC_Main()
{
   using (var web = new WebClient()){
      web.DownloadFile("https://www.bbc.com/russian/features-55487452", Path.Combine("html", "BBC_Main.html"));
   }
}


async Task Remake_File()
{
    var html = File.ReadAllText("html/BBC_Main.html");
    html = html.Split("<main role=\"main\">")[1];
    html = html.Split("</main>")[0];
    System.Console.WriteLine(html);
    html = html.Replace("style=\"padding-bottom:56.25%", "");
    File.WriteAllText("html/newBBC_Main.html", html);
}


//Download_BBC_Main();
Remake_File();






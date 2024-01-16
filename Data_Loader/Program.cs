using System;
using System.Net;
using System.IO;

using AngleSharp;
using AngleSharp.Text;

void Download_BBC_Main()
{
   using (var web = new WebClient()){
      web.DownloadFile("https://www.bbc.com/russian", Path.Combine("html", "BBC_Main.html"));
   }
}


void Reading_File()
{
   try
   {
      var html_text = File.ReadAllText("html/BBC_Main.html");
      System.Console.WriteLine(html_text);
   }
   catch(Exception e)
   {
      Console.WriteLine("Exception: " + e.Message);
   }
   finally
   {
      Console.WriteLine("Executing finally block.");
   }
}

//Download_BBC_Main();
Reading_File();
using System.Diagnostics;
using System.Security;
using System.Net;
using System.IO;

using News_Database;



string docPath = "Python_scripts/";




Database db = new Database();
var unPublishedData = db.GetUnpublishedData();

using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "NewsNames.txt")))
{
    foreach(var News_Page in unPublishedData)
    {
        outputFile.WriteLine(News_Page[0] + "###" + News_Page[1]);
    }
}




ProcessStartInfo proc_start_info = new ProcessStartInfo();
proc_start_info.FileName = "bash";
proc_start_info.Arguments = "Python_scripts/script.sh";
// -c allows to wait the command to be execute and exit

proc_start_info.RedirectStandardOutput = true;
proc_start_info.UseShellExecute = false;
proc_start_info.CreateNoWindow = true;

Process proc = new Process();
proc.StartInfo = proc_start_info;
proc.Start();
string result = proc.StandardOutput.ReadToEnd();






var html = File.ReadAllText("Python_scripts/Analysed_Data.txt");
foreach(var News_Page in html.Split("\n"))
{
    if(News_Page != "")
    {
        System.Console.WriteLine(News_Page);
        if (News_Page.Split("###")[1] == "0")
        {
            db.DeleteDataById(News_Page.Split("###")[0]);
        }
        else
        {
            db.UpdateDataToPublishedById(News_Page.Split("###")[0]);
        }
    }
    
}

File.WriteAllText("Python_scripts/Analysed_Data.txt","");
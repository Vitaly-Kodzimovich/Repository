using System.IO;

using System.Diagnostics;
using System.Security;


int Positivity_Python_Assessor(string text)
{


    ProcessStartInfo proc_start_info = new ProcessStartInfo();
    proc_start_info.FileName = "bash";
    proc_start_info.Arguments = "Python_scripts/script.sh";

    proc_start_info.RedirectStandardOutput = true;
    proc_start_info.UseShellExecute = false;
    proc_start_info.CreateNoWindow = true;

    Process proc = new Process();
    proc.StartInfo = proc_start_info;
    proc.Start();
    string result = proc.StandardOutput.ReadToEnd();

    Console.WriteLine(result);

    return 0;
}


string PositivityAssessor(string text)
{
    int Positivity = 0;
    return text + "###" + Positivity.ToString() + "\n";
}

string NewsWithPositivityOutput = "";

string? line;
try
{
    
    StreamReader sr = new StreamReader("input/News.txt");
    
    line = sr.ReadLine();

    while (line != null)
    {
        NewsWithPositivityOutput += PositivityAssessor(line);
        
        line = sr.ReadLine();
    }
    
    sr.Close();
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    Console.WriteLine("Чтение произведено успешно");
    Positivity_Python_Assessor("Hello");
}

try
{
    StreamWriter sw = new StreamWriter("output/NewsWithPositivity.txt");
    sw.Write(NewsWithPositivityOutput);
    sw.Close();
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    Console.WriteLine("Запись произведена успешно");
}

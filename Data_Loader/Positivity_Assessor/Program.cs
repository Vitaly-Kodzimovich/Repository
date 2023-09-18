using System.IO;

string PositivityAssessor(string text)
{
    int Positivity = 0;
    return text + "#" + Positivity.ToString() + "\n";
}

string NewsWithPositivityOutput = "";

string line;
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
using MySql.Data.MySqlClient;


string cs = @"server=localhost;userid=ADMIN;password=PASSWORD;database=NEWS_DATABASE";

using var con = new MySqlConnection(cs);
con.Open();

using var cmd = new MySqlCommand();
cmd.Connection = con;

string line;
try
{
    
    StreamReader sr = new StreamReader("NewsIntoSql/NewsWithPositivity.txt");
    
    line = sr.ReadLine();
    string[] SqlObject;

    while (line != null)
    {
        line = sr.ReadLine();
        SqlObject = line.Split('#');

        //SQL
        cmd.CommandText = $"INSERT INTO News(Name,Content, DateTime, Positivity) VALUES('{SqlObject[0]}','{SqlObject[1]}', '{SqlObject[2]}', {SqlObject[3]});";
        cmd.ExecuteNonQuery();
    }
    
    sr.Close();
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    Console.WriteLine("Загружено в Базу данных");
}


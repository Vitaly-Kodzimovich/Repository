using MySql.Data.MySqlClient;

//List<string[]> TestData()
//{
//    var data = new List<string[]> ();
//    string[] a = new string[] {"Name1","PicturePath","FileName","Company","1"};
//    string[] b = new string[] {"Name2","PicturePath","FileName","Company","1"};
//    data.Add(a);
//    data.Add(b);
//    return data; 
//}


//DeleteData();

//PostData(TestData());

//var Data = GetData();
//System.Console.WriteLine(Data[0][0]);


//Database db = new Database();
//var data = db.GetOneElement();
//System.Console.WriteLine(data[0][1]);

namespace News_Database;

public class Database(){

public List<string[]> GetAllData()
{
    string connStr = @"server=localhost;userid=root;password=zxczxczxczxcZXClolololppp777@@@;database=News_db";
    MySqlConnection conn = new MySqlConnection(connStr);
    
    var Data = new List<string[]> ();

    try
    {
        Console.WriteLine("Connecting to MySQL...");
        conn.Open();

        string sql = "SELECT * FROM News_Pages";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();

        

        while (rdr.Read())
        {
            string[] help = new string[] {"Id","Name","Image_Path","Html_Path","Company_Name","Is_Active"};
            help[0] = rdr[0].ToString();
            help[1] = rdr[1].ToString();
            help[2] = rdr[2].ToString();
            help[3] = rdr[3].ToString();
            help[4] = rdr[4].ToString();
            help[5] = rdr[5].ToString();
            Data.Add(help);
        }
        rdr.Close();
    }

    catch(Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
    finally
    {
        Console.WriteLine("All Data getted successfully");
    }


    return Data;
}

public List<string[]> GetOneElement(int id = 1)
{
    string connStr = @"server=localhost;userid=root;password=zxczxczxczxcZXClolololppp777@@@;database=News_db";
    MySqlConnection conn = new MySqlConnection(connStr);
    
    var Data = new List<string[]> ();

    try
    {
        Console.WriteLine("Connecting to MySQL...");
        conn.Open();

        string sql = $"SELECT * FROM News_Pages WHERE Id = {id}";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();

        

        while (rdr.Read())
        {
            string[] help = new string[] {"Id","Name","Image_Path","Html_Path","Company_Name","Is_Active"};
            help[0] = rdr[0].ToString();
            help[1] = rdr[1].ToString();
            help[2] = rdr[2].ToString();
            help[3] = rdr[3].ToString();
            help[4] = rdr[4].ToString();
            help[5] = rdr[5].ToString();
            Data.Add(help);
        }
        rdr.Close();
    }

    catch(Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
    finally
    {
        Console.WriteLine("All Data getted successfully");
    }


    return Data;
}

public List<string[]> GetUnpublishedData()
{
    string connStr = @"server=localhost;userid=root;password=zxczxczxczxcZXClolololppp777@@@;database=News_db";
    MySqlConnection conn = new MySqlConnection(connStr);
    
    var Data = new List<string[]> ();

    try
    {
        Console.WriteLine("Connecting to MySQL...");
        conn.Open();

        string sql = "SELECT Id,Name FROM News_Pages WHERE IsPosted='0'";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();

        

        while (rdr.Read())
        {
            string[] help = new string[] {"Id","Name"};
            help[0] = rdr[0].ToString();
            help[1] = rdr[1].ToString();
            Data.Add(help);
        }
        rdr.Close();
    }

    catch(Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
    finally
    {
        Console.WriteLine("All Unpublished Data getted successfully");
    }


    return Data;
}


public void PostData(List<string[]> Data)
{
    string cs = @"server=localhost;userid=root;password=zxczxczxczxcZXClolololppp777@@@;database=News_db";

    using var con = new MySqlConnection(cs);
    con.Open();

    using var cmd = new MySqlCommand();
    cmd.Connection = con;

    try
    {
        foreach(string[] News_Page in Data)
        {
            cmd.CommandText = $"INSERT INTO News_Pages( Name, PicturePath, FileName, Company, IsPosted) VALUES( '{News_Page[0]}', '{News_Page[1]}', '{News_Page[2]}','{News_Page[3]}', '{News_Page[4]}')";
            cmd.ExecuteNonQuery();
        }
    }
    catch(Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
    finally
    {
        Console.WriteLine("All Data Posted successfully");
    }
}


public void UpdateDataToPublishedById(string id = "1")
{
    string cs = @"server=localhost;userid=root;password=zxczxczxczxcZXClolololppp777@@@;database=News_db";

    using var con = new MySqlConnection(cs);
    con.Open();

    using var cmd = new MySqlCommand();
    cmd.Connection = con;

    try
    {
        cmd.CommandText = $"UPDATE News_Pages SET IsPosted = '1' where Id = '{id}';";
        cmd.ExecuteNonQuery();
    }
    catch(Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
    finally
    {
        Console.WriteLine("All Data Updated successfully");
    }
}



public void DeleteDataById(string id)
{
    string cs = @"server=localhost;userid=root;password=zxczxczxczxcZXClolololppp777@@@;database=News_db";

    using var con = new MySqlConnection(cs);
    con.Open();

    using var cmd = new MySqlCommand();
    cmd.Connection = con;

    try
    {
        cmd.CommandText = $"DELETE FROM News_Pages WHERE Id='{id}'";
        cmd.ExecuteNonQuery();
    }
    catch(Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
    finally
    {
        Console.WriteLine("All Data Deleted successfully");
    }
}

}











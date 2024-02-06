using MySql.Data.MySqlClient;



//Database db = new Database();
//System.Console.WriteLine(db.CreateMD5("HEllo"));

namespace Users_Database;


public class Database(){
    public string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }

    public List<string[]> GetAllData()
    {
        string cs = @"server=localhost;userid=root;password=zxczxczxczxcZXClolololppp777@@@;database=Users";

        MySqlConnection conn = new MySqlConnection(cs);
        
        var Data = new List<string[]> ();

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT * FROM Users";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            

            while (rdr.Read())
            {
                string[] help = new string[] {"Id","Name","Password","UserAccess"};
                help[0] = rdr[0].ToString();
                help[1] = rdr[1].ToString();
                help[2] = rdr[2].ToString();
                help[3] = rdr[3].ToString();
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

    public List<string[]> GetUserDataByName(string UserName)
    {
        string cs = @"server=localhost;userid=root;password=zxczxczxczxcZXClolololppp777@@@;database=Users";

        MySqlConnection conn = new MySqlConnection(cs);
        
        var Data = new List<string[]> ();

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = $"SELECT * FROM Users WHERE Name='{UserName}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            

            while (rdr.Read())
            {
                string[] help = new string[] {"Id","Name","Password","UserAccess"};
                help[0] = rdr[0].ToString();
                help[1] = rdr[1].ToString();
                help[2] = rdr[2].ToString();
                help[3] = rdr[3].ToString();
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

    public void NewUser(string[] UserData)
    {
        string cs = @"server=localhost;userid=root;password=zxczxczxczxcZXClolololppp777@@@;database=Users";

        using var con = new MySqlConnection(cs);
        con.Open();

        using var cmd = new MySqlCommand();
        cmd.Connection = con;

        try
        {
            cmd.CommandText = $"INSERT INTO Users( Name, Password, UserAccess) VALUES( '{UserData[0]}', '{CreateMD5(UserData[1])}', '{UserData[2]}')";
            cmd.ExecuteNonQuery();
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

    public bool CheckUser(string[] UserData)
    {
        //cmd.CommandText = $"SELECT Id FROM Users WHERE Name='{UserData[0]}' AND Password='{CreateMD5(UserData[0])}'";
        string cs = @"server=localhost;userid=root;password=zxczxczxczxcZXClolololppp777@@@;database=Users";

        MySqlConnection conn = new MySqlConnection(cs);
        
        var Data = new List<string[]> ();

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = $"SELECT Id FROM Users WHERE Name='{UserData[0]}' AND Password='{CreateMD5(UserData[1])}';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                return true;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        return false;
    }

    //System.Console.WriteLine(GetAllData()[0][1]);
    //System.Console.WriteLine(GetUserDataByName("Person2")[0][1]);

    //string[] SomeNewUser = {"Tommy","Pizza","1"};
    //NewUser(SomeNewUser);

    //string[] SomeUser = {"Person3","qwerty2"}; //-- true
    //string[] SomeUser = {"Person3","abc"}; //-- false
    //string[] SomeUser = {"Person12345","qwerty2"}; //--false
    //System.Console.WriteLine((CheckUser(SomeUser)));
}


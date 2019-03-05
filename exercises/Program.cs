using System;
using System.Data.SQLite;

namespace SQLiteDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Testing SQLite database in C# ...");
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            DropTables(sqlite_conn);
            CreateTable(sqlite_conn);
            InsertData(sqlite_conn);
            ReadData(sqlite_conn);
        }

        private static void DropTables(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "drop table if exists SampleTable";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            string Createsql1 = "drop table if exists SampleTable1";
            sqlite_cmd.CommandText = Createsql1;
            sqlite_cmd.ExecuteNonQuery();
            Console.WriteLine("Dropping tables ...");
        }

        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new 
                SQLiteConnection("Data Source= database.db; New = True; Compress = True; "); // Open the connection:
                //SQLiteConnection("Data Source= database.db; Version = 3; New = True; Compress = True; "); // Open the connection:
             try
            {
                sqlite_conn.Open();
                Console.WriteLine("SQLite connection created ...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return sqlite_conn;
            }

        static void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE SampleTable (Col1 VARCHAR(20), Col2 INT)";
            string Createsql1 = "CREATE TABLE SampleTable1 (Col1 VARCHAR(20), Col2 INT)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql1;
            sqlite_cmd.ExecuteNonQuery();
            Console.WriteLine("Creating tables ...");
        }

        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES('Test Text ', 1); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES('Test1 Text1 ', 2); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES('Test2 Text2 ', 3); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable1 (Col1, Col2) VALUES('Test3 Text3 ', 3); ";
            sqlite_cmd.ExecuteNonQuery();
            Console.WriteLine("Insert queries successfully executed ...");
        }

        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM SampleTable";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }
    }
}
//namespace SQLiteDemo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//        }
//    }
//}

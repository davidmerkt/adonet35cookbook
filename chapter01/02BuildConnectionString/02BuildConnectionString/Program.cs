using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _02BuildConnectionString
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();

            csb.DataSource = @"(local)\SQLEXPRESS";
            csb.Add("Initial Catalog", "AdventureWorks2014");
            csb["Integrated Security"] = true;

            Console.WriteLine("Connection string:\n{0}", csb.ConnectionString);

            SqlConnection connection = new SqlConnection(csb.ConnectionString);

            connection.Open();
            Console.WriteLine("\nConnectionState = {0}", connection.State);
            connection.Close();
            Console.WriteLine("\nConnectionState = {0}", connection.State);

            Console.WriteLine("\nPress any key to continue…");
            Console.ReadKey();
        }
    }
}

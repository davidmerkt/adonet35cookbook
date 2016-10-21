using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _01StoredConnectionStringConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Connection string enumeration---");
            foreach(ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                Console.WriteLine(css.Name);
                Console.WriteLine(css.ProviderName);
                Console.WriteLine(css.ConnectionString);
            }

            Console.WriteLine("\n---Using a connection string---");
            Console.WriteLine("-> Retrieving connection string AdventureWorks");
            string sqlConnectString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;
            SqlConnection connection = new SqlConnection(sqlConnectString);
            Console.WriteLine("-> Opening connection string…");
            connection.Open();
            Console.WriteLine("Connection string state = {0}", connection.State);
            connection.Close();
            Console.WriteLine("-> Closing connection string…");
            Console.WriteLine("Connection string state = {0}", connection.State);

            Console.WriteLine("\nPress any key to continue…");
            Console.ReadKey();
        }
    }
}

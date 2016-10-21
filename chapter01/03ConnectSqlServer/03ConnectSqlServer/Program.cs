using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;

namespace _03ConnectSqlServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect using .NET data provider for SQL Server and integrated security
            string sqlConnectString1 = @"Data Source=(local)\SQLExpress;Integrated Security=SSPI;Initial Catalog=AdventureWorks2014;";
            string authenticationMode = "with Windows Authentication mode---";

            TestSqlConnection(sqlConnectString1, authenticationMode);

            // Connect using .NET data provider for SQL Server and SQL Server authentication
            string sqlConnectString2 = @"Data Source=(local)\SQLExpress;User Id=sa;Password=Password.1;Initial Catalog=AdventureWorks2014;";
            authenticationMode = "with SQL Server Authentication mode---";

            TestSqlConnection(sqlConnectString2, authenticationMode);

            // Connect using .NET data provider for OLE DB.
            string oledbConnectString = @"Provider=SQLOLEDB;Data Source=(local)\SQLExpress;Initial Catalog=AdventureWorks2014;User Id=sa;Password=Password.1;";
            authenticationMode = "with .NET data provider for OLE DB---";

            using (OleDbConnection connection = new OleDbConnection(oledbConnectString))
            {
                connection.Open();

                // Return some information about the server.
                Console.WriteLine("\n---.NET data provider for SQL Server " + authenticationMode);
                Console.WriteLine("ConnectionString = {0}\n", oledbConnectString);
                Console.WriteLine("State = {0}", connection.State);
                Console.WriteLine("DataSource = {0}", connection.DataSource);
                Console.WriteLine("ServerVersion = {0}", connection.ServerVersion);

                connection.Close();
            }

            // Connect using .NET data provider for ODBC.
            string odbcConnectString = @"Driver={SQL Native Client};Server=(local)\SQLExpress;Database=AdventureWorks2014;uid=sa;pwd=Password.1;";
            authenticationMode = "with .NET data provider for ODBC---";

            using (OdbcConnection connection = new OdbcConnection(odbcConnectString))
            {
                connection.Open();

                // Return some information about the server.
                Console.WriteLine("\n---.NET data provider for SQL Server " + authenticationMode);
                Console.WriteLine("ConnectionString = {0}\n", oledbConnectString);
                Console.WriteLine("State = {0}", connection.State);
                Console.WriteLine("DataSource = {0}", connection.DataSource);
                Console.WriteLine("ServerVersion = {0}", connection.ServerVersion);

                connection.Close();
            }

            Console.WriteLine("\nPress any key to continue…");
            Console.ReadKey();
        }

        private static void TestSqlConnection(string sqlConnectString, string authenticationMode) 
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectString))
            {
                connection.Open();

                Console.WriteLine("\n---.NET data provider for SQL Server " + authenticationMode);
                Console.WriteLine("ConnectionString = {0}\n", sqlConnectString);
                Console.WriteLine("State = {0}", connection.State);
                Console.WriteLine("DataSource = {0}", connection.DataSource);
                Console.WriteLine("ServerVersion = {0}", connection.ServerVersion);

                connection.Close();
            }
        }
    }
}

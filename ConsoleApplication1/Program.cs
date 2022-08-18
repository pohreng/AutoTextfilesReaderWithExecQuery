using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");

            //configure database here
            var datasource = @"write ip";
            var database = "write database";
            var username = "write username";
            var password = "write password";

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");

 

                //***change path and file name***
                string[] lines = System.IO.File.ReadAllLines(@"C:\write\path\here");
                foreach (string line in lines)
                {
                    StringBuilder strBuilder = new StringBuilder();

                    strBuilder.Append("insesrt\update query where condition = '" + line + "'");

                    string sqlQuery = strBuilder.ToString();
                    using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                    {
                        if (command.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine(line + " update successfully");
                        }
                    }
                }

                Console.WriteLine("Connection successful!");
                Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
    }
}

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Utils
{
    public class DbUtil
    {
        public static void DBConnection()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();

            //Use DB in project directory.  If it does not exist, create it:
            connectionStringBuilder.DataSource = @"C:\Users\Anoop.Simon\source\repos\ToDoList\ToDoList\SQliteDB.db";

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                //Create a table (drop if already exists first):

                var delTableCmd = connection.CreateCommand();
                delTableCmd.CommandText = "DROP TABLE IF EXISTS favorite_beers";
                delTableCmd.ExecuteNonQuery();

                var createTableCmd = connection.CreateCommand();
                createTableCmd.CommandText = "CREATE TABLE Item(name VARCHAR(50))";
                createTableCmd.ExecuteNonQuery();

                //Seed some data:
                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();

                    insertCmd.CommandText = "INSERT INTO Item VALUES('LAGUNITAS IPA')";
                    insertCmd.ExecuteNonQuery();

                    insertCmd.CommandText = "INSERT INTO Item VALUES('JAI ALAI IPA')";
                    insertCmd.ExecuteNonQuery();

                    insertCmd.CommandText = "INSERT INTO Item VALUES('RANGER IPA')";
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                }

                //Read the newly inserted data:
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT name FROM Item";

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var message = reader.GetString(0);
                        Console.WriteLine(message);
                    }
                }


            }
        }
    }
}

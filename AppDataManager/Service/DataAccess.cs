using System;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;
using System.Collections.Generic;

namespace AppDataManager.Service
{
    public static class DataAccess
    {
        static string nameDataBase = "keeperData.db"; 
        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("keeperData.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "keeperData.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                
                
                var tableCommand = "CREATE TABLE IF NOT EXISTS User " + 
                                                       "(ID INTEGER PRIMARY KEY, " +
                                                        "Email VARCHAR(255) NOT NULL, " +
                                                        "Password VARCHAR(255) NOT NULL);" +
                                   "CREATE TABLE IF NOT EXISTS Secret " + 
                                                       "(ID INTEGER PRIMARY KEY, " +
                                                        "Title VARCHAR(255) NOT NULL, " +
                                                        "Url VARCHAR(255) NULL, " +
                                                        "Comment VARCHAR(2048) NULL, " +
                                                        "UserId INTEGER(255), " +
                                                        "FOREIGN KEY (UserId) REFERENCES User(ID))";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }
        public static void AddData(string inputText)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, nameDataBase);
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", inputText);

                insertCommand.ExecuteReader();
            }
        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, nameDataBase);
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Text_Entry from MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
            }

            return entries;
        }

    }
}

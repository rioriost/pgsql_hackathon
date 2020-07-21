using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;

private static string Host = "riohackathonpgsql.postgres.database.azure.com";
private static string User = "rifujita@riohackathonpgsql";
private static string DBname = "postgres";
private static string Port = "5432";
private static string Password = "Passw0rd#";

public static void Run(Stream myBlob, string name, ILogger log)
{
    log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
    List<string> sqllist = new List<string>();
    using (StreamReader sr = new StreamReader(myBlob)){
        int fieldnum;
        string line = "", buf = "", hh = "", mm = "";
        while (!sr.EndOfStream){
            line = sr.ReadLine();
            List<string> lists = new List<string>();
            lists.AddRange(line.Split(','));
            fieldnum = 0;
            List<string> items = new List<string>();
            foreach (string list in lists){
                if (fieldnum == 0) {
                    buf = string.Format("{{\"tag\": \"{0}\", \"data\": [", list);
                } else {
                    hh = ((fieldnum - 1) / 6).ToString("D2");
                    mm = ((fieldnum - 1) * 10 % 60).ToString("D2");
                    items.Add(string.Format("{{\"{0}:{1}\" : \"{2}\"}}", hh, mm, list));
                }
                fieldnum += 1;
            }
            sqllist.Add(string.Format("INSERT INTO logs (content) VALUES ('{0}')", buf + string.Join(",", items) + "]}"));
        }
    }
    string connString = string.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", Host, User, DBname, Port, Password);
    using (var conn = new NpgsqlConnection(connString)){
        conn.Open();
        int nRows;
        foreach (string sql in sqllist){
            using (var command = new NpgsqlCommand(sql, conn)){
                nRows = command.ExecuteNonQuery();
                log.LogInformation(string.Format("Number of rows inserted={0}", nRows));
            }
        }
    }
}

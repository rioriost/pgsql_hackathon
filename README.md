# pgsql_hackathon

![A diagram showing the range of hackathon.](pgsql_hackathon.png 'Solution Architecture')

1. create [Resource Group](https://docs.microsoft.com/en-us/azure/azure-resource-manager/management/manage-resource-groups-portal)
2. create [Storage Account](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-create?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&tabs=azure-portal)
3. create [Containers](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-portal)

    path: samples-workitems
4. create [Function App](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-storage-blob-triggered-function)
5. create Azure Blob Storage trigger

    path: samples-workitems/{name}
    
    Storage Account Connection: riohackathonsa
6. Upload dummy.data to Container
7. Check if template works with [Monitor](https://docs.microsoft.com/en-us/azure/azure-functions/functions-monitoring?tabs=cmd)
8. Edit code as follows
```csharp
using System;
using System.Collections.Generic;
using System.IO;

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
            buf = string.Format("INSERT INTO logs (content) VALUES ('{0}')", buf + string.Join(",", items) + "]}");
            log.LogInformation(buf);
            sqllist.Add(buf);
        }
    }
}
```
9. Create [function.proj](https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-csharp#using-nuget-packages) file with [App Service Editor](https://github.com/projectkudu/kudu/wiki/App-Service-Editor)

How to find the version of Npgsql
```shell
% nuget list Npgsql | grep Npgsql.EntityFrameworkCore
Npgsql.EntityFrameworkCore.PostgreSQL 3.1.4
Npgsql.EntityFrameworkCore.PostgreSQL.Design 1.1.0
Npgsql.EntityFrameworkCore.PostgreSQL.FuzzyStringMatch 3.1.4
Npgsql.EntityFrameworkCore.PostgreSQL.NetTopologySuite 3.1.4
Npgsql.EntityFrameworkCore.PostgreSQL.NodaTime 3.1.4
Npgsql.EntityFrameworkCore.PostgreSQL.Trigrams 3.1.4
```

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>netstandard2.0</TargetFramework>
    </PropertyGroup>
    <ItemGroup>
        <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="3.1.4" />
        <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL.Design" Version="1.1.0" />
    </ItemGroup>
</Project>
```

10. Create [PostgreSQL](https://docs.microsoft.com/en-us/azure/postgresql/quickstart-create-server-database-portal)

[Allow access to Azure services](https://docs.microsoft.com/en-us/azure/postgresql/howto-manage-firewall-using-portal)

Create a table and an index with psql command
```shell
psql "host=riohackdemopgsql.postgres.database.azure.com port=5432 dbname=postgres user=rifujita@riohackdemopgsql password=Passw0rd# sslmode=require"
```
```plpgsql
CREATE TABLE logs (id BIGSERIAL PRIMARY KEY, content JSONB);
CREATE INDEX content_index ON logs USING GIN (content jsonb_path_ops);
```

11. Edit code as follows
```csharp
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
```

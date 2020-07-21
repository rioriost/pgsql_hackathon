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
            sqllist.Add(string.Format("INSERT INTO logs (content) VALUES ('{0}')", buf + string.Join(",", items) + "]}"));
        }
    }
}

using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
public class CSVWriter
{

    public List<int> LogLoad(string fileName)
    {
        List<int> x = new List<int>();
        using (StreamReader reader = new StreamReader(Application.dataPath + "/" + fileName + ".csv"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                x.Add(int.Parse(line));
            }
            
        }
        return x;
    }

    public void LogSave(List<int> x, string fileName)
    {
        StreamWriter sw; // これがキモらしい
        FileInfo fi;
        // Aplication.dataPath で プロジェクトファイルがある絶対パスが取り込める
        fi = new FileInfo(Application.dataPath + "/" + fileName + ".csv");
        sw = fi.AppendText();
        foreach(var i in x)
        {
            sw.WriteLine(i.ToString());
        }
        sw.Flush();
        sw.Close();
    }
}

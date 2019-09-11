using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class CsvReader
    {
        //区切り文字
        public char delim = ',';

        public List<string[]> ReadFile(string filepath)
        {

            // Assets/Resources配下のファイルを読み込む
            TextAsset csvFile = Resources.Load(filepath) as TextAsset;

            // StringReaderで一行ずつ読み込んで、区切り文字で分割
            List<string[]> data = new List<string[]>();
            StringReader sr = new StringReader(csvFile.text);
            while (sr.Peek() > -1)
            {
                string line = sr.ReadLine();
                data.Add(line.Split(delim));
            }

            return data;
        }
    }

}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var file1CSVValues = GetCSVData("D:/1.csv", ',');
            var file2CSVValues = GetCSVData("D:/2.csv", ',');

            //Read Each File
            ProcessGenericCSVData(file1CSVValues);
            Console.ReadKey();
        }

        public static List<GenericCSVData> GetCSVData(string fileName, char columnSeperator)
        {
            var genericCSVDataList = new List<GenericCSVData>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string currentLine;
                var columnNames = new List<string>();
                if ((currentLine = sr.ReadLine()) != null)
                {
                    var values = currentLine.Split(columnSeperator);
                    foreach (var value in values)
                    {
                        columnNames.Add(value);
                    }
                }
                while ((currentLine = sr.ReadLine()) != null)
                {
                    var genericCSVData = new GenericCSVData();
                    genericCSVData.ValuePairs = new Dictionary<string, string>();
                    var values = currentLine.Split(',');

                    for (int i = 0; i < columnNames.Count; i++)
                    {

                        genericCSVData.ValuePairs.Add(columnNames[i], values[i]);
                    }
                    genericCSVDataList.Add(genericCSVData);
                }
            }
            return genericCSVDataList;
        }

        public static void ProcessGenericCSVData(List<GenericCSVData> genericCSVDatas)
        {
            foreach(var genericCSVData in genericCSVDatas)
            {
                foreach(var keyValuePair in genericCSVData.ValuePairs)
                {
                    // Here write your processing logic. Remove Console.WriteLine as it is for reference only
                    Console.WriteLine(String.Format("ColumnName: {0}, Value :{1}", keyValuePair.Key, keyValuePair.Value));
                }
                Console.WriteLine();
            }
        }

        public class GenericCSVData
        {
            public Dictionary<string, string> ValuePairs { get; set; }
        }

    }
}

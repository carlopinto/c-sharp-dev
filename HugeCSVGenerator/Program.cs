
using System.Text;

namespace HugeCSVGenerator
{
    public class Program
    {
        /// <summary>
        /// Write a CSV file with only integers, whose value is between -10000 and 10000
        /// </summary>
        /// <param name="filePath">Path of the file to be written</param>
        /// <param name="rows">Number of columns in the file</param>
        public static void GenerateCSV(string filePath, int rows)
        {
            int columns = 10;
            var csv = new StringBuilder();
            var headers = "";
            for (int i = 0; i < columns; i++)
            {
                // no comma for the last element
                headers += "C" + i;
                if (i != columns - 1)
                    headers += ",";
            }
            csv.AppendLine(headers);

            var random = new Random();
            for (int r = 0; r < rows; r++)
            {
                var row = "";
                for (int i = 0; i < columns; i++)
                {
                    row += random.Next(-10000, 10000);
                    if (i != columns - 1)
                        headers += ",";
                }
                csv.AppendLine(row);
            }

            File.WriteAllText(filePath, csv.ToString());
        }

        public static void Main(string[] args)
        {

        }
    }
}
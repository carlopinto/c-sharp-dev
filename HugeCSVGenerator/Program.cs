
using System.Text;

namespace HugeCSVGenerator
{
    public class Program
    {
        private const int NUMBER_OF_COLUMNS = 10;

        /// <summary>
        /// Write a CSV file
        /// </summary>
        /// <param name="filePath">Path of the file to be written</param>
        /// <param name="rows">Number of rows in the file</param>
        public static void GenerateCSV(string filePath, int rows)
        {
            Console.WriteLine("Starting CSV generation...");
            var startTime = DateTime.Now;
            var headers = CreateCSVHeader();

            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(headers);

                for (int r = 0; r < rows; r++)
                {
                    var row = CreateCSVRow();
                    sw.WriteLine(row);
                }
            }

            var endTime = DateTime.Now;
            var totalTimeMs = (endTime - startTime).TotalMilliseconds;
            Console.WriteLine($"CSV generation completed in {totalTimeMs} milliseconds");
        }

        /// <summary>
        /// Create a CSV row with the headers (C1, C2, etc.)
        /// </summary>
        /// <returns></returns>
        public static string CreateCSVHeader()
        {
            var row = "";
            for (int i = 0; i < NUMBER_OF_COLUMNS; i++)
            {
                // no comma for the last element
                row += "C" + i;
                if (i != NUMBER_OF_COLUMNS - 1)
                    row += ",";
            }
            return row;
        }

        /// <summary>
        /// Create a CSV row with only integers, whose value is between -10000 and 10000
        /// </summary>
        /// <returns></returns>
        public static string CreateCSVRow()
        {
            var random = new Random();
            var row = "";
            for (int i = 0; i < NUMBER_OF_COLUMNS; i++)
            {
                // no comma for the last element
                row += random.Next(-10000, 10000);
                if (i != NUMBER_OF_COLUMNS - 1)
                    row += ",";
            }
            return row;
        }

        public static void Main(string[] args)
        {
            string filePath = "huge.csv";
            GenerateCSV(filePath, 10000000);
        }
    }
}
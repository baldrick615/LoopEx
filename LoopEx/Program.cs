public class Program
{
    private static void Main(string[] args)
    {
        string newfees = "input.csv";
        string fileName = "output.txt";
        string path = "C:\\Users\\tmcgr\\OneDrive\\Desktop\\";
        string filepath = path + newfees;
        var array1 = ReadCsvFile(path + newfees);

        //Facility codes
        var array2 = new string[] { "18", "19", "21", "22", "23" };

        //Delete the file if it exists
        if (!File.Exists(path + fileName))
        {
            File.Create(path + fileName).Close();
        }
        else
        {
            File.Delete(path + fileName);
            File.Create(path + fileName).Close();
        }

        //Loop through values and create the output file
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i][3] == "FACILITY")
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    Console.WriteLine(array1[i][0] + ", " + array1[i][1] + ", " + array1[i][2] + ", " + array2[j]);
                    //output the values to a csv file
                    using (var sw = new StreamWriter(path + fileName, true))
                    {
                        sw.WriteLine(array1[i][0] + ", " + array1[i][1] + ", " + array1[i][2] + ", " + array1[i][4] + ", " + array1[i][5] + ", " + array2[j]);
                    }
                }
            }
            else
            {
                //output the values to a csv file
                using (var sw = new StreamWriter(path + fileName, true))
                {
                    sw.WriteLine(array1[i][0] + ", " + array1[i][1] + ", " + array1[i][2] + ", " + array1[i][4] + ", " + array1[i][5] + ", " + "''");
                }
            }
        }
    }



    static string[][] ReadCsvFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        return lines.Select(line => line.Split(',')).ToArray();
    }
}

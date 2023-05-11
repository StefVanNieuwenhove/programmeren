
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Diagnostics;
using System.Globalization;

const string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=gentse-feesten;Integrated Security=True;TrustServerCertificate=True";
const string csvFile = @"C:\Users\stefv\Documents\HoGent\2022-2023\Programmeren\Gente-feesten\Evenementen.csv";

using (SqlConnection connection = new(connectionString))
{
    try
    {
        connection.Open();

        string query = "INSERT INTO Events (Id, Title, Startdate, EndDate, Price, Description)" +
                       "Values (@Id, @Title, @StartDate, @EndDate, @Price, @Description)";
      
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandText = query;

            using (StreamReader reader = new(csvFile))
            {
                while (!reader.EndOfStream)
                {

                    string line = reader.ReadLine();
                    if (line.Contains('"'))
                    {
                        line = line.Replace("\"", string.Empty);

                        string[] values = line.Split(';');

                        if (connection.State != ConnectionState.Open)
                            Console.WriteLine("connection closed");
                        else Console.WriteLine("Connection open");


                        DateTime.TryParseExact(values[2], "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime start);
                        DateTime.TryParseExact(values[3], "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime end);
                        Console.WriteLine(start + " | " + end);

                        command.Parameters.Add("@Id", SqlDbType.VarChar);
                        command.Parameters["@Id"].Value = values[0];

                        command.Parameters.Add("@Title", SqlDbType.VarChar);
                        command.Parameters["@Title"].Value = values[1];

                        command.Parameters.Add("@StartDate", SqlDbType.DateTime);
                        command.Parameters["@StartDate"].Value = start;

                        command.Parameters.Add("@EndDate", SqlDbType.DateTime);
                        command.Parameters["@EndDate"].Value = end;

                        command.Parameters.Add("@Price", SqlDbType.Decimal);
                        command.Parameters["@Price"].Value = values[4];

                        command.Parameters.Add("@Description", SqlDbType.Text);
                        command.Parameters["@Description"].Value = values[5];

                        //Console.WriteLine($"{values[2]} | {values[3]} ");

                        command.ExecuteNonQuery();

                        connection.Close();
                    }



                }
            }
        }

    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void readDataOfCsvFile(string csvFile)
{
    StreamReader reader = new(csvFile);
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        string[] values = line.Split(';');

        try
        {
            string id = values[0];
            string title = values[1];
            string start = values[2];
            string end = values[3];
            string price = values[4];
            string description = values[5];

            Console.WriteLine($"{id} | {title} | {start} | {end} | {price} | {description}");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

Console.Read();

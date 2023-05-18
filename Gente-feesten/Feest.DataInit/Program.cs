
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Diagnostics;
using System.Globalization;

const string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=gentse-feesten;Integrated Security=True;TrustServerCertificate=True";
const string csvFile = @"C:\Users\stefv\Documents\HoGent\2022-2023\Programmeren\Gente-feesten\Evenementen.csv";
const string tableName = "Events";

List<string> data = new();
SqlConnection connection = new(connectionString);
int count = 0;
try {
    connection.Open();

    StreamReader stream = new(csvFile);
    while (!stream.EndOfStream) {
        string line = stream.ReadLine();
        string[] values = line.Split(';');
       
        try {
            string id = values[0];
            string title = values[1];
            string start = values[2];
            string end = values[3];
            string price = values[4];
            string description = values[5];

            //Console.WriteLine($"{id} | {title} | {start} | {end} | {price} | {description}");
            

            SqlCommand command = new($"INSERT INTO {tableName} VALUES (@id, @title, @start, @end, @price, @description);", connection);

            command.Parameters.Add("@id", SqlDbType.VarChar);
            command.Parameters["@id"].Value = id;

            command.Parameters.Add("@title", SqlDbType.VarChar);
            command.Parameters["@title"].Value = title;

            DateTime.TryParseExact(values[2], "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);
            //Console.WriteLine(startDate);
            command.Parameters.Add("@start", SqlDbType.DateTime);
            command.Parameters["@start"].Value = startDate;

            DateTime.TryParseExact(values[3], "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);
            //Console.WriteLine(endDate);
            command.Parameters.Add("@end", SqlDbType.DateTime);
            command.Parameters["@end"].Value = endDate;

            decimal.TryParse(values[4], out decimal value);
            command.Parameters.Add("@price", SqlDbType.Decimal);
            command.Parameters["@price"].Value = value;

            command.Parameters.Add("@description", SqlDbType.Text);
            command.Parameters["@description"].Value = description;

            
            command.ExecuteNonQuery();
           

        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            Console.WriteLine(count);
        }
        count++;
    }
    Console.WriteLine(count);
    

} catch (Exception ex) {
    Console.WriteLine(ex.Message);
} finally {
    connection.Close();
}







/*using (SqlConnection connection = new(connectionString))
{
    try
    {
        connection.Open();

        string query = "INSERT INTO Events (Id, Title, Startdate, EndDate, Price, Description)" +
                       "Values (@Id, @Title, @StartDate, @EndDate, @Price, @Description);";
      
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandText = query;

            using (StreamReader reader = new(csvFile)) {
                while (!reader.EndOfStream) {

                    string line = reader.ReadLine();
                    if (line.Contains('"')) {
                        line = line.Replace("\"", string.Empty);

                        string[] values = line.Split(';');

                        if (connection.State != ConnectionState.Open)
                            Console.WriteLine("connection closed");
                        else Console.WriteLine("Connection open");

                        //Console.WriteLine(values.Length);

                        DateTime.TryParseExact(values[2], "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime start);
                        DateTime.TryParseExact(values[3], "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime end);

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

                        Console.WriteLine($"{values[0]} | {values[1]} | {values[2]} | {values[3]} | {values[4]} | {values[5].Trim()}");
                        Console.WriteLine(command.ToString);
                        command.ExecuteNonQuery();

                        command.Parameters.Clear();

                    }



                }
            }
        }
        connection.Close();

    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}*/

/*void readDataOfCsvFile(string csvFile)
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
}*/

Console.Read();

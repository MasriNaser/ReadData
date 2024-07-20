using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExcuteRawSql;
class Program
{
    public static void Main()
    {
        var confi = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        //Console.WriteLine(confi.GetSection("constr").Value);
        var connectionStr = confi.GetSection("constr").Value;
        SqlConnection conn = new SqlConnection(connectionStr);

        var sql = "SELECT * FROM WALLETS";

        SqlCommand cmd = new SqlCommand(sql, conn);

        cmd.CommandType = CommandType.Text; 

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        Wallet wallate;

        while (reader.Read())
        {
            wallate = new Wallet
            {
                Id = reader.GetInt32("Id"),
                Holder = reader.GetString("Holder"),
                Balance = reader.GetDecimal("Balance"),
            };
            Console.WriteLine(wallate);
        }
        conn.Close();
        Console.ReadKey();
    }
}

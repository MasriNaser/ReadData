

using Microsoft.Extensions.Configuration;

namespace Currency;

class Program
{
    public static void Main()
    {
        var confi = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        Console.WriteLine(confi.GetSection("constr").Value);

        Console.ReadKey();
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Helpers;

public class ConnectionStr
{
    public static string GetConnectionString()
    {
        ConfigurationManager configurationManager = new ConfigurationManager();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Ecommerce.API"));
        configurationManager.AddJsonFile("appsettings.json");

        string? connectionString = configurationManager.GetConnectionString("MsSql");
        if (connectionString is null)
        {
            throw new Exception("Connection String not found");
        }
        return connectionString;
    }
}
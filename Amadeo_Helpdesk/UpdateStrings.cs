using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Amadeo_Helpdesk
{
    internal class UpdateStrings
    {
        
        public void UpdateBufor()
        {
            string[] connectionStrings = JsonConvert.DeserializeObject<string[]>(File.ReadAllText(@"E:\dotnet\Amadeo_Helpdesk\list_connection_string.json"));
            for (int i = 0; i < connectionStrings.Length; i++)
            {
                using var con = new NpgsqlConnection(connectionStrings[i]);
                con.Open();
                var sql = "update stan_na_dzien set odebrano=1 where odebrano=0";

                using var cmd = new NpgsqlCommand(sql, con);
                cmd.CommandTimeout = 1000;
                var result = cmd.ExecuteNonQuery();
                Console.WriteLine(result);
            }

        }



    }
}

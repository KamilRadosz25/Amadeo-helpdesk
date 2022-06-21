using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amadeo_Helpdesk
{
    internal class Special_price 
    {

        public List<int> IdGood { get; set; } = new List<int>();
        public string _constring;
        
        public Special_price()
        {
            InitConString();
            using var con = new NpgsqlConnection(_constring);
            con.Open();

        }
        private void InitConString()
        {
            _constring = File.ReadAllText(@"E:\dotnet\Amadeo_Helpdesk\con_strin_vat_centrala.txt");
        }

        public void AddToSpecialList()
        {
            Console.WriteLine();
            string userInput = Console.ReadLine(); 
            while(userInput != "x")
            {
               userInput = Console.ReadLine();
               IdGood.Add(int.Parse(userInput));
            }
        }
        public string CreateExtendUpdate()
        {
            string values = String.Empty;
             foreach(int id in IdGood)
             {
                values += id.ToString() + ",";
             }
             values= values.Remove(values.Length - 1);
            return values;
        }
        public void ChangeSpecialPrice()

        {
            var sql = $"UPDATE kartotekatowaru SET objety_csp=0 WHERE id IN ({CreateExtendUpdate()})";



        }


    }
}

using System;
using System.IO;
using Newtonsoft.Json;
using Npgsql;


namespace Amadeo_Helpdesk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var amadeoErp = new AmadeoErp();
            int option = Convert.ToInt32(Console.ReadLine());
            int trueCostInvoice;
            int invoiceNumber;
            string date;
            switch(option)
            {
                case 1:
                    amadeoErp.RunSpecialPriceFeature();
                    break;
                case 2:
                    amadeoErp.FlushWeeklyBuffer();
                    break;
                case 3:
                    amadeoErp.RunUpdateReceiptsStates();
                    break;
                case 4:
                    Console.WriteLine("Podaj numer faktury");
                    invoiceNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Podaj date założenia faktury");
                    date = Console.ReadLine();


                default:
                    Console.WriteLine("Nie wybrałeś żadnej opcji");
                    break;
            }
            //stworzyc update do bazy
            //stworzony select 

            

          
            



           



        }
    }
}

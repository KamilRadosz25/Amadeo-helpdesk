using System;

namespace Amadeo_Helpdesk
{
    internal class AmadeoErp
    {
        private FileReader _fileReader;
        private QueryBuilder _queryBuilder;

        public AmadeoErp()
        {
            _fileReader = new FileReader();
            _queryBuilder = new QueryBuilder();
        }

        public void RunSpecialPriceFeature()
        {
            var connectionString = _fileReader.ReadDbSpecialPriceConnectionString(@"E:\dotnet\Amadeo_Helpdesk\con_strin_vat_centrala.txt");
            //1. Pobieranie ID z pliku
            var ids = _fileReader.ReadClientIds(@"E:\dotnet\Amadeo_Helpdesk\IdSpecialPrice.json");
            

            //2. Zbuduj query
            var specialPriceUpdateQuery = _queryBuilder.CreateSpecialPriceUpdateQuery(ids);

            //3. Update na bazie danych na rekorach równych id .
            var databaseManager = new DatabaseManager(connectionString);
            var updatedRecords = databaseManager.Update(specialPriceUpdateQuery);
            Console.WriteLine($"Zaaktualizowano: {updatedRecords}");
        }

        public void FlushWeeklyBuffer()
        {

            var connectionStrings = _fileReader.ReadDbConnectionStrings(@"E:\dotnet\Amadeo_Helpdesk\list_connection_string.json");


            foreach(var connectionString in connectionStrings)
            {
                var databaseManager = new DatabaseManager(connectionString);

                var bufferUpdateQuery = _queryBuilder.CreateBuforUpdateQuery();

                var updatedRecords = databaseManager.Update(bufferUpdateQuery);

                Console.WriteLine($"Zaaktualizowano: {updatedRecords}");
            }
        }
        public void RunUpdateReceiptsStates()
        {
            var ids = _fileReader.ReadReceiptIds(@"E:\dotnet\Amadeo_Helpdesk\salami_receipt_ids.json");
            var connectionString = _fileReader.ReadDbSalamiConnectionString(@"E:\dotnet\Amadeo_Helpdesk\con_string_salami.txt");
            var receiptStatesQuery = _queryBuilder.CreateReceiptStatesUpdateQuery(ids);

            var databaseManager = new DatabaseManager(connectionString);

            var updateReceiptStates = databaseManager.Update(receiptStatesQuery);

            Console.WriteLine($" Zaaktualizowano: {updateReceiptStates} paragonów");
          

        }
        

    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Amadeo_Helpdesk
{
    internal class FileReader
    {
        public FileReader()
        {
            
        }

        internal List<int> ReadClientIds(string fileName)
        {
            
            return JsonConvert.DeserializeObject<List<int>>(File.ReadAllText(fileName));
        }
        public List<string> ReadDbConnectionStrings(string fileName)
        {
            return JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(fileName));
        }

        public string ReadDbSpecialPriceConnectionString(string fileName)
        {
            return File.ReadAllText(fileName);
            
        }
        public List<int> ReadReceiptIds(string fileName)
        {
            return JsonConvert.DeserializeObject<List<int>>(File.ReadAllText(fileName));

        }
        public string ReadDbSalamiConnectionString(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
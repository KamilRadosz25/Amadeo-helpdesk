using System;
using System.Collections.Generic;
using System.Linq;

namespace Amadeo_Helpdesk
{
    internal class QueryBuilder
    {
        public QueryBuilder()
        {
        }

        public string CreateSpecialPriceUpdateQuery(List<int> ids)
        {
            return $"UPDATE kartotekatowaru SET objety_csp=0 WHERE id IN ({TransformToString(ids)})";
        }

        internal string CreateBuforUpdateQuery()
        {
            return "UPDATE stan_na_dzien set odebrano=1 where odebrano=0";
        }
        public string CreateReceiptStatesUpdateQuery(List<int> ids)
        {
            return $"UPDATE tabelazakupy SET fiskalny=1 WHERE numer_wew IN ({TransformToString(ids)})";
        }
        
        public string CreateCostInvoiceUpdateQuery(double trueCost, int invoiceNumber, string date)
        {
            return $"UPDATE tabelazakupy SET detbru={trueCost},bezrab={trueCost} WHERE numer_wew ={invoiceNumber} and data_z={date}";
        }

        public string CreateInvoiceInfoSelectQuery(int invoiceNumber, string date)
        {
            return $"SELECT numer_wew, data_z, detbru, bezrab FROM tabelazakupy WHERE numer_wew ={invoiceNumber} and data_z={date}";
        }
        private string TransformToString(List<int> ids)
        {
            return string.Join(',', ids);
        }
    }
}
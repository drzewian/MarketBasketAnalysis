using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketBasketAnalysis.Logic
{
    class LoadTransactions
    {
        public StreamReader sr { get; set; }

        public LoadTransactions(StreamReader sr)
        {
            this.sr = sr;
        }

        public List<List<string>> Load()
        {
            List<List<string>> transactions = new List<List<string>>();
            List<string> trans;

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                trans = new List<string>();

                foreach(var item in line.Split(','))
                {
                    trans.Add(item.Trim().ToLower());
                }
                transactions.Add(trans);
            }
            return transactions;
        }
    }
}

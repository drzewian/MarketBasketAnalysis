using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketBasketAnalysis.Logic
{
    class Apriori
    {
        private Dictionary<int, List<string>> transactions;
        public int MinimumSupportCount { private get; set; }



        public Apriori(Dictionary<int, List<string>> transactions, int minimumSupportCount)
        {
            this.transactions = transactions;
            this.MinimumSupportCount = minimumSupportCount;
        }

        public Dictionary<string, int> FirstCandidates(Dictionary<int, List<string>> trans)
        {
            if (trans == null)
                return null;

            Dictionary<string, int> firstCandidates = new Dictionary<string, int>();

            foreach (var transaction in trans)
            {
                foreach (var item in transaction.Value)
                {
                    if (firstCandidates != null && firstCandidates.Keys.Contains(item))
                    {
                        firstCandidates[item] += 1;
                        continue;
                    }
                    firstCandidates.Add(item, 1);
                }
            }
            return firstCandidates;
        }
        
        private void NextCandidates()
        {

        }
        
        public Dictionary<string, int> ExtractSupported(Dictionary<string, int> candidates)
        {
            List<string> notSupported = new List<string>();

            foreach (var item in candidates)
            {
                if (item.Value < MinimumSupportCount)
                {
                    notSupported.Add(item.Key);
                }
            }

            foreach (var key in notSupported)
            {
                candidates.Remove(key);
            }

            return candidates;
        } 
    }
}

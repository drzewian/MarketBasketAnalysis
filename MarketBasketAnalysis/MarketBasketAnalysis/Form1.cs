using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketBasketAnalysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<int, List<string>> transactions = new Dictionary<int, List<string>>();
            List<string> lista = new List<string> { "1", "3", "4" };
            List<string> lista1 = new List<string> { "2", "3", "5" };
            List<string> lista2 = new List<string> { "1", "2", "3", "5" };
            List<string> lista3 = new List<string> { "2", "5" };
            List<string> lista4 = new List<string> { "1", "3", "5" };
            transactions.Add(0, lista);
            transactions.Add(1, lista1);
            transactions.Add(2, lista2);
            transactions.Add(3, lista3);
            transactions.Add(4, lista4);

            int minimumSupportCount = 2;

            Dictionary<string, int> candidates1 = new Dictionary<string, int>();

            foreach (var transaction in transactions)
            {
                foreach (var item in transaction.Value)
                {
                    if (candidates1 != null && candidates1.Keys.Contains(item))
                    {
                        candidates1[item] += 1;
                        continue;
                    }

                    candidates1.Add(item, 1);
                }
            }

            //foreach (var item in candidates1)
            //{
            //    if (item.Value < minimumSupportCount)
            //    {
            //        candidates1.Remove(item.Key);
            //    }
            //}

            foreach (var item in candidates1)
            {
                listBox1.Items.Add(item);
            }

        }
    }
}

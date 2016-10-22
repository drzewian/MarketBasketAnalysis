using MarketBasketAnalysis.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketBasketAnalysis
{    
    public partial class Form1 : Form
    {
        List<List<string>> transactions;
        Apriori apriori;
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();            
            
            apriori.SetUp(trackBar1.Value);
            apriori.FindFrequent();

            foreach (var item in apriori.FirstFrequent)
            {
                listBox1.Items.Add(item);
            }

            foreach (var item in apriori.FrequentItemSets)
            {
                listBox2.Items.Add(item);
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            transactions = new List<List<string>>();

            List<string> lista1 = new List<string> { "bread", "peanuts", "milk", "fruit", "jam" };
            List<string> lista2 = new List<string> { "bread", "jam", "soda", "chips", "milk", "fruit" };
            List<string> lista3 = new List<string> { "steak", "jam", "soda", "chips", "bread" };
            List<string> lista4 = new List<string> { "jam", "soda", "peanuts", "milk", "fruit" };
            List<string> lista5 = new List<string> { "jam", "soda", "chips", "milk", "bread" };
            List<string> lista6 = new List<string> { "fruit", "soda", "chips", "milk" };
            List<string> lista7 = new List<string> { "fruit", "soda", "peanuts", "milk" };
            List<string> lista8 = new List<string> { "fruit", "peanuts", "cheese", "yogurt" };

            transactions.Add(lista1);
            transactions.Add(lista2);
            transactions.Add(lista3);
            transactions.Add(lista4);
            transactions.Add(lista5);
            transactions.Add(lista6);
            transactions.Add(lista7);
            transactions.Add(lista8);

            apriori = new Apriori(transactions);
            trackBar1.Maximum = apriori.FirstFrequent.Values.ToList().Max();
            labelSupportMax.Text = trackBar1.Maximum.ToString();

            button1.Enabled = true;
            trackBar1.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBoxSupportValue.Text = trackBar1.Value.ToString();
        }
    }
}

﻿using MarketBasketAnalysis.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketBasketAnalysis
{    
    public partial class Form1 : Form
    {        
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
                listBox1.Items.Add(item.Key + " - " + item.Value);
            }

            foreach (var item in apriori.FrequentItemSets)
            {
                listBox2.Items.Add(item.Key + " - " + item.Value);
            }

            button3.Enabled = true;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
                        
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            StreamReader sr = new StreamReader(myStream);
                            LoadTransactions lt = new LoadTransactions(sr);
                            List<List<string>> transactions;
                            transactions = lt.Load();
                            apriori = new Apriori(transactions);                                                                                     
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            foreach(var transacion in apriori.transactions)
            {
                StringBuilder tempString = new StringBuilder();

                foreach(var item in transacion)
                {
                    tempString.Append(item + ", ");
                }
                listBox4.Items.Add(tempString.ToString());
            }

            trackBar1.Maximum = apriori.FirstFrequent.Values.ToList().Max();
            labelSupportMax.Text = trackBar1.Maximum.ToString();
            textBoxSupportValue.Text = trackBar1.Value.ToString();

            button1.Enabled = true;
            trackBar1.Enabled = true;
            trackBar2.Enabled = true;
            button3.Enabled = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBoxSupportValue.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBoxConfidenceValue.Text = trackBar2.Value.ToString() + "%";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            apriori.GetConfidence(trackBar2.Value);

            foreach (var item in apriori.ConfidenceItemSets)
            {                                
                listBox3.Items.Add(item.Key + " - " + Math.Round(item.Value, 2));
            }
        }
    }
}

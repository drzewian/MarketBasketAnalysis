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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<List<string>> transactions = new List<List<string>>();
            List<string> lista = new List<string> { "1", "3", "4" };
            List<string> lista1 = new List<string> { "2", "3", "5" };
            List<string> lista2 = new List<string> { "1", "2", "3", "5" };
            List<string> lista3 = new List<string> { "2", "5" };
            List<string> lista4 = new List<string> { "1", "3", "5" };
            transactions.Add(lista);
            transactions.Add(lista1);
            transactions.Add(lista2);
            transactions.Add(lista3);
            transactions.Add(lista4);

            int minimumSupportCount = 2;

            Apriori apriori = new Apriori(transactions, minimumSupportCount);

            Dictionary<string, int> firstCandidates = apriori.ExtractSupported(apriori.FirstCandidates(transactions));                     
            
            foreach (var item in firstCandidates)
            {
                listBox1.Items.Add(item);
            }

            //Second Canditates
            Dictionary<string, int> secondCandidates = new Dictionary<string, int>();

            List<string> myList = firstCandidates.Keys.ToList();//new List<string> { "A", "B", "C", "D", "Z" };
            List<string> myListSecond = firstCandidates.Keys.ToList();//new List<string> { "A", "B", "C", "D", "Z" };
            //Regex r

            foreach (var item in myList)
            {
                listBox2.Items.Add(item);
            }            

            while(myList.Count != 0)
            {                
                for(int i = 1 ; i<myListSecond.Count;i++)
                {   
                    if (myList.ElementAt(0) == myListSecond.ElementAt(i) || 
                        secondCandidates.Keys.Contains(myList.ElementAt(0) + "," + myListSecond.ElementAt(i)) ||
                        secondCandidates.Keys.Contains(myListSecond.ElementAt(i) + "," + myList.ElementAt(0)))
                    {
                        continue;
                    }
                    secondCandidates.Add(myList.ElementAt(0) + "," + myListSecond.ElementAt(i), 0);
                }
                myList.RemoveAt(0);                
            }


            foreach(var key in secondCandidates.Keys.ToList())
            {
                List<string> tempSplit = key.Split(',').ToList();

                foreach(List<string> transaction in transactions)
                {

                    var xxx = tempSplit.Except(transaction);

                    if(tempSplit.Except(transaction).Any())
                    {
                        continue;
                    }
                    secondCandidates[key] += 1;
                }
            }

            

            foreach (var item in secondCandidates)
            {
                listBox3.Items.Add(item);
            }


            //Third Candidates
            List<string> myList3 = new List<string>();
                      

            List<string> list1 = new List<string> { "Aa", "Bb", "Cc" };
            List<string> list2 = new List<string> { "Aa", "Cc", "Bb", "Bb" };
            List<string> list3 = new List<string> { "Aa", "Bb", "Dd" };

            var cos = list1.Except(list2);
            var cos1 = list1.Except(list3);
            var cos2 = list1.Except(list2).Any();
            var cos3 = list1.Except(list3).Any();

            listBox4.Items.Add(cos3);

            foreach (var item in cos1)
            {
                listBox4.Items.Add(item);
            }

            //foreach (var item in myList2)
            //{
            //List<string> tempSplit = item.Split(',').ToList();
            //List<string> tempLeft = new List<string>();

            //var cose = tempSplit.Except(myList);

            //foreach(var itemFirst in myList)
            //{
            //    var result = tempSplit.Except(itemFirst);
            //if(tempSplit.Except(item))
            //{

            //}
            //}
            //if (result.Count() == 0)
            //{
            //    myList3.Add(item + "," + )
            //}
            //}



            //foreach (var transaction in transactions)
            //{
            //    foreach (var item in transaction.Value)
            //    {
            //        if (firstCandidates != null && firstCandidates.Keys.Contains(item))
            //        {
            //            firstCandidates[item] += 1;
            //            continue;
            //        }

            //        firstCandidates.Add(item, 1);
            //    }
            //}

        }
    }
}

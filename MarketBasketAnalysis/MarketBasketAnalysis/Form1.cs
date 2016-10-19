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

            Dictionary<string, int> firstCandidates = new Dictionary<string, int>();

            foreach (var transaction in transactions)
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

            List<string> notSupported = new List<string>();

            foreach (var item in firstCandidates)
            {
                if (item.Value < minimumSupportCount)
                {
                    notSupported.Add(item.Key);                    
                }
            }

            foreach(var key in notSupported)
            {
                firstCandidates.Remove(key);
            }

            foreach (var item in firstCandidates)
            {
                listBox1.Items.Add(item);
            }

            //Second Canditates
            Dictionary<string, int> secondCandidates = new Dictionary<string, int>();

            List<string> myList = new List<string> { "A", "B", "C", "D", "Z" };
            //Regex r

            foreach (var item in myList)
            {
                listBox2.Items.Add(item);
            }

            List<string> myList2 = new List<string>();

            while(myList.Count != 0)
            {                
                for(int i = 1 ; i<myList.Count;i++)
                {                   
                    myList2.Add(myList.ElementAt(0) + "," + myList.ElementAt(i));
                }
                myList.RemoveAt(0);                
            }

            foreach (var item in myList2)
            {
                listBox3.Items.Add(item);
            }


            //Third Candidates
            List<string> myList3 = new List<string>();

            var isExist = myList.Except(myList2);

            List<string> list1 = new List<string> { "Aa", "Bb", "Cc" };
            List<string> list2 = new List<string> { "Aa", "Cc", "Bb", "Bb" };
            List<string> list3 = new List<string> { "Aa", "Bb", "Dd" };

            var cos = list1.Except(list2);
            var cos1 = list1.Except(list3);
            var cos2 = list1.Except(list2).Any();
            var cos3 = list1.Except(list3).Any();

            foreach (var item in myList2)
            {
                List<string> tempSplit = item.Split(',').ToList();
                //List<string> tempLeft = new List<string>();

                var cose = tempSplit.Except(myList);
                                
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
            }



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

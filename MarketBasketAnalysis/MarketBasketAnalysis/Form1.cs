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
            List<string> lista1 = new List<string> { "bread", "peanuts", "milk", "fruit", "jam" };
            List<string> lista2 = new List<string> { "bread", "jam", "soda", "chips", "milk", "fruit" };
            List<string> lista3 = new List<string> { "steak", "jam", "soda", "chips", "bread" };
            List<string> lista4 = new List<string> { "jam", "soda", "peanuts", "milk", "fruit" };
            List<string> lista5 = new List<string> { "jam", "soda", "chips", "milk", "bread" };
            List<string> lista6 = new List<string> { "fruit", "soda", "chips", "milk" };
            List<string> lista7 = new List<string> { "fruit", "soda", "peanuts", "milk" };
            List<string> lista8 = new List<string> { "fruit", "peanuts", "cheese", "yogurt" };
            //List<string> lista9 = new List<string> { "I1", "I2", "I3" };

            transactions.Add(lista1);
            transactions.Add(lista2);
            transactions.Add(lista3);
            transactions.Add(lista4);
            transactions.Add(lista5);
            transactions.Add(lista6);
            transactions.Add(lista7);
            transactions.Add(lista8);
            //transactions.Add(lista9);

            int minimumSupportCount = 4;

            Apriori apriori = new Apriori(transactions, minimumSupportCount);

            apriori.Start();                     
            
            foreach (var item in apriori.fFrequent)
            {
                listBox1.Items.Add(item);
            }

            foreach (var item in apriori.sFrequent)
            {
                listBox2.Items.Add(item);
            }

            foreach (var item in apriori.tFrequent)
            {
                listBox3.Items.Add(item);
            }

            foreach (var item in apriori.foFrequent)
            {
                listBox4.Items.Add(item);
            }

            string myString = "1,2,3";

            List<string> myList = PruneElements(myString);

            List<string> toPruneList = new List<string> { "1,2", "1,3", "2,3" };
            List<string> PruneList = new List<string> { "1,3", "1,5", "3,2", "2,5", "3,5" };

            listBox4.Items.Add(NeedToBePrune(toPruneList, PruneList));

            foreach (var item in myList)
            {
                listBox4.Items.Add(item);
            }


            ////Second Canditates
            //Dictionary<string, int> secondCandidates = new Dictionary<string, int>();

            //List<string> myList = /*firstCandidates.Keys.ToList();/*/new List<string> { "1,3", "1,5", "2,3", "2,5", "3,5" };
            //List<string> myListSecond = /*firstCandidates.Keys.ToList();/*/new List<string> { "1", "2", "3", "5" };
            ////Regex r

            //foreach (var item in myList)
            //{
            //    listBox2.Items.Add(item);
            //}            

            //while(myList.Count != 0)
            //{                
            //    for(int i = 1 ; i<myListSecond.Count;i++)
            //    {   
            //        if (IsContainElement(myList.ElementAt(0), myListSecond.ElementAt(i)) ||
            //            IsContainElement(myList.ElementAt(0) + "," + myListSecond.ElementAt(i), secondCandidates.Keys.ToList()))                        
            //        {
            //            continue;
            //        }
            //        secondCandidates.Add(myList.ElementAt(0) + "," + myListSecond.ElementAt(i), 0);
            //    }
            //    myList.RemoveAt(0);                
            //}


            //foreach(var key in secondCandidates.Keys.ToList())
            //{
            //    List<string> tempSplit = key.Split(',').ToList();

            //    foreach(List<string> transaction in transactions)
            //    {                    
            //        if(tempSplit.Except(transaction).Any())
            //        {
            //            continue;
            //        }
            //        secondCandidates[key] += 1;
            //    }
            //}            
        }

        private List<string> PruneElements(string item)
        {
            List<string> elements = new List<string>();
            List<string> itemList = item.Split(',').ToList();            

            for (int i = 0; i < itemList.Count; i++)
            {
                List<string> temp = new List<string>(itemList);
                temp.RemoveAt(i);

                StringBuilder tempString = new StringBuilder(temp[0]);

                for (int j = 1; j < temp.Count; j++)
                {
                    tempString.Append("," + temp[j]);
                }
                elements.Add(tempString.ToString());
            }

            return elements;
        }

        private bool NeedToBePrune(List<string> firstElement, List<string> secondElement)
        {
            if (firstElement == null || secondElement == null)
            {
                return false;
            }           

            foreach (var item in firstElement)
            {
                int counter = 0;
                List<string> tempElements = item.Split(',').ToList();

                foreach (var element in secondElement)
                {
                    if (!tempElements.Except(element.Split(',').ToList()).Any())
                    {
                        counter+=1;
                    }                    
                }
                if(counter == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

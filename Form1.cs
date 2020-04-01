using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortAlgorithm
{
    public partial class Form1 : Form
    {
        int[] numbers = new int[10];
        
        //check if input is an integer or a string
        static bool isNumber(string s)
        {
            int distance;
            while (!int.TryParse(s,out distance))
            {
                return false;
            }
            return true;
        }
        

        void bubbleSort_smalltobig(int[] Array)
        {
            int i;
            int j;
            int TempValue;

            for (i = (Array.Length - 1); i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    if (Array[j - 1] > Array[j])
                    {
                        TempValue = Array[j - 1];
                        Array[j - 1] = Array[j];
                        Array[j] = TempValue;
                    }
                }
            }
        }

        void bubbleSort_bigtosmall(int[] Array)
        {
            int i;
            int j;
            int TempValue;

            for (i = (Array.Length - 1); i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    if (Array[j - 1] < Array[j])
                    {
                        TempValue = Array[j - 1];
                        Array[j - 1] = Array[j];
                        Array[j] = TempValue;
                    }
                }
            }
        }

        void selectionSort_smalltobig(int[] Array)
        {
            int n = Array.Length;

            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (Array[j] < Array[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first 
                // element 
                int temp = Array[min_idx];
                Array[min_idx] = Array[i];
                Array[i] = temp;
            }
        }

        void selectionSort_bigtosmall(int[] Array)
        {
            int n = Array.Length;

            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (Array[j] > Array[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first 
                // element 
                int temp = Array[min_idx];
                Array[min_idx] = Array[i];
                Array[i] = temp;
            }
        }
        void insertionSort_smalltobig(int[] Array)
        {
            int i;
            int j;
            int IndexValue;

            for (i = 1; i < Array.Length; i++)
            {
                IndexValue = Array[i];
                j = i;

                while ((j > 0) && (Array[j - 1] > IndexValue))
                {
                    Array[j] = Array[j - 1];
                    j = j - 1;
                }

                Array[j] = IndexValue;
            }
        }

        void insertionSort_bigtosmall(int[] Array)
        {
            int i;
            int j;
            int IndexValue;

            for (i = 1; i < Array.Length; i++)
            {
                IndexValue = Array[i];
                j = i;

                while ((j > 0) && (Array[j - 1] < IndexValue))
                {
                    Array[j] = Array[j - 1];
                    j = j - 1;
                }

                Array[j] = IndexValue;
            }
        }




    public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If the bubble sort is selected
            if (comboBox1.SelectedIndex == 0)
            {
                bubbleSort_smalltobig(numbers);
                listBox3.Items.Clear();
                //enter the numbers listbox3
                for (int i = 0; i < 10; i++)
                {
                    
                    listBox3.Items.Add(numbers[i]);
                }

                bubbleSort_bigtosmall(numbers);
                listBox2.Items.Clear();
                //enter the numbers listbox2
                for (int i = 0; i < 10; i++)
                {
                    
                    listBox2.Items.Add(numbers[i]);
                }

            }//If the selection sort is selected
            else if (comboBox1.SelectedIndex == 1)
            {
                selectionSort_smalltobig(numbers);
                listBox3.Items.Clear();
                //enter the number listbox3
                for (int i = 0; i < 10; i++)
                {
                    
                    listBox3.Items.Add(numbers[i]);
                }

                selectionSort_bigtosmall(numbers);
                //enter the numbers listbox2
                listBox2.Items.Clear();
                for (int i = 0; i < 10; i++)
                {
                    listBox2.Items.Add(numbers[i]);
                }
            }//if the insertion sort is selected
            else if (comboBox1.SelectedIndex == 2)
            {
                insertionSort_smalltobig(numbers);
                listBox3.Items.Clear();
                //enter the numbers listbox3
                for(int i = 0; i < 10; i++)
                {
                    listBox3.Items.Add(numbers[i]);
                }
                insertionSort_bigtosmall(numbers);
                listBox2.Items.Clear();
                //enter the numbers listbox2
                for(int i = 0; i < 10; i++)
                {
                    listBox2.Items.Add(numbers[i]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //Getting number from user
            for(int i = 0; i < 10; i++)
            {
                string enteredNumber = Interaction.InputBox("Enter the"+ i+". Number", "Getting Number", "Exp: 25 ", 0, 0);
                if (isNumber(enteredNumber))    //Check the entered number is integer or string
                {
                    numbers[i] = Convert.ToInt32(enteredNumber);
                }
                else
                {
                    //if input is string
                    i--;
                }
            }

            //Write the numbers to listbox1
            for(int i = 0; i < 10; i++)
            {
                listBox1.Items.Add(numbers[i]);
            }

            
        }
    }
}

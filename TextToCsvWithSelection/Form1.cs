using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextToCsvWithSelection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream chooseStream = null;
            OpenFileDialog toRead = new OpenFileDialog();
           
            //setup defaults
            toRead.InitialDirectory = "c:\\";
            toRead.Filter = "txt files (*.txt)|*.txt";
            toRead.FilterIndex = 2;
            toRead.RestoreDirectory = true;
            
            //make sure the selection window is working
            if (toRead.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string outPath = toRead.FileName+".csv";
                    StreamWriter outLines = new StreamWriter(outPath);

                    //create a stream to read the file
                    if ((chooseStream = toRead.OpenFile()) != null)
                    {
                        //using the file
                        using (toRead)
                        {
                  
                            using (StreamReader sr = new StreamReader(chooseStream))
                            {
                                while (sr.Peek() >= 0)
                                {
                                    //reading 1 line at a time, turn spaces into ,'s
                                    string clean = System.Text.RegularExpressions.Regex.Replace(sr.ReadLine(), @"\s+", ",");
                                    outLines.WriteLine(clean);
                                }
                            }
                        }
                    }
                }
                //make sure things went as planned
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file" + ex.Message);
                }
            }
            //close the window after selecting the file
            Application.Exit();
        }

        //text for the window
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
   
}
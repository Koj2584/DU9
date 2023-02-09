using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_stream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            if(file.ShowDialog() == DialogResult.OK)
            {
                StreamReader ctenar = new StreamReader(file.FileName, Encoding.GetEncoding("windows-1250"));
                listBox1.Items.Clear();
                while (!ctenar.EndOfStream)
                    listBox1.Items.Add(ctenar.ReadLine());
                ctenar.Close();
            }

            int pocet = 0;
            foreach (string line in listBox1.Items)
            {
                vymazMezery(line);

                if(radioButton1.Checked)
                {
                    foreach(char c in line)
                    {
                        if (c == '.' || c == '!' || c == '?')
                            pocet++;
                    }
                } else
                {
                    pocet += line.Split(' ').Length;
                }
            }
            MessageBox.Show("Počet prvků: " + pocet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.DefaultExt = ".txt";
            if (file.ShowDialog() == DialogResult.OK)
            {
                StreamWriter zapis = new StreamWriter(file.FileName, true, Encoding.GetEncoding("windows-1250"));

                foreach(string line in listBox1.Items)
                {
                    zapis.WriteLine(vymazMezery(line));
                }
                zapis.Close();
            }
        }

        string vymazMezery(string vstup)
        {
            string clearLine = vstup.Trim();
            while (clearLine.Contains("  "))
                clearLine = clearLine.Replace("  ", " ");
            return clearLine;
        }
    }
}

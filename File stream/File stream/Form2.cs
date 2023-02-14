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

namespace File_stream
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int soucet = 0, pocetLich = 0, pocetSud = 0;
            StreamReader ctenar = new StreamReader("cislo.txt", Encoding.GetEncoding("windows-1250"));
            listBox1.Items.Clear();
            while (!ctenar.EndOfStream)
            {
                listBox1.Items.Add(ctenar.ReadLine());
                int cislo = 0;
                string vstup = listBox1.Items[listBox1.Items.Count - 1].ToString();
                cislo = int.Parse(vstup);
                if (cislo % 2 == 0 && cislo != 0)
                    pocetSud++;
                else
                    pocetLich++;
                soucet += cislo;
            }
            ctenar.Close();

            StreamWriter zapis = new StreamWriter("cislo.txt", true, Encoding.GetEncoding("windows-1250"));
            zapis.WriteLine("\n"+soucet);
            zapis.WriteLine(pocetLich);
            zapis.WriteLine(pocetSud);
            zapis.Close();

            ctenar = new StreamReader("cislo.txt", Encoding.GetEncoding("windows-1250"));
            listBox2.Items.Clear();
            while (!ctenar.EndOfStream)
                listBox2.Items.Add(ctenar.ReadLine());
            ctenar.Close();
        }
    }
}

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
            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == DialogResult.OK)
            {
                StreamReader ctenar = new StreamReader(file.FileName, Encoding.GetEncoding("windows-1250"));
                listBox1.Items.Clear();
                while (!ctenar.EndOfStream)
                    listBox1.Items.Add(ctenar.ReadLine());
                ctenar.Close();
            }
        }
    }
}

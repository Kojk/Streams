using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Streams
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";                           // hlada na c:\   
            openFileDialog1.Title = "Vyber subor"; 
            openFileDialog1.CheckFileExists = true;                              // poistka existujuceho suboru
            openFileDialog1.CheckPathExists = true;                              // poistka existujucej cesty
            openFileDialog1.Filter = "Text files TXT | *.TXT";                   // vyberá iba txt
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;                        // vypise cestu file
                // StreamReader pre citanie streamu zo suboru
                // using blok pre automaticke uvolnenie streamu DOLEZITE aby uvolnil subor
                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    string obsahSouboru = reader.ReadToEnd();
                    textBox2.Text = obsahSouboru;

                }
                using (StreamWriter writer = new StreamWriter(@"c:\temp\KOPIE.txt", true))
                {
                    // vytvori novy file vlozi text z okna a zvacsi vsetky pismena
                    writer.WriteLine();
                    writer.Write(textBox2.Text.ToUpper());
                }
                ZipFile.CreateFromDirectory(@"C:\temp", @"C:\temp1\kopie.zip");
            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            using(StreamReader htmlReader = new StreamReader(webClient.OpenRead(textBox3.Text)))
            {
                textBox2.Text = htmlReader.ReadToEnd();

            }

        }
    }
}

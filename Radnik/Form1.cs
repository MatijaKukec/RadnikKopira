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

namespace Radnik
{
    public partial class Form1 : Form
    {
        BackgroundWorker radnik = new BackgroundWorker();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        OpenFileDialog ofd = new OpenFileDialog();

        string original =null, kopija = null;

        public Form1()
        {
            InitializeComponent();

            radnik.WorkerReportsProgress = true;
            radnik.WorkerSupportsCancellation = true;

            radnik.DoWork += new DoWorkEventHandler(radnik_DoWork);
            radnik.ProgressChanged += new ProgressChangedEventHandler(radnik_ProgressChanged);
            radnik.RunWorkerCompleted += new RunWorkerCompletedEventHandler(radnik_RunWorkerCompleted);
            
        }

        private void Copy(string ulaznaputanja, string izlaznaputanja)
        {
            int bufferSize = 1024 * 1024;


            try
            {
            using (FileStream fileStream = new FileStream(izlaznaputanja, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            //using (FileStream fs = File.Open(<file-path>, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                    FileStream fs = new FileStream(ulaznaputanja, FileMode.Open, FileAccess.ReadWrite);
                    fileStream.SetLength(fs.Length);
                    int bytesRead = -1;
                    byte[] bytes = new byte[bufferSize];

                    while ((bytesRead = fs.Read(bytes, 0, bufferSize)) > 0)
                    {
                        fileStream.Write(bytes, 0, bytesRead);
                        radnik.ReportProgress((int)(fs.Position * 100 / fs.Length));
                    }

                    fs.Close();
                    fileStream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }  

        private void radnik_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Tekst.Text = e.ProgressPercentage.ToString();
            progressBar1.Value = e.ProgressPercentage;
        }

        private void radnik_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                Tekst.Text = "Otkazano!";
                progressBar1.Value = 0;
            }

            else if (!(e.Error == null))
            {
                Tekst.Text = ("Greška: " + e.Error.Message);
            }
            else
            {
                Tekst.Text = "Gotovo!";
            }
        }

        private void radnik_DoWork(object sender, DoWorkEventArgs e)
        {

            for (int i = 1; (i <= 100); i++)
            {
                if ((radnik.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Obavljanje zahtjevne operacije i proslijeđivanje statusa
                    Copy(original, kopija+ @"\" + Path.GetFileName(original));
                    radnik.ReportProgress((i));
                }
            }
        }

        private void OdaberiFolder_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() ==DialogResult.OK)
            {
                kopija = fbd.SelectedPath;
                textBox2.Text = kopija + @"\" + Path.GetFileName(original);
            }
        }

        private void Kopiraj_Click(object sender, EventArgs e)
        {
            if (radnik.IsBusy != true)
            {
                // Metodom RunWorkerAsync se pokreće izvođenje operacije u pozadini
                radnik.RunWorkerAsync();
            }
        }

        private void Zaustavi_Click(object sender, EventArgs e)
        {
            radnik.CancelAsync();
        }

        private void OdaberiFile_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                original = ofd.FileName;
                textBox1.Text = original;
            }
        }
        
    }
}

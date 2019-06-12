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

        string original = null, kopija = null;

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
                using (FileStream ulaznadatoteka = new FileStream(izlaznaputanja, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                {
                    FileStream izlaznadatoteka = new FileStream(ulaznaputanja, FileMode.Open, FileAccess.ReadWrite);
                    ulaznadatoteka.SetLength(izlaznadatoteka.Length);
                    int bytesRead = -1;
                    byte[] bytes = new byte[bufferSize];

                    while ((bytesRead = izlaznadatoteka.Read(bytes, 0, bufferSize)) > 0)
                    {
                        ulaznadatoteka.Write(bytes, 0, bytesRead);
                        radnik.ReportProgress((int)(izlaznadatoteka.Position * 100 / izlaznadatoteka.Length));
                    }

                    izlaznadatoteka.Close();
                    ulaznadatoteka.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void radnik_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Tekst.Text = e.ProgressPercentage.ToString()+" %";
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
            if ((radnik.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                Copy(original, kopija + @"\" + Path.GetFileName(original));
            }
        }

        private void OdaberiFolder_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                kopija = fbd.SelectedPath;
                textBox2.Text = kopija + @"\" + Path.GetFileName(original);
            }
        }

        private void Kopiraj_Click(object sender, EventArgs e)
        {
            if (radnik.IsBusy != true)
            {
                radnik.RunWorkerAsync();
            }
        }

        private void Zaustavi_Click(object sender, EventArgs e)
        {
            radnik.CancelAsync();
        }

        private void OdaberiFile_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                original = ofd.FileName;
                textBox1.Text = original;
            }
        }

    }
}

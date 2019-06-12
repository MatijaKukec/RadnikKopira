using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Radnik
{
    public partial class Form1 : Form
    {
        BackgroundWorker radnik = new BackgroundWorker();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        OpenFileDialog ofd = new OpenFileDialog();

        string original = null, kopija = null;

        public BackgroundWorker Radnik { get => radnik; set => radnik = value; }
        public FolderBrowserDialog Fbd { get => fbd; set => fbd = value; }
        public OpenFileDialog Ofd { get => ofd; set => ofd = value; }
        public string Original { get => original; set => original = value; }
        public string Kopija { get => kopija; set => kopija = value; }

        public Form1()
        {
            InitializeComponent();

            Radnik.WorkerReportsProgress = true;
            Radnik.WorkerSupportsCancellation = true;

            Radnik.DoWork += new DoWorkEventHandler(radnik_DoWork);
            Radnik.ProgressChanged += new ProgressChangedEventHandler(radnik_ProgressChanged);
            Radnik.RunWorkerCompleted += new RunWorkerCompletedEventHandler(radnik_RunWorkerCompleted);
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
                        Radnik.ReportProgress((int)(izlaznadatoteka.Position * 100 / izlaznadatoteka.Length));
                    }
                    izlaznadatoteka.Close();
                    ulaznadatoteka.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Pogreška {0}",e);
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
            if ((Radnik.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                Copy(Original, Kopija + @"\" + Path.GetFileName(Original));
            }
        }

        private void OdaberiFolder_Click(object sender, EventArgs e)
        {
            if (Fbd.ShowDialog() == DialogResult.OK)
            {
                Kopija = Fbd.SelectedPath;
                textBox2.Text = Kopija + @"\" + Path.GetFileName(Original);
            }
        }

        private void Kopiraj_Click(object sender, EventArgs e)
        {
            if (Radnik.IsBusy != true)
            {
                Radnik.RunWorkerAsync();
            }
        }

        private void Zaustavi_Click(object sender, EventArgs e)
        {
            Radnik.CancelAsync();
        }

        private void OdaberiFile_Click(object sender, EventArgs e)
        {
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                Original = Ofd.FileName;
                textBox1.Text = Original;
            }
        }

    }
}

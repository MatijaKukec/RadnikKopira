using System;

namespace Radnik
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OdaberiFile = new System.Windows.Forms.Button();
            this.OdaberiFolder = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Kopiraj = new System.Windows.Forms.Button();
            this.Zaustavi = new System.Windows.Forms.Button();
            this.Tekst = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OdaberiFile
            // 
            this.OdaberiFile.Location = new System.Drawing.Point(513, 9);
            this.OdaberiFile.Name = "OdaberiFile";
            this.OdaberiFile.Size = new System.Drawing.Size(90, 23);
            this.OdaberiFile.TabIndex = 0;
            this.OdaberiFile.Text = "Odaberi File";
            this.OdaberiFile.UseVisualStyleBackColor = true;
            this.OdaberiFile.Click += new System.EventHandler(this.OdaberiFile_Click);
            // 
            // OdaberiFolder
            // 
            this.OdaberiFolder.Location = new System.Drawing.Point(513, 53);
            this.OdaberiFolder.Name = "OdaberiFolder";
            this.OdaberiFolder.Size = new System.Drawing.Size(90, 23);
            this.OdaberiFolder.TabIndex = 1;
            this.OdaberiFolder.Text = "Odaberi Folder";
            this.OdaberiFolder.UseVisualStyleBackColor = true;
            this.OdaberiFolder.Click += new System.EventHandler(this.OdaberiFolder_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(25, 344);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(751, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(495, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(495, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Kopiraj
            // 
            this.Kopiraj.Location = new System.Drawing.Point(596, 306);
            this.Kopiraj.Name = "Kopiraj";
            this.Kopiraj.Size = new System.Drawing.Size(75, 23);
            this.Kopiraj.TabIndex = 5;
            this.Kopiraj.Text = "Kopiraj";
            this.Kopiraj.UseVisualStyleBackColor = true;
            this.Kopiraj.Click += new System.EventHandler(this.Kopiraj_Click);
            // 
            // Zaustavi
            // 
            this.Zaustavi.Location = new System.Drawing.Point(701, 306);
            this.Zaustavi.Name = "Zaustavi";
            this.Zaustavi.Size = new System.Drawing.Size(75, 23);
            this.Zaustavi.TabIndex = 6;
            this.Zaustavi.Text = "Zaustavi";
            this.Zaustavi.UseVisualStyleBackColor = true;
            this.Zaustavi.Click += new System.EventHandler(this.Zaustavi_Click);
            // 
            // Tekst
            // 
            this.Tekst.AutoSize = true;
            this.Tekst.Location = new System.Drawing.Point(46, 311);
            this.Tekst.Name = "Tekst";
            this.Tekst.Size = new System.Drawing.Size(34, 13);
            this.Tekst.TabIndex = 7;
            this.Tekst.Text = "Tekst";
            this.Tekst.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Tekst);
            this.Controls.Add(this.Zaustavi);
            this.Controls.Add(this.Kopiraj);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.OdaberiFolder);
            this.Controls.Add(this.OdaberiFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        #endregion

        private System.Windows.Forms.Button OdaberiFile;
        private System.Windows.Forms.Button OdaberiFolder;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button Kopiraj;
        private System.Windows.Forms.Button Zaustavi;
        private System.Windows.Forms.Label Tekst;
    }
}


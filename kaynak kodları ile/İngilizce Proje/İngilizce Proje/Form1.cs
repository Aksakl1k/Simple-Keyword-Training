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

namespace İngilizce_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool kelime_sayısı;
        string warning;

        void LanguageUpdate(string dil)
        {
            switch (dil)
            {
                case "Türkçe":
                    this.Text = "Ana Sayfa";
                    button1.Text = "Kelime Ekle";
                    button2.Text = "Alıştırma Yap";
                    warning = "Alıştırmaları Yapabilmek İçin En Az 6 Kelime Eklemiş Olmalısınız!"; break;
                case "English":
                    this.Text = "Main Page";
                    button1.Text = "Add Word";
                    button2.Text = "Make Exercise";
                    warning = "You Must Add Least 6 Word To Make Exercies!"; break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader oku = new StreamReader(Application.StartupPath + "\\Language.txt");
            LanguageUpdate(oku.ReadLine());
            oku.Close();

            StreamReader words = new StreamReader(Application.StartupPath + "\\Words.txt");
            int say = 0;
            while (words.ReadLine() != null)
            {
                say++;
                if(say > 5)
                {
                    kelime_sayısı = true;
                    break;
                }
            }
            words.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StreamWriter dilyaz = new StreamWriter(Application.StartupPath + "\\Language.txt");
            dilyaz.WriteLine(comboBox1.Text);
            dilyaz.Close();

            LanguageUpdate(comboBox1.Text);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Pages.AddToWord x = new Pages.AddToWord();
            x.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (kelime_sayısı)
            {
                Pages.Exercises x = new Pages.Exercises();
                x.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(warning);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

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

namespace İngilizce_Proje.Pages
{
    public partial class AddToWord : Form
    {
        public AddToWord()
        {
            InitializeComponent();
        }

        string warning;
        string closing;
        string succesful;

        void LanguageUpdate(string dil)
        {
            switch (dil)
            {
                case "Türkçe":
                    this.Text = "Kelime Ekleme";

                    label1.Text = "İlk Kelime : (Kendi Dilinizde)";
                    label2.Text = "İkinci Kelime : (İngilizce)";

                    button1.Text = "Ekle";
                    button2.Text = "Ana Sayfaya Geri Dön";

                    warning = "Tüm Alanlar Dolu Olmalıdır!";
                    closing = "Programın Düzgün Çalışması İçin Uygulamayı Yeniden Başlatınız!";
                    succesful = "Kelime Doğru Bir Şekilde Eklendi!";
                    break;
                case "English":
                    this.Text = "Adding Word";

                    label1.Text = "First Word : (In Your Language)";
                    label2.Text = "Second Word : (English)";

                    button1.Text = "Add";
                    button2.Text = "Comeback To MainPage";

                    warning = "All Places Must Be Full";
                    closing = "Restart The Program for Working Well!";
                    succesful = "Words Added Successfully!";
                    break;

            }
        }

        private void AddToWord_Load(object sender, EventArgs e)
        {
            StreamReader oku = new StreamReader(Application.StartupPath + "\\Language.txt");
            LanguageUpdate(oku.ReadLine());
            oku.Close();
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
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                StreamWriter yaz = File.AppendText(Application.StartupPath + "\\Words.txt");
                yaz.WriteLine(textBox1.Text + "," + textBox2.Text);
                yaz.Close();

                textBox1.Text = "";
                textBox2.Text = "";

                MessageBox.Show(succesful);
            }
            else
            {
                MessageBox.Show(warning);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 x = new Form1();
            x.Show();
            this.Hide();
        }

        private void AddToWord_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

            MessageBox.Show(closing);
        }
    }
}

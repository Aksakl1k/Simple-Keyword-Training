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
    public partial class Exercises : Form
    {
        public Exercises()
        {
            InitializeComponent();
        }

        List<string> english = new List<string>();
        List<string> anotherLanguage = new List<string>();

        string anotherQuestions;

        int trueCount;
        int falseCount;
        int dogruButtonNumber;

        void Checking(int answer)
        {
            if(answer == dogruButtonNumber)
            {
                trueCount++;
                lblTrueCount.Text = trueCount.ToString();
            }
            else
            {
                falseCount++;
                lblFalseCount.Text = falseCount.ToString();
            }

            button1.Text = anotherQuestions;
            button1.Enabled = true;

            btnAnswer1.Enabled = false;
            btnAnswer2.Enabled = false;
            btnAnswer3.Enabled = false;
        }

        void LanguageUpdate(string dil,bool start)
        {
            switch (dil)
            {
                case "Türkçe":
                    if (start)
                        lblWord.Text = "Başlamak İçin Düğmeye Basınız!";

                    button1.Text = "Başla";
                    button2.Text = "Ana Sayfaya Geri Dön";

                    label2.Text = "Doğru Cevap Sayısı:";
                    label3.Text = "Yanlış Cevap Sayısı:";

                    anotherQuestions = "Sonraki Soru";
                    this.Text = "Alıştırma Sayfası";
                    break;
                case "English":
                    if (start)
                        lblWord.Text = "Press The Button To Start!";

                    button1.Text = "Start";
                    button2.Text = "Go to Main Page";

                    label2.Text = "Count of True Answers:";
                    label3.Text = "Count of False Answers:";

                    anotherQuestions = "Another Question";
                    this.Text = "Exercises Page";
                    break;
            }
        }

        private void Exercises_Load(object sender, EventArgs e)
        {
            StreamReader oku = new StreamReader(Application.StartupPath + "\\Language.txt");
            LanguageUpdate(oku.ReadLine(),true);
            oku.Close();

            StreamReader kelimeler = new StreamReader(Application.StartupPath + "\\Words.txt");
            string satir = kelimeler.ReadLine();
            while (satir != null && satir != "")
            {
                anotherLanguage.Add(satir.Split(',')[0]);
                english.Add(satir.Split(',')[1]);
                satir = kelimeler.ReadLine();
            }
            kelimeler.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            Random rastgele = new Random();

            int language = rastgele.Next(0, 2);

            int dogru = rastgele.Next(0, english.Count);
            int dogru_button = rastgele.Next(0, 3);

            dogruButtonNumber = dogru_button + 1;

            btnAnswer1.Enabled = true;
            btnAnswer2.Enabled = true;
            btnAnswer3.Enabled = true;

            List<int> liste = new List<int>();
            for (int i = 0; i < english.Count - 1; i++)
            {
                liste.Add(i);
            }

            liste.Remove(dogru_button);

            if (language == 0)
            {
                List<string> testAnother = new List<string>();

                foreach (string i in anotherLanguage)
                {
                    if (i == anotherLanguage[dogru])
                        continue;
                    testAnother.Add(i);
                }

                lblWord.Text = english[dogru];

                int anlik = liste[rastgele.Next(0, liste.Count)];
                btnAnswer1.Text = testAnother[anlik];

                liste.Remove(anlik);
                anlik = liste[rastgele.Next(0, liste.Count)];
                btnAnswer2.Text = testAnother[anlik];

                liste.Remove(anlik);
                anlik = liste[rastgele.Next(0, liste.Count)];
                btnAnswer3.Text = testAnother[anlik];

                switch (dogru_button)
                {
                    case 0:
                        btnAnswer1.Text = anotherLanguage[dogru]; break;
                    case 1:
                        btnAnswer2.Text = anotherLanguage[dogru]; break;
                    default:
                        btnAnswer3.Text = anotherLanguage[dogru]; break;
                }
            }
            else
            {
                List<string> testEnglish = new List<string>();

                foreach (string i in english)
                {
                    if (i == english[dogru])
                        continue;
                    testEnglish.Add(i);
                }

                lblWord.Text = anotherLanguage[dogru];

                int anlik = liste[rastgele.Next(0, liste.Count)];
                btnAnswer1.Text = testEnglish[anlik];

                liste.Remove(anlik);
                anlik = liste[rastgele.Next(0, liste.Count)];
                btnAnswer2.Text = testEnglish[anlik];

                liste.Remove(anlik);
                anlik = liste[rastgele.Next(0, liste.Count)];
                btnAnswer3.Text = testEnglish[anlik];

                switch (dogru_button)
                {
                    case 0:
                        btnAnswer1.Text = english[dogru]; break;
                    case 1:
                        btnAnswer2.Text = english[dogru]; break;
                    default:
                        btnAnswer3.Text = english[dogru]; break;
                }
            }
        }

        private void BtnAnswer1_Click(object sender, EventArgs e)
        {
            Checking(1);
        }

        private void BtnAnswer2_Click(object sender, EventArgs e)
        {
            Checking(2);
        }

        private void BtnAnswer3_Click(object sender, EventArgs e)
        {
            Checking(3);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StreamWriter dilyaz = new StreamWriter(Application.StartupPath + "\\Language.txt");
            dilyaz.WriteLine(comboBox1.Text);
            dilyaz.Close();

            LanguageUpdate(comboBox1.Text,false);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 x = new Form1();
            x.Show();
            this.Hide();
        }

        private void Exercises_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

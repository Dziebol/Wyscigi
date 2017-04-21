using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wyscigi_zaklady
{
    public partial class Form1 : Form
    {
        
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuyArray = new Guy[3];
        Random MyRandom = new Random();

        public Form1()
        {
            InitializeComponent();

            MessageBox.Show("Gra polaga na obstawieniu 1 z 4 Chartów. Gracz, który postawił na zwycięskiego Charta ma zwracaną postawioną przez siebie kwotę, jeżeli źle obstawi traci postawioną kwotę.", "ZASADY!");
            GuyArray[0] = new Guy() { Name = "Gracz 1", Cash = 100, MyLabel = label3, MyRadioButton = radioButton1, MyBet = new Bet() };
            GuyArray[1] = new Guy() { Name = "Gracz 2", Cash = 100, MyLabel = label4, MyRadioButton = radioButton2, MyBet = new Bet() };
            GuyArray[2] = new Guy() { Name = "Gracz 3", Cash = 100, MyLabel = label5, MyRadioButton = radioButton3, MyBet = new Bet() };
         for (   int i = 0;i<GuyArray.Length; i++)
            {
                GuyArray[i].MyBet.Bettor = GuyArray[i];
            }

            GreyhoundArray[0] = new Greyhound() { MyPictureBox = dogPicture1, MyRandom = MyRandom, TrasaDlugosc = pictureBox1.Width };//Stworzenie
            GreyhoundArray[1] = new Greyhound() { MyPictureBox = dogPicture2, MyRandom = MyRandom, TrasaDlugosc = pictureBox1.Width };//każdego
            GreyhoundArray[2] = new Greyhound() { MyPictureBox = dogPicture3, MyRandom = MyRandom, TrasaDlugosc = pictureBox1.Width };//psa
            GreyhoundArray[3] = new Greyhound() { MyPictureBox = dogPicture4, MyRandom = MyRandom, TrasaDlugosc = pictureBox1.Width };//do wyścigu
            nameLabel.Text = GuyArray[0].Name;
            minimumLabel.Text = "Minimalny zakład: " + numericUpDown1.Minimum.ToString() + " zł.";

            for (int i = 0; i < GuyArray.Length; i++)
            {
                GuyArray[i].UpdateLabels();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                int guyNumber = 0;
                if (radioButton1.Checked)
                    guyNumber = 0;
                if (radioButton2.Checked)
                    guyNumber = 1;
                if (radioButton3.Checked)
                    guyNumber = 2;

                GuyArray[guyNumber].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                GuyArray[guyNumber].WylaczRadioButton();
                GuyArray[guyNumber].UpdateLabels();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < GreyhoundArray.Length; i++) 
            {
                if(GreyhoundArray[i].Run() == true)
                {
                    groupBox1.Enabled = true;
                    timer1.Stop();
                    i++;
                    var result = MessageBox.Show("CHart numer " + i + " wygrał!", "Mamy zwycięzce");
                    for (int j = 0; j < GreyhoundArray.Length; j++)
                    {
                        GreyhoundArray[j].ZajmijPozycje();
                    }
                    for (int j = 0; j < GuyArray.Length; j++)
                    {
                        if (GuyArray[j].MyBet == null)
                            break;
                        else
                        {
                            GuyArray[j].WlaczenieRadioButton();
                            GuyArray[j].MyBet.PayOut(i);
                            GuyArray[j].Collect(i);
                            GuyArray[j].UpdateLabels();
                            GuyArray[j].ClearBet();
                        }
                    }
                }
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            {
                if (MessageBox.Show("                    Zamknąć aplikację?", "Zamykanie programu...", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = GuyArray[0].Name;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = GuyArray[1].Name;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = GuyArray[2].Name;
        }
    }
}

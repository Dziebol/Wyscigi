using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wyscigi_zaklady
{
    public class Greyhound
    {
        public int PozycjaStartowa;
        public int TrasaDlugosc;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random MyRandom;

        public bool Run()
        {
            MyPictureBox.Left += MyRandom.Next(1, 4);
            Location += MyPictureBox.Left;
            if (MyPictureBox.Right >= TrasaDlugosc)
                return (true);
            else
                return false;
        }

        public void ZajmijPozycje()
        {
            MyPictureBox.Left = PozycjaStartowa;
            Location = 0;
        }
    }

   

    
}

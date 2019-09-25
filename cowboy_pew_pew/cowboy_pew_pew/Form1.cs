using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cowboy_pew_pew
{
    public partial class Form1 : Form
    {
        Cowboy goodGuy = new Cowboy();
        Cowboy badGuy = new Cowboy(2, 3, -1, -1);
        List<PictureBox> pictureBoxes = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Pictureboxen für UI-Elemente generieren
            for (int zähler = 0; zähler < 24; zähler++)
            {
                PictureBox pictureBox = new PictureBox();
                int locationX;
                if (zähler < 12)
                {
                    locationX = (zähler % 6 + 1) * 20;
                }
                else
                {
                    locationX = this.Width - 20 - (zähler % 6 + 1) * 20;
                }
                int locationY = (zähler / 6 % 2 + 1) * 20;
                pictureBox.Location = new Point(locationX, locationY);
                pictureBox.Size = new Size(20, 20);
                pictureBox.Show();
                pictureBoxes.Add(pictureBox);
                this.Controls.Add(pictureBox);
            }
            reloadUI();
        }

        void reloadUI()
        {
            // Einzelne UI-Elemente aktualisieren
            for (int zähler = 0; zähler < 24; zähler++)
            {
                switch (zähler)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        if (goodGuy.health < zähler + 1)
                        {
                            pictureBoxes[zähler].Image = new Bitmap(System.IO.Path.GetFullPath("graphics\\health_empty.png"));
                        }
                        else
                        {
                            pictureBoxes[zähler].Load(System.IO.Path.GetFullPath("graphics\\health_full.png"));
                        }
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                        if (goodGuy.bullets < zähler - 5)
                        {
                            pictureBoxes[zähler].Image = new Bitmap(System.IO.Path.GetFullPath("graphics\\bullet_empty.png"));
                        }
                        else
                        {
                            pictureBoxes[zähler].Load(System.IO.Path.GetFullPath("graphics\\bullet_full.png"));
                        }
                        break;
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                        if (badGuy.health < zähler - 11)
                        {
                            pictureBoxes[zähler].Image = new Bitmap(System.IO.Path.GetFullPath("graphics\\health_empty.png"));
                        }
                        else
                        {
                            pictureBoxes[zähler].Load(System.IO.Path.GetFullPath("graphics\\health_full.png"));
                        }
                        break;
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                        if (badGuy.bullets < zähler - 17)
                        {
                            pictureBoxes[zähler].Image = new Bitmap(System.IO.Path.GetFullPath("graphics\\bullet_empty.png"));
                        }
                        else
                        {
                            pictureBoxes[zähler].Load(System.IO.Path.GetFullPath("graphics\\bullet_full.png"));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        //Tasteneingaben lesen
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Spieler 1
            if (goodGuy.currentAction == 0)
            {
                switch (e.KeyCode)
                {
                    case (Keys.D1):
                        goodGuy.currentAction = 1;
                        break;
                    case (Keys.D2):
                        goodGuy.currentAction = 2;
                        break;
                    case (Keys.D3):
                        goodGuy.currentAction = 3;
                        break;
                    case (Keys.D4):
                        goodGuy.currentAction = 4;
                        break;
                    default:
                        break;
                }
            }

            // Spieler 2
            if (badGuy.currentAction == 0)
            {
                switch (e.KeyCode)
                {
                    case (Keys.NumPad1):
                        badGuy.currentAction = 1;
                        break;
                    case (Keys.NumPad2):
                        badGuy.currentAction = 2;
                        break;
                    case (Keys.NumPad3):
                        badGuy.currentAction = 3;
                        break;
                    case (Keys.NumPad4):
                        badGuy.currentAction = 4;
                        break;
                    default:
                        break;
                }
            }

            if (goodGuy.currentAction > 0 && badGuy.currentAction > 0)
            {
                // Prüfen, ob die Cowboys noch Munition haben 
                bool[] ableToShoot = { true, true };
                if (goodGuy.bullets == 0)
                {
                    ableToShoot[0] = false;
                }
                if (badGuy.bullets == 0)
                {
                    ableToShoot[1] = false;
                }
                // Kampf durchlaufen
                goodGuy.combat(badGuy, ableToShoot[1]);
                badGuy.combat(goodGuy, ableToShoot[0]);
                resolveCombat();
            }
        }

        // Bestimmen, ob das Spiel zu Ende ist
        void resolveCombat()
        {
            reloadUI();
            if (goodGuy.health == 0)
            {
                if (badGuy.health == 0)
                {
                    MessageBox.Show("wow you both suck");
                }
                else
                {
                    MessageBox.Show("the bad guy wins");
                }
                goodGuy.currentAction = -1;
                badGuy.currentAction = -1;
            }
            else if (badGuy.health == 0)
            {
                MessageBox.Show("the good guy wins");
                goodGuy.currentAction = -1;
                badGuy.currentAction = -1;
            }
            else
            {
                goodGuy.currentAction = 0;
                badGuy.currentAction = 0;
            }
        }
    }
}
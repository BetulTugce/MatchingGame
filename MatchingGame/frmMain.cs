using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class frmMain : Form
    {

        Image[] pokemon = {
            Properties.Resources.abra,
            Properties.Resources.articuno,
            Properties.Resources.bellsprout,
            Properties.Resources.bulbasaur,
            Properties.Resources.caterpie,
            Properties.Resources.charmander,
            Properties.Resources.charmander__2_,
            Properties.Resources.dratini,
            Properties.Resources.eevee,
            Properties.Resources.jigglypuff,
            Properties.Resources.mankey,
            Properties.Resources.meowth,
            Properties.Resources.mew,
            Properties.Resources.pidgey,
            Properties.Resources.pikachu,
            Properties.Resources.psyduck,
            Properties.Resources.rattata,
            Properties.Resources.snorlax,
            Properties.Resources.squirtle,
            Properties.Resources.venonat,
            Properties.Resources.weedle
        };

        int[] index = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19, 20, 20 };
        Button firstPokemon;
        int firstIndex, found, movement;

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            found = 0;
            movement = 0;
            tableLayoutPanel1.Enabled = true;
            for (var i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                var button = (Button)tableLayoutPanel1.Controls[i];
                button.Visible = true;
            }
            updateCards();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            updateCards();
        }

        private void updateCards()
        {
            Random rnd = new Random();

            for (int i = 0; i < 42; i++)
            {
                int number = rnd.Next(0, 21);
                int temp = index[i];
                index[i] = index[number];
                index[number] = temp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Enabled = false;
            int buttonNo = int.Parse(button.Name.Substring(6));
            int indexNo = index[buttonNo - 1];
            button.BackgroundImage = pokemon[indexNo];
            button.Refresh();

            if (firstPokemon == null)
            {
                firstPokemon = button;
                firstIndex = indexNo;
                movement++;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                firstPokemon.BackgroundImage = null;
                button.BackgroundImage = null;
                if (firstIndex == indexNo)
                {
                    found++;
                    firstPokemon.Visible = false;
                    button.Visible = false;

                    if (found == 21)
                    {
                        MessageBox.Show("Tebrikler! " + movement + " denemede bitirdiniz.");
                        tableLayoutPanel1.Enabled = false;
                    }
                }
                button.Enabled = true;
                firstPokemon.Enabled = true;
                firstPokemon = null;
            }
        }

        public frmMain()
        {
            InitializeComponent();
            updateCards();
        }
    }
}

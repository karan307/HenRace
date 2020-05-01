using System;
using System.Windows.Forms;

namespace HenRace
{
    public partial class Game : Form
    {
        HenSetup[] henArray = new HenSetup[4]; // creates one array of 4 hen objects 
        HenClients[] puntersArray = new HenClients[3]; // creates one array of 3 guy objects
        Random MyRandomNumbers = new Random();
        public Game()
        {
            InitializeComponent();
            settingTheRaceTrack();
        }

        private void Bets_Click(object sender, EventArgs e)
        {
            if (JaskaranRadioButton.Checked)
            {
                if (puntersArray[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    JaskaranBetLabel.Text = puntersArray[0].henBet.GetTheDescription();
                }
            }
            else if (samRadioButton.Checked)
            {
                if (puntersArray[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    samBetLabel.Text = puntersArray[1].henBet.GetTheDescription();
                }
            }
            else if (arunRadioButton.Checked)
            {
                if (puntersArray[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    arunBetLabel.Text = puntersArray[2].henBet.GetTheDescription();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Hen take starting position
            henArray[0].HenStartPosition();
            henArray[1].HenStartPosition();
            henArray[2].HenStartPosition();
            henArray[3].HenStartPosition();

            //disable race button till the end of the race
            bettingParlor.Enabled = false;

            //start timer
            timer1.Start();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (henArray[i].HenRun())
                {
                    timer1.Stop();
                    bettingParlor.Enabled = true;
                    i++;
                    MessageBox.Show("Hen " + i + " won the race");
                    for (int j = 0; j <= 2; j++)
                    {
                        puntersArray[j].Collect(i);
                        puntersArray[j].ClearTheBet();
                    }

                    foreach (HenSetup hen in henArray)
                    {
                        hen.HenStartPosition();
                    }
                    break;
                }
            }
        }
        private void settingTheRaceTrack()//this funtion is for setting the race track
        {
            JaskaranRadioButton.Checked = true;
            // initialize minimum bet label
            minimumBetLabel.Text = "Minimum Bet : " + numericUpDown1.Minimum.ToString() + " dollars";

            // initialize all 4 elements of the CarArray
            henArray[0] = new HenSetup()
            {
                MyPictureBox = hen1,
                HenStartingPosition = hen1.Left,
                TrackLength = henTrack.Width - hen1.Width,
                Randomizer = MyRandomNumbers
            };

            henArray[1] = new HenSetup()
            {
                MyPictureBox = hen2,
                HenStartingPosition = hen2.Left,
                TrackLength = henTrack.Width - hen2.Width,
                Randomizer = MyRandomNumbers
            };

            henArray[2] = new HenSetup()
            {
                MyPictureBox = hen3,
                HenStartingPosition = hen3.Left,
                TrackLength = henTrack.Width - hen3.Width,
                Randomizer = MyRandomNumbers
            };

            henArray[3] = new HenSetup()
            {
                MyPictureBox = hen4,
                HenStartingPosition = hen4.Left,
                TrackLength = henTrack.Width - hen4.Width,
                Randomizer = MyRandomNumbers
            };

            //initialize all 3 elements of the GuysArray
            puntersArray[0] = new HenClients()
            {
                ClientName = "Jaskaran",
                henBet = null,
                Cashes = 50,
                MyRadioButton = JaskaranRadioButton,
                MyLabel = JaskaranBetLabel
            };

            puntersArray[1] = new HenClients()
            {
                ClientName = "Sam",
                henBet = null,
                Cashes = 50,
                MyRadioButton = samRadioButton,
                MyLabel = samBetLabel
            };

            puntersArray[2] = new HenClients()
            {
                ClientName = "Arun",
                henBet = null,
                Cashes = 50,
                MyRadioButton = arunRadioButton,
                MyLabel = arunBetLabel
            };

            for (int i = 0; i <= 2; i++)
            {
                puntersArray[i].UpdatingLabels();
                puntersArray[i].henBet = new HenBet();
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace HenRace
{
    public class HenSetup : HenAbstractClass //inherited abstract class
    {
        public int HenStartingPosition; // where my PictureBox Starts
        public int TrackLength; //How long the racetrack is
        public PictureBox MyPictureBox = null; //My PictureBox object
        public Random Randomizer; //An integer random
        public int Loc = 0; //My Location on the track

        public override bool HenRun()//This is overridden by abstract class
        {
            Loc += Randomizer.Next(1, 25);
            MyPictureBox.Left = Loc;
            if (MyPictureBox.Left >= TrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void HenStartPosition()//This is overridden by abstract class
        {
            Loc = 0;
            MyPictureBox.Left = HenStartingPosition;
        }
    }
}

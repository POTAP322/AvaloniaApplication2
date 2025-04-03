using System;

namespace AvaloniaApplication2.Models
{
    public class Panther : Creature
    {
        public event EventHandler? SoundGiven;
        public event EventHandler? TreeClimbed;
        public event EventHandler? GetDownFromTree;

        public Panther(int speedStep, int maxSpeed) : base(speedStep, maxSpeed) { }

        public override void Move()
        {
            if (Speed < MaxSpeed)
            {
                Speed += SpeedStep;
            }
        }

        public override void Stand()
        {
            if (Speed > 0)
            {
                Speed -= SpeedStep;
            }
        }

        public void MakeSound()
        {
            SoundGiven?.Invoke(this, EventArgs.Empty);
        }

        public void ClimbTree()
        {
            TreeClimbed?.Invoke(this, EventArgs.Empty);
        }

        public void GetDown()
        {
            GetDownFromTree?.Invoke(this, EventArgs.Empty);
        }
    }
}

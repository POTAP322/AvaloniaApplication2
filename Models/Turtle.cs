namespace AvaloniaApplication2.Models
{
    public class Turtle : Creature
    {
        public Turtle(int maxSpeed, int speedStep) : base(speedStep, maxSpeed) { }

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
    }
}

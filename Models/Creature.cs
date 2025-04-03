namespace AvaloniaApplication2.Models;

public abstract class Creature{
    private int _speed;
    private int _speedStep;
    private int _maxSpeed;
    public int Speed{
        get => _speed;
        protected set => _speed = value < 0 ? 0 : value;
    }
    public int SpeedStep{get;protected set;}
    public int MaxSpeed{get;protected set;}

    protected Creature(int speedStep, int maxSpeed){
        this.SpeedStep = speedStep;
        this.MaxSpeed = maxSpeed;
        this.Speed = 0;
    }

    public abstract void Move();
    public abstract void Stand();

}

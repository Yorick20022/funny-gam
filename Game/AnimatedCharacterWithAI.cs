using SFML.System;

namespace Game;

public class AnimatedCharacterWithAI : AnimatedCharacter
{
    public List<Waypoint> Waypoints { get; set; }
    private int nextWaypointIndex = 1;
    Clock AiClock = new Clock();

    public AnimatedCharacterWithAI(string filename, int frameSize) : base(filename, frameSize)
    {
        AiClock = new Clock();
    }

    public override void Update(float deltaTime)
    {
        followWayPoints();
        base.Update(deltaTime);
    }

    private void followWayPoints()
    {
        if (AiClock.ElapsedTime.AsSeconds() > 0.5f)
        {
            if (Waypoints != null)
            {
                Waypoint nextWaypoint = Waypoints[nextWaypointIndex];

                float xDifference = nextWaypoint.Xpos - this.Xpos;
                float yDifference = nextWaypoint.Ypos - this.Ypos;
                float absXDifference = Math.Abs(xDifference);
                float absYDifference = Math.Abs(yDifference);

                if (absXDifference < 10 && absXDifference < 10)
                {
                    if (nextWaypoint.Xpos < Waypoints.Count - 1)
                    {
                        nextWaypointIndex++;
                    }
                    else
                    {
                        nextWaypointIndex = 0;
                    }
                }

                if (absXDifference > absYDifference)
                {
                    if (xDifference > 0)
                    {
                        this.CurrentState = CharacterState.MovingRight;
                    }

                    if (xDifference < 0)
                    {
                        this.CurrentState = CharacterState.MovingLeft;
                    }
                }
                else
                {
                    if (yDifference > 0)
                    {
                        this.CurrentState = CharacterState.MovingDown;
                    }
                    else
                    {
                        if (yDifference < 0)
                        {
                            this.CurrentState = CharacterState.MovingUp;
                        }
                    }
                }
            }
            AiClock.Restart();
        }
    }
}
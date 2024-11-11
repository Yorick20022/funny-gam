namespace Game;

public class Chicken : AnimatedCharacterWithAI
{
    public Chicken() : base("Sprites/chicken_walk.png", 32)
    {
        Anim_Up = new Animation(0, 0, 4);
        Anim_Left = new Animation(32, 0, 4);
        Anim_Down = new Animation(64, 0, 4);
        Anim_Right = new Animation(96, 0, 4);
    }
}
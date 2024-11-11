using SFML.Window;

namespace Game;
    public class Player : AnimatedCharacter
    {
        public Player() : base("Sprites/male_01.png", 64)
        {
            Anim_Up = new Animation(512, 0, 9);
            Anim_Left = new Animation(578, 0, 9);
            Anim_Down = new Animation(640, 0, 9);
            Anim_Right = new Animation(704, 0, 9);

            moveSpeed = 150;
            animationSpeed = 0.05f;
        }

        public override void Update(float deltaTime)
        {
            this.CurrentState = CharacterState.None;

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                this.CurrentState = CharacterState.MovingUp;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                this.CurrentState = CharacterState.MovingLeft;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                this.CurrentState = CharacterState.MovingDown;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                this.CurrentState = CharacterState.MovingRight;
            }
            base.Update(deltaTime);
        }
    }   


using System.Numerics;
using Raylib_cs;
using RayWrapper;
using RayWrapper.Vars;

namespace SpaceInvaders
{
    public class Player : GameObject
    {
        public override Vector2 Position
        {
            get => _pos;
            set
            {
                _pos = value;
                rect = rect.MoveTo(value);
            }
        }

        public override Vector2 Size => rect.Size();

        public int speed = 1;
        public Rectangle rect;

        private long _lastUpdate;
        private Vector2 _pos;

        public Player(Vector2 pos)
        {
            rect = RectWrapper.AssembleRectFromVec(_pos = pos, new Vector2(50, 100));
            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void UpdateCall()
        {
            var realSpeed = speed * (GameBox.GetTimeMs() - _lastUpdate);
            
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) Position -= new Vector2(realSpeed, 0);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) Position += new Vector2(realSpeed, 0);

            if (Position.X < 0) Position = new Vector2(0, 600);
            if (Position.X > 1230) Position = new Vector2(1230, 600);
            
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) Program.projectiles.Add(new Projectile(_pos + new Vector2(20, 0)));
            
            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void RenderCall() => rect.Draw(Color.BLUE);
    }
}
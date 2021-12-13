using System.Numerics;
using Raylib_cs;
using RayWrapper;
using RayWrapper.Vars;

namespace SpaceInvaders
{
    public class Projectile : GameObject
    {
        public override Vector2 Position
        {
            get => _pos;
            set => rect = rect.MoveTo(_pos = value);
        }

        public override Vector2 Size => rect.Size();

        public int speed = 1;
        public Rectangle rect;

        private long _lastUpdate;
        private Vector2 _pos;

        public Projectile(Vector2 pos)
        {
            rect = RectWrapper.AssembleRectFromVec(_pos = pos, new Vector2(10, 20));
            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void UpdateCall()
        {
            var realSpeed = speed * (GameBox.GetTimeMs() - _lastUpdate);
            Position -= new Vector2(0, realSpeed);
            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void RenderCall() => rect.Draw(Color.GOLD);
    }
}
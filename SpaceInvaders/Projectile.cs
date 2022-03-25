using System.Numerics;
using Raylib_CsLo;
using RayWrapper;
using RayWrapper.Vars;
using static Raylib_CsLo.Raylib;

namespace SpaceInvaders
{
    public class Projectile : GhostObject
    {
        public int speed = 1;
        public Rectangle rect;

        private long _lastUpdate;

        public Projectile(Vector2 pos)
        {
            rect = RectWrapper.AssembleRectFromVec(pos, new Vector2(10, 20));
            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void UpdateCall()
        {
            var realSpeed = speed * (GameBox.GetTimeMs() - _lastUpdate);
            rect.y -= realSpeed;
            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void RenderCall() => rect.Draw(GOLD);
    }
}
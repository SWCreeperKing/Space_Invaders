using System.Numerics;
using Raylib_cs;
using RayWrapper;
using RayWrapper.Vars;

namespace SpaceInvaders
{
    public class Invader : GhostObject
    {
        public float speed = .15f;
        public Rectangle rect;
        public bool turn;

        private long _lastUpdate;

        public Invader(Vector2 pos)
        {
            rect = RectWrapper.AssembleRectFromVec(pos, new Vector2(75, 20));
            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void UpdateCall()
        {
            var realSpeed = speed * (GameBox.GetTimeMs() - _lastUpdate) * (turn ? -1 : 1);
            rect.x += realSpeed;
            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void RenderCall() => rect.Draw(Color.RED);

        public int CheckTurn() =>
            rect.x switch
            {
                <= 0 => 1,
                >= 1205 => -1,
                _ => 0
            };

        public void Turn(bool toTurn) => rect.MoveBy(speed * ((turn = toTurn) ? 1 : 1), 15);
    }
}
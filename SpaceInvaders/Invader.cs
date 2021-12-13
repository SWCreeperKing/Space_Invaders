using System.Numerics;
using Raylib_cs;
using RayWrapper;
using RayWrapper.Vars;

namespace SpaceInvaders
{
    public class Invader : GameObject
    {
        public override Vector2 Position
        {
            get => _pos;
            set => rect = rect.MoveTo(_pos = value);
        }

        public override Vector2 Size => rect.Size();

        public float speed = .15f;
        public Rectangle rect;
        public bool turn;

        private long _lastUpdate;
        private Vector2 _pos;

        public Invader(Vector2 pos)
        {
            rect = RectWrapper.AssembleRectFromVec(_pos = pos, new Vector2(75, 20));
            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void UpdateCall()
        {
            var realSpeed = speed * (GameBox.GetTimeMs() - _lastUpdate) * (turn ? -1 : 1);
            Position += new Vector2(realSpeed, 0);
            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void RenderCall() => rect.Draw(Color.RED);

        public int CheckTurn() =>
            _pos.X switch
            {
                <= 0 => 1,
                >= 1205 => -1,
                _ => 0
            };

        public void Turn(bool toTurn) => Position += new Vector2(speed * ((turn = toTurn) ? 1 : 1), 15);
    }
}
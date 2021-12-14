﻿using System.Numerics;
using Raylib_cs;
using RayWrapper;
using RayWrapper.Vars;

namespace SpaceInvaders
{
    public class Player : GhostObject
    {
        public int speed = 1;
        public Rectangle rect;

        private long _lastUpdate;

        public Player(Vector2 pos)
        {
            rect = RectWrapper.AssembleRectFromVec(pos, new Vector2(50, 100));
            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void UpdateCall()
        {
            var realSpeed = speed * (GameBox.GetTimeMs() - _lastUpdate);

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) rect.x -= realSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) rect.x += realSpeed;

            if (rect.x < 0) rect.MoveTo(new Vector2(0, 600));
            if (rect.x > 1230) rect.MoveTo(new Vector2(1230, 600));

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                Program.projectiles.Add(new Projectile(new Vector2(rect.x + 20, rect.y)));

            _lastUpdate = GameBox.GetTimeMs();
        }

        protected override void RenderCall() => rect.Draw(Color.BLUE);
    }
}
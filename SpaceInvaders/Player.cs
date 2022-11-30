using System.Numerics;
using Raylib_CsLo;
using RayWrapper.Base.GameObject;
using static Raylib_CsLo.Raylib;
using Rectangle = RayWrapper.Base.Primitives.Rectangle;

namespace SpaceInvaders;

public class Player : GameObject
{
    public int speed = 200;
    public Rectangle rect;

    public Player(Vector2 pos)
    {
        rect = new Rectangle(pos, new Vector2(50, 100));
    }

    protected override void UpdateCall(float dt)
    {
        var realSpeed = speed * dt;

        if (IsKeyDown(KeyboardKey.KEY_A)) rect.X -= realSpeed;
        if (IsKeyDown(KeyboardKey.KEY_D)) rect.X += realSpeed;

        if (rect.X < 0) rect.X = 600;
        if (rect.X > 1230) rect.Pos = new Vector2(1230, 600);

        if (IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            Program.projectiles.Add(new Projectile(new Vector2(rect.X + 20, rect.Y)));
        }
    }

    protected override void RenderCall() => rect.Draw(BLUE);
}
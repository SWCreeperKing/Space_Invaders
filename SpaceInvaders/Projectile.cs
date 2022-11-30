using System.Numerics;
using RayWrapper.Base.GameObject;
using static Raylib_CsLo.Raylib;
using Rectangle = RayWrapper.Base.Primitives.Rectangle;

namespace SpaceInvaders;

public class Projectile : GameObject
{
    public int speed = 400;
    public Rectangle rect;

    public Projectile(Vector2 pos) => rect = new Rectangle(pos, new Vector2(10, 20));
    protected override void UpdateCall(float dt) => rect.Y -= speed * dt;
    protected override void RenderCall() => rect.Draw(GOLD);
}
using System.Numerics;
using RayWrapper.Base.GameObject;
using static Raylib_CsLo.Raylib;
using Rectangle = RayWrapper.Base.Primitives.Rectangle;

namespace SpaceInvaders;

public class Invader : GameObject
{
    public float speed = 150f;
    public Rectangle rect;
    public bool turn;

    public Invader(Vector2 pos)
    {
        rect = new Rectangle(pos, new Vector2(75, 20));
    }

    protected override void UpdateCall(float dt) => rect.X += speed * dt * (turn ? -1 : 1);
    protected override void RenderCall() => rect.Draw(RED);

    public int CheckTurn()
    {
        return rect.X switch
        {
            <= 0 => 1,
            >= 1205 => -1,
            _ => 0
        };
    }

    public void Turn(bool toTurn, float dt)
    {
        turn = toTurn;
        rect.Pos += new Vector2(speed * dt * (turn ? -1 : 1), 15);
    }
}
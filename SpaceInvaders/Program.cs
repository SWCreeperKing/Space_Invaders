﻿using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Raylib_CsLo;
using RayWrapper.Base.GameBox;
using SpaceInvaders;

new GameBox(new Program(), new Vector2(1280, 720), "Space Invaders");

public partial class Program : GameLoop
{
    public static List<Projectile> projectiles = new();
    public static List<Invader> invaders = new();
    public Player player;

    public override void Init()
    {
        player = new Player(new Vector2(590, 600));
        RegisterGameObj(player);
        Spawn();
    }

    public override void UpdateLoop(float dt)
    {
        List<Projectile> remove = new();
        List<Invader> ded = new();
        foreach (var inv in invaders) inv.Update(dt);
        foreach (var r in ded) invaders.Remove(r);

        var turns = invaders.Select(inv => inv.CheckTurn()).Where(i => i != 0).ToList();
        if (turns.Any())
        {
            var turn = turns.Any(i => i != 1);
            foreach (var inv in invaders) inv.Turn(turn, dt);
        }

        foreach (var proj in projectiles)
        {
            proj.Update(dt);
            if (proj.rect.Y <= -20)
            {
                remove.Add(proj);
                continue;
            }

            var inv = invaders.Where(invader => Raylib.CheckCollisionRecs(proj.rect, invader.rect));
            if (!inv.Any()) continue;
            remove.Add(proj);
            invaders.Remove(inv.First());
        }

        foreach (var r in remove) projectiles.Remove(r);

        if (!invaders.Any()) Spawn();
    }

    public override void RenderLoop()
    {
        foreach (var inv in invaders) inv.Render();
        foreach (var proj in projectiles) proj.Render();
    }

    public static void Spawn()
    {
        for (var x = 0; x < 8; x++)
        for (var y = 0; y < 5; y++)
            invaders.Add(new Invader(new Vector2(20 + x * 75 + x * 10, 20 + y * 20 + y * 10)));
    }
}
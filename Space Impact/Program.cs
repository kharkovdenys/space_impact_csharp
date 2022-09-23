using System;
using System.Collections.Generic;
using System.Threading;

int score = 0, health = 3, superShots = 3, cooldownProjectile = 0, cooldownEnemy = 60, cooldownSpeedEnemy = 3, cooldownProjectileEnemy = 0;
bool fire = false, superFire = false, restart = false, skip;
if (OperatingSystem.IsWindows())
{
    Console.WindowHeight = Console.BufferHeight = 30;
    Console.WindowWidth = Console.BufferWidth = 120;
}
Vector2 player;
player = new(4, 13);
Random random = new();
Print.Player(player);
List<Vector2> projectiles = new();
List<Vector2> projectilesEnemy = new();
List<Vector2> superProjectiles = new();
List<Vector2> enemys1 = new();
List<Vector2> enemys2 = new();
List<Vector2> bonus = new();
List<int> bonusType = new();
while (true)
{
    Console.Clear();
    Print.Player(player);
    for (int i = 0; i < enemys2.Count; i++)
    {
        Print.Enemy(enemys2[i], ConsoleColor.Magenta);
        if (enemys2[i].x + 1 <= 0)
            enemys2.RemoveAt(i);
        else
        {
            if (cooldownSpeedEnemy == 0)
            {
                enemys2[i] = new(enemys2[i], -1, 0);
            }
            if (cooldownProjectileEnemy == 0 && player.x <= enemys2[i].x)
                projectilesEnemy.Add(new(enemys2[i], -1, 0));
            if (Colision.EnemyPlayer(enemys2[i], player))
            {
                enemys2.RemoveAt(i);
                health--;
                if (health <= 0)
                {
                    Print.GameOver(score);
                    player = new(4, 13);
                    score = 0; health = 3; superShots = 3; cooldownProjectile = 0; cooldownEnemy = 60; cooldownSpeedEnemy = 3; cooldownProjectileEnemy = 0;
                    fire = false; superFire = false;
                    projectiles.Clear();
                    projectilesEnemy.Clear();
                    superProjectiles.Clear();
                    enemys1.Clear();
                    enemys2.Clear();
                    bonus.Clear();
                    bonusType.Clear();
                }
            }
        }
    }
    if (cooldownProjectileEnemy == 0 && projectilesEnemy.Count > 0)
        cooldownProjectileEnemy = 45;
    for (int i = 0; i < bonus.Count; i++)
    {
        Print.Bonus(bonus[i], bonusType[i]);
        if (bonus[i].x + 1 <= 0)
        {
            bonus.RemoveAt(i);
            bonusType.RemoveAt(i);
        }
        else
        {
            if (cooldownSpeedEnemy == 0)
            {
                bonus[i] = new(bonus[i], -1, 0);
            }
            if (Colision.ObjectPlayer(bonus[i], player))
            {
                if (bonusType[i] == 1 && health < 3)
                    health++;
                else
                if (bonusType[i] == 2 && superShots < 10)
                    superShots++;
                bonus.RemoveAt(i);
                bonusType.RemoveAt(i);

            }
        }
    }
    for (int i = 0; i < enemys1.Count; i++)
    {
        Print.Enemy(enemys1[i], ConsoleColor.Red);
        if (enemys1[i].x + 1 <= 0)
            enemys1.RemoveAt(i);
        else
        {
            if (cooldownSpeedEnemy == 0)
            {
                enemys1[i] = new(enemys1[i], -1, 0);
            }
            if (Colision.EnemyPlayer(enemys1[i], player))
            {
                enemys1.RemoveAt(i);
                health--;
                if (health <= 0)
                {
                    Print.GameOver(score);
                    player = new(4, 13);
                    score = 0; health = 3; superShots = 3; cooldownProjectile = 0; cooldownEnemy = 60; cooldownSpeedEnemy = 3; cooldownProjectileEnemy = 0;
                    fire = false; superFire = false;
                    projectiles.Clear();
                    projectilesEnemy.Clear();
                    superProjectiles.Clear();
                    enemys1.Clear();
                    enemys2.Clear();
                    bonus.Clear();
                    bonusType.Clear();
                }
            }
        }
    }
    for (int i = 0; i < projectilesEnemy.Count; i++)
    {
        if (projectilesEnemy[i].x == -1)
            projectilesEnemy.RemoveAt(i);
        else
        {
            Print.Projectile(projectilesEnemy[i], ConsoleColor.Magenta);
            projectilesEnemy[i] = new(projectilesEnemy[i], -1, 0);
            if (Colision.ObjectPlayer(projectilesEnemy[i], player))
            {
                projectilesEnemy.RemoveAt(i);
                health--;
                if (health <= 0)
                {
                    Print.GameOver(score);
                    player = new(4, 13);
                    score = 0; health = 3; superShots = 3; cooldownProjectile = 0; cooldownEnemy = 60; cooldownSpeedEnemy = 3; cooldownProjectileEnemy = 0;
                    fire = false; superFire = false;
                    projectiles.Clear();
                    projectilesEnemy.Clear();
                    superProjectiles.Clear();
                    enemys1.Clear();
                    enemys2.Clear();
                    bonus.Clear();
                    bonusType.Clear();
                }
            }
        }
    }
    for (int i = 0; i < projectiles.Count; i++)
    {
        Print.Projectile(projectiles[i], ConsoleColor.DarkGreen);
        if (projectiles[i].x + 1 >= 120)
            projectiles.RemoveAt(i);
        else
        {
            projectiles[i] = new(projectiles[i], 1, 0);
            skip = false;
            for (int j = 0; j < projectilesEnemy.Count; j++)
            {
                if (projectilesEnemy[j] == projectiles[i] || projectilesEnemy[j] == new Vector2(projectiles[i], -1, 0))
                {
                    projectiles.RemoveAt(i);
                    projectilesEnemy.RemoveAt(j);
                    skip = true;
                    break;
                }
            }
            if (skip)
                continue;
            for (int j = 0; j < enemys1.Count; j++)
            {
                if (Colision.ProjectileEnemy(projectiles[i], enemys1[j]))
                {

                    skip = true;
                    score += 10;
                    int randomNum = random.Next(20);
                    if (randomNum == 4)
                    {
                        bonus.Add(enemys1[j]);
                        bonusType.Add(1);
                    }
                    if (randomNum == 6)
                    {
                        bonus.Add(enemys1[j]);
                        bonusType.Add(2);
                    }
                    projectiles.RemoveAt(i);
                    enemys1.RemoveAt(j);
                    break;
                }
            }
            if (skip)
                continue;
            for (int j = 0; j < enemys2.Count; j++)
            {
                if (Colision.ProjectileEnemy(projectiles[i], enemys2[j]))
                {
                    int randomNum = random.Next(20);
                    if (randomNum == 4)
                    {
                        bonus.Add(enemys2[j]);
                        bonusType.Add(1);
                    }
                    if (randomNum == 6)
                    {
                        bonus.Add(enemys2[j]);
                        bonusType.Add(2);
                    }
                    projectiles.RemoveAt(i);
                    enemys2.RemoveAt(j);
                    score += 20;
                    break;
                }
            }
        }
    }
    for (int i = 0; i < superProjectiles.Count; i++)
    {
        Print.SuperProjectile(superProjectiles[i]);
        if (superProjectiles[i].x + 1 >= 120)
            superProjectiles.RemoveAt(i);
        else
        {
            superProjectiles[i] = new(superProjectiles[i], 1, 0);
            skip = false;
            for (int j = 0; j < projectilesEnemy.Count; j++)
            {
                if (projectilesEnemy[j] == superProjectiles[i] || projectilesEnemy[j] == new Vector2(superProjectiles[i], -1, 0))
                {
                    projectilesEnemy.RemoveAt(j);
                    break;
                }
            }
            if (skip)
                continue;
            for (int j = 0; j < enemys1.Count; j++)
            {
                if (Colision.ProjectileEnemy(superProjectiles[i], enemys1[j]))
                {
                    int randomNum = random.Next(20);
                    if (randomNum == 4)
                    {
                        bonus.Add(enemys1[j]);
                        bonusType.Add(1);
                    }
                    if (randomNum == 6)
                    {
                        bonus.Add(enemys1[j]);
                        bonusType.Add(2);
                    }
                    enemys1.RemoveAt(j);
                    skip = true;
                    score += 10;
                    break;
                }
            }
            if (skip)
                continue;
            for (int j = 0; j < enemys2.Count; j++)
            {
                if (Colision.ProjectileEnemy(superProjectiles[i], enemys2[j]))
                {
                    int randomNum = random.Next(20);
                    if (randomNum == 4)
                    {
                        bonus.Add(enemys2[j]);
                        bonusType.Add(1);
                    }
                    if (randomNum == 6)
                    {
                        bonus.Add(enemys2[j]);
                        bonusType.Add(2);
                    }
                    enemys2.RemoveAt(j);
                    score += 20;
                    break;
                }
            }
        }
    }
    if (cooldownSpeedEnemy == 0 && enemys1.Count + enemys2.Count > 0)
        cooldownSpeedEnemy = 3;
    if (cooldownProjectile > 0)
        cooldownProjectile--;
    if (cooldownEnemy > 0)
        cooldownEnemy--;
    if (cooldownSpeedEnemy > 0)
        cooldownSpeedEnemy--;
    if (cooldownProjectileEnemy > 0)
        cooldownProjectileEnemy--;
    Print.Info("   Health: " + health, "Super Shots:" + superShots + "/10   Score: " + score + "  ");
    while (Console.KeyAvailable)
    {
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (pressedKey.Key == ConsoleKey.A)
        {
            if (player.x - 2 >= 0)
            {
                player = new(player, -1, 0);
            }
        }
        else
        if (pressedKey.Key == ConsoleKey.D)
        {
            if (player.x + 2 < 120)
            {
                player = new(player, 1, 0);
            }
        }
        else
        if (pressedKey.Key == ConsoleKey.S)
        {
            if (player.y + 2 < 30)
            {
                player = new(player, 0, 1);
            }
        }
        else
        if (pressedKey.Key == ConsoleKey.W)
        {
            if (player.y - 2 >= 1)
            {
                player = new(player, 0, -1);
            }
        }
        else
        if (superShots > 0 && !superFire && pressedKey.Key == ConsoleKey.Tab)
        {
            superFire = true;
        }
        else
        if (!fire && pressedKey.Key == ConsoleKey.Spacebar)
        {
            fire = true;
        }
        else
        if (pressedKey.Key == ConsoleKey.Escape)
        {
            Print.Pause(ref restart);
            if (restart)
            {
                restart = false;
                player = new(4, 13);
                score = 0; health = 3; superShots = 3; cooldownProjectile = 0; cooldownEnemy = 60; cooldownSpeedEnemy = 3; cooldownProjectileEnemy = 0;
                fire = false; superFire = false;
                projectiles.Clear();
                projectilesEnemy.Clear();
                superProjectiles.Clear();
                enemys1.Clear();
                enemys2.Clear();
                bonus.Clear();
                bonusType.Clear();
            }
        }

    }
    if (fire && cooldownProjectile == 0)
    {
        projectiles.Add(new(player, 2, 0));
        fire = false;
        cooldownProjectile = 10;
    }
    if (superFire && cooldownProjectile == 0)
    {
        superShots--;
        superProjectiles.Add(new(player, 2, 0));
        superFire = false;
        cooldownProjectile = 10;
    }
    if (cooldownEnemy == 0)
    {
        cooldownEnemy = 60;
        if (random.Next(2) == 0)
        {
            enemys1.Add(new(121, random.Next(27) + 2));
        }
        else
        {
            enemys2.Add(new(121, random.Next(27) + 2));
        }
    }
    Thread.Sleep(16);
}
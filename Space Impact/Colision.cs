using System;

class Colision
{
    public static bool ProjectileEnemy(in Vector2 v1, in Vector2 v2)
    {
        if (Math.Abs(v2.y - v1.y) > 1)
            return false;
        if (Math.Abs(v2.x - v1.x) > 2)
            return false;
        if (v2.y == v1.y)
            return true;
        if (v2.x == v1.x || v2.x + 1 == v1.x)
            return true;
        return false;
    }
    public static bool ObjectPlayer(in Vector2 v1, in Vector2 v2)
    {
        if (Math.Abs(v2.y - v1.y) > 1)
            return false;
        if (Math.Abs(v2.x - v1.x) > 2)
            return false;
        if (v2.y == v1.y)
            return true;
        if (v2.x == v1.x || v2.x - 1 == v1.x)
            return true;
        return false;
    }
    public static bool EnemyPlayer(in Vector2 v1, in Vector2 v2)
    {
        if (Math.Abs(v2.y - v1.y) > 2)
            return false;
        if (Math.Abs(v2.x - v1.x) > 3)
            return false;
        if (v2.y == v1.y)
            return true;
        if (v2.x == v1.x || v2.x - 1 == v1.x)
            return true;
        return false;
    }
}
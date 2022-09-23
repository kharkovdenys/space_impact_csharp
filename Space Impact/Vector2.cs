using System;

struct Vector2
{
    public int x;
    public int y;
    public Vector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public Vector2(Vector2 vector, int dx, int dy)
    {
        x = vector.x + dx;
        y = vector.y + dy;
    }
    public static bool operator ==(Vector2 v1, Vector2 v2)
    {
        return v1.Equals(v2);
    }
    public static bool operator !=(Vector2 v1, Vector2 v2)
    {
        return !v1.Equals(v2);
    }
    public override bool Equals(Object obj)
    {
        Vector2 v2 = (Vector2)obj;
        if (x == v2.x && y == v2.y)
        {
            return true;
        }
        else
            return false;
    }
    public override int GetHashCode()
    {
        return (x << 2) ^ y;
    }
}

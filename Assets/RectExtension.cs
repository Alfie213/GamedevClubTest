using UnityEngine;

public static class RectExtension
{
    public static Vector2 RandomPoint(this Rect rect)
    {
        float x = Random.Range(rect.xMin, rect.xMax);
        float y = Random.Range(rect.yMin, rect.yMax);
        Vector2 randomPoint = new Vector2(x, y);
        return randomPoint;
    }
}

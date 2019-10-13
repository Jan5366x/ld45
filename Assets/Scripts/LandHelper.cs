using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LandHelper : MonoBehaviour
{
    public static bool IsLand(Vector3 from, Vector3 target)
    {
        RaycastHit2D hit = Physics2D.Linecast(from, target, LayerMask.GetMask("Ground"));
        Debug.DrawLine(from, target, Color.red, 5);
        return !hit;
    }

    public static Vector3 ChooseLand(Vector3 basePosition, Rect range)
    {
        for (int i = 0; i < 100; i++)
        {
            float x = basePosition.x + Random.Range(range.xMin, range.xMax);
            float y = basePosition.y + Random.Range(range.yMin, range.yMax);

            if (IsLand(basePosition, new Vector3(x, y)))
            {
                return new Vector3(x, y);
            }
        }

        return basePosition;
    }
}
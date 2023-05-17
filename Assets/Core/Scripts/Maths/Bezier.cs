using System.Collections.Generic;
using UnityEngine;

public class Bezier
{
    public Vector2 GetPoint(List<Vector2> points, float time)
    {
        time = Mathf.Clamp01(time);
        int numPoints = points.Count;

        Vector2 point = Vector2.zero;
        for (int i = 0; i < numPoints; i++)
        {
            float coeff = BinomialCoefficient(numPoints - 1, i) * Mathf.Pow(1 - time, numPoints - 1 - i) *
                          Mathf.Pow(time, i);
            point += coeff * points[i];
        }

        return point;
    }

    private float BinomialCoefficient(int n, int k)
    {
        float result = 1f;
        for (int i = 1; i <= k; i++)
        {
            result *= (float) (n - k + i) / i;
        }

        return result;
    }
}
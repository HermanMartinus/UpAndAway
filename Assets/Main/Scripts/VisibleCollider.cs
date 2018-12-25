using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[ExecuteInEditMode]
public class VisibleCollider : MonoBehaviour
{

    BoxCollider2D b;
    [SerializeField] bool alwaysShowCollider = true;


    void OnDrawGizmos()
    {
        if (alwaysShowCollider)
        {
            b = GetComponent<BoxCollider2D>();

            List<Vector2> points = new List<Vector2>();
            points.Add(b.offset + new Vector2(b.size.x/2-1f, -b.size.y/2));
            points.Add(b.offset + new Vector2(-b.size.x/2, -b.size.y/2));
            points.Add(b.offset + new Vector2(-b.size.x/2-0, b.size.y/2));
            points.Add(b.offset + new Vector2(b.size.x/2-1f, b.size.y/2));
            points.Add(b.offset + new Vector2(b.size.x / 2, 0));

            Gizmos.color = Color.green;

            // for every point (except for the last one), draw line to the next point
            for (int i = 0; i < points.Count - 1; i++)
            {
                GizmosUtil.DrawLocalLine(transform, (Vector3)points[i], (Vector3)points[i + 1]);
            }
            // for polygons, close with the last segment
            GizmosUtil.DrawLocalLine(transform, (Vector3)points[points.Count - 1], (Vector3)points[0]);
        }
    }

}

public static class GizmosUtil
{

    /// <summary>
    /// Draw a line with local coordinates, with current gizmos parameters
    /// </summary>
    /// <param name="p1">Local 1st coordinates of the line.</param>
    /// <param name="p2">Local 2nt coordinates of the line.</param>
    public static void DrawLocalLine(Transform tr, Vector3 p1, Vector3 p2)
    {
        Gizmos.DrawLine(tr.TransformPoint(p1), tr.TransformPoint(p2));
    }

}
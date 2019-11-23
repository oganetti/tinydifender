using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void DrawTrajectoryPoints(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[10];
        lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.2f;
            points[i] = origin + speed * time + Physics.gravity * time * time / 2;

            if (points[i].y < 0)
            {
                break;

            }


        }

        lineRenderer.SetPositions(points);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int segments = 10;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Draw(Vector3 a, Vector3 b, float length)
    {
        lineRenderer.enabled = true;

        float interpolant = Vector3.Distance(a, b) / length;
        float offset = Mathf.Lerp(length / 2f, 0, interpolant);
        Vector3 aDown = a + Vector3.down * offset;
        Vector3 bDown = b + Vector3.down * offset;

        lineRenderer.positionCount = segments + 1;
        for (int i = 0; i < segments + 1; i++) {

            lineRenderer.SetPosition(i, Bezier.GetPoint(a, aDown, bDown, b, (float)i/length));
        }
    }

    public void Hide()
    {
        lineRenderer.enabled = false;
    }
}

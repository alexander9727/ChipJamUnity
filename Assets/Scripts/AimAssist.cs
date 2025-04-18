using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssist : MonoBehaviour
{
    [SerializeField]
    float InitialVelocity, MaximumTime = 10;
    [SerializeField]
    bool UseGravity;
    [SerializeField, Tooltip("Only used if UseGravity is true")]
    int Segments = 10;
    LineRenderer Line;
    List<Vector3> Points = new List<Vector3>();
    [SerializeField]
    LayerMask layers;
    public static AimAssist Instance;
    public void SetInitialVelocity(float velo)
    {
        InitialVelocity = velo;
    }

    void Awake()
    {
        Instance = this;
        Line = GetComponent<LineRenderer>();
        Line.useWorldSpace = true;
    }

    void Update()
    {
        Points.Clear();
        if (UseGravity)
        {
            CalculateCurvedPath();
        }
        else
        {
            CalculateStraighPath();
        }
        DrawPath();
    }

    private void DrawPath()
    {
        Line.positionCount = Points.Count;
        Line.SetPositions(Points.ToArray());
    }
    private void CalculateCurvedPath()
    {
        float timeStep = MaximumTime / Segments;
        Vector3 u = transform.up * InitialVelocity;
        Vector3 a = Physics.gravity;
        Vector3 prevPoint = transform.position, currentPoint, dir;

        Points.Add(transform.position);
        for (float t = timeStep; t <= MaximumTime; t += timeStep)
        {
            currentPoint = transform.position + ((u * t) + (0.5f * a * t * t));
            dir = (currentPoint - prevPoint).normalized;
            RaycastHit2D hit = Physics2D.Raycast(prevPoint, dir, Vector3.Distance(prevPoint, currentPoint), layers);
            if (hit.collider != null)
            {
                Points.Add(hit.point);
                return;
            }
            prevPoint = currentPoint;
            Points.Add(currentPoint);
        }
    }
    void CalculateStraighPath()
    {
        float dist = InitialVelocity * MaximumTime;
        Points.Add(transform.position);
        Vector3 point = transform.position + transform.forward * dist;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, dist))
        {
            point = hit.point;
        }
        Points.Add(point);
    }
}

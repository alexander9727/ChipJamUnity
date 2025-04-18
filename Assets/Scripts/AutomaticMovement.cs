using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    public Vector3[] Points;
    public float MoveSpeed;
    public float StopDuration;
    int CurrentPosition;
    Vector3 Destination;
    float Timer;
    void Start()
    {
        Timer = StopDuration;
        CurrentPosition = 0;
        transform.position = Points[CurrentPosition];
        Destination = GetNextPosition();
    }
    void Update()
    {
        if (Timer < StopDuration)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, Destination, MoveSpeed * Time.deltaTime);
            transform.position = newPosition;
            if (Vector3.Distance(Destination, newPosition) == 0)
            {
                Destination = GetNextPosition();
                Timer = 0;

            }
        }
    }
    private Vector3 GetNextPosition()
    {
        CurrentPosition++;
        if (CurrentPosition >= Points.Length)
        {
            CurrentPosition = 0;
        }
        return Points[CurrentPosition];
    }
}

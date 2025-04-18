using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticRotation : MonoBehaviour
{
    [SerializeField]
    float[] Angles = { 0f, 90f };
    [SerializeField]
    float RotateSpeed = 150;
    [SerializeField]
    float StopDuration = 1;
    int CurrentPosition;
    Quaternion CorrectAngle;
    float Timer;
    void Start()
    {
        Timer = StopDuration;
        CurrentPosition = 0;
        transform.rotation = Quaternion.Euler(0,0, Angles[CurrentPosition]);
        CorrectAngle = GetNextPosition();
    }
    void Update()
    {
        if (Timer < StopDuration)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, CorrectAngle, RotateSpeed * Time.deltaTime);
            transform.rotation = newRotation;
            if (Quaternion.Angle(CorrectAngle, newRotation) == 0)
            {
                CorrectAngle = GetNextPosition();
                Timer = 0;

            }
        }
    }

    private Quaternion GetNextPosition()
    {
        CurrentPosition++;
        if (CurrentPosition >= Angles.Length)
        {
            CurrentPosition = 0;
        }
        return Quaternion.Euler(0,0,Angles[CurrentPosition]);
    }
}

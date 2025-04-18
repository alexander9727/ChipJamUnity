using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float MoveSpeed = 2;
    float LerpTime;
    public static CameraMovement Instance;


    Vector3 StartPoint, EndPoint;
    private void Start()
    {
        Instance = this;
        LerpTime = 1;
        StartPoint = EndPoint = transform.position;
    }

    private void Update()
    {
        LerpTime += Time.deltaTime * MoveSpeed;
        transform.position = Vector3.Lerp(StartPoint, EndPoint, LerpTime);
        //transform.position = Vector3.MoveTowards(transform.position, EndPoint, MoveSpeed * Time.deltaTime);
    }

    public void MoveCamera(float newX)
    {
        StartPoint = EndPoint = transform.position;
        EndPoint.x = newX;
        LerpTime = 0;
    }
}

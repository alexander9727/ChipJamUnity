using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotationScript : MonoBehaviour
{
    [SerializeField]
    float Speed;

    void Update()
    {
        transform.Rotate(Vector3.forward * Speed * Time.deltaTime);        
    }
}

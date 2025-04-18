using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectMovement : MonoBehaviour
{
    Vector3 Direction;
    float Speed;
    void Start()
    {
        Direction = Camera.main.transform.position - transform.position;
        Direction.z = 0;
        Direction += new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        Direction.Normalize();
        Speed = Random.Range(1f, 5f);
        transform.localScale = Random.Range(1f, 4f) * Vector3.one;
    }

    void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

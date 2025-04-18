using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject RandomObject;
    [SerializeField]
    float TimeBetweenSpawns;
    void Start()
    {
        InvokeRepeating("SpawnObject", 0, TimeBetweenSpawns);
    }

    void SpawnObject()
    {
        GameObject g = Instantiate(RandomObject,  transform) as GameObject;
        g.transform.localPosition = GetRandomPosition();
        g.transform.parent = null;
    }


    Vector3 GetRandomPosition()
    {
        Vector3 pos = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f));

        if(pos.magnitude < Camera.main.orthographicSize)
        {
            return GetRandomPosition();
        }

        return pos;
    }
}

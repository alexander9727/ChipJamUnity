using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    [SerializeField]
    Vector2 ForceToAdd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().AddForce(ForceToAdd);
    }
}

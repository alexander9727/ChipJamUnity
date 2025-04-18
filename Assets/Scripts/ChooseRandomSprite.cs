using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomSprite : MonoBehaviour
{
    [SerializeField]
    Sprite[] Choices;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Choices[Random.Range(0, Choices.Length)];
    }
}

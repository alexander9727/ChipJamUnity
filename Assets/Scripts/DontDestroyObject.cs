﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

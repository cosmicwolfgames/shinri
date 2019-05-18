﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        
        transform.Translate(translation, 0, 0);
    }
}

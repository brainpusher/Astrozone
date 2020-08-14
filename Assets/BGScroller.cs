﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float tileSizeZ;

    private Vector3 startPosition;

    private void Start () 
    {
        startPosition = transform.position;
    }

    private void Update ()
    {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}

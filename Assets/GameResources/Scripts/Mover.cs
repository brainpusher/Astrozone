using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private Rigidbody boltRigidbody;
    private void Start()
    {
        boltRigidbody.velocity = transform.forward * speed;
    }
}

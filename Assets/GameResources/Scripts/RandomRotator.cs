using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    [SerializeField] private float tumble;
    [SerializeField] private Rigidbody asteroidRigidbody;

    void Start ()
    {
        asteroidRigidbody.angularVelocity = Random.insideUnitSphere * tumble; 
    }
}

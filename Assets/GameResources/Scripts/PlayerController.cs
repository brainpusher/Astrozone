using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float tilt;
    [SerializeField] private Rigidbody playerShipRigidbody;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private MeshRenderer playerShipRenderer;
    [SerializeField] private Transform bulletSpawnTransform;
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private float fireRate;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private bl_Joystick joystick;
    [SerializeField] private bl_Joystick attackJoystick;

    private float nextFire;
    private Vector3 playerShipSize;
    private float rightBoundary;
    private float topBoundary;
    private int count = 0;
    private void Start()
    {
        playerShipSize = playerShipRenderer.bounds.size;
        rightBoundary = cameraController.CameraHalfWidth - playerShipSize.x / 2;
        topBoundary = cameraController.CameraHalfHeight - playerShipSize.z / 2;
    }

    private void Update ()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
#else
        if (attackJoystick.Horizontal != 0f  && Time.time > nextFire)
        {
#endif
            nextFire = Time.time + fireRate;
            shootSound.Play();
            objectPooler.SpawnFromPool("Bullet", bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        }
    }
    
    private void FixedUpdate()
    {
#if UNITY_EDITOR
        speed = 40f;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
#else
        float moveVertical = joystick.Vertical;
        float moveHorizontal = joystick.Horizontal;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * Time.deltaTime;
#endif
        
        playerShipRigidbody.velocity = movement * speed;

        playerShipRigidbody.MovePosition(
            new Vector3
            (
                Mathf.Clamp(playerShipRigidbody.position.x, -rightBoundary, rightBoundary),
                0.0f,
                Mathf.Clamp(playerShipRigidbody.position.z, -topBoundary, topBoundary)
            ));

       playerShipRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, playerShipRigidbody.velocity.x * -tilt);
    }
}
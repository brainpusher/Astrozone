using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera orthographicCamera;
    
    public float CameraHeight => (orthographicCamera != null) ? (2f * orthographicCamera.orthographicSize) : 0f;
    public float CameraWidth =>  (orthographicCamera != null) ? (2f * orthographicCamera.orthographicSize * orthographicCamera.aspect) : 0f;
    public float CameraHalfHeight =>  (orthographicCamera != null) ? orthographicCamera.orthographicSize : 0f;
    public float CameraHalfWidth => (orthographicCamera != null) ? orthographicCamera.orthographicSize * orthographicCamera.aspect : 0f;
}

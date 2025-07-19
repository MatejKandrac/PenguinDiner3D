using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform cameraAnchor;

    void Update()
    {
        transform.SetPositionAndRotation(cameraAnchor.position, cameraAnchor.rotation);
    }
}

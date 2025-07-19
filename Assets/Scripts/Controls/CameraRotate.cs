using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate : MonoBehaviour
{

    public float sensitivity;
    private float _xRotation = 0f;
    private Vector2 _lookInput;
    public Transform player;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse movement. Delta time fixes FPS issues
        var mouseX = _lookInput.x * Time.deltaTime * sensitivity;
        var mouseY = _lookInput.y * Time.deltaTime * sensitivity;

        // Apply movement for X
        transform.Rotate(Vector3.up * mouseX);

        // Apply movement for Y with clamp of 90 degrees
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }

    public void OnLook(InputAction.CallbackContext context) {
        _lookInput = context.ReadValue<Vector2>();
    }
}


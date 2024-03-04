using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controls : MonoBehaviour
{
    public float mouse_sensitivity = 100f;
    public float rotation_speed = 1.2f;

    public Transform player_body;

    float x_roation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouse_sensitivity * rotation_speed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouse_sensitivity * rotation_speed * Time.deltaTime;

        x_roation -= mouseY;
        x_roation = Mathf.Clamp(x_roation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(x_roation, 0f, 0f);
        player_body.Rotate(Vector3.up * mouseX);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -15f;

    public Transform ground_check;
    public float ground_distance = 0.4f;
    public LayerMask ground_mask;

    Vector3 velocity;
    bool is_grounded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        is_grounded = Physics.CheckSphere(ground_check.position, ground_distance, ground_mask);

        if (is_grounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

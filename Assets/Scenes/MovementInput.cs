using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    public CharacterController charController;
    public float speed = 10f;
    Vector3 Velocity;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float gravity = -9f;
    bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if(onGround && Velocity.y <= 0)
        {
            Velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        charController.Move(move * speed);

        Velocity.y += gravity * Time.deltaTime;
        charController.Move(Velocity * Time.deltaTime);
        
        if(Input.GetButton("Jump") && onGround)
        {
            Velocity.y = Mathf.Sqrt(1f * -2f * gravity);
            AudioSource jump = GetComponent<AudioSource>();
            jump.Play();
        }
    }
}

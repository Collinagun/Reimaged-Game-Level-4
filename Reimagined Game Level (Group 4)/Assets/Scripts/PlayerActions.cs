using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    // Variables
    Rigidbody rb;
    public float speed;
    public int jumpForce;
    bool jump = false;
    float inputX, inputY;
    bool isGrounded;

    // Could be used as reference for the bullets that come out of the shotgun
    // public float bulletSpeed;
    // bool shoot = false;
    // public GameObject bullet;
    // public Transform bulletPos;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


   
    void Start()
    {
        
    }

    
    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y); // Checks if the the player is grounded


    }

        private void FixedUpdate()
    {
        
        Move();

        if (jump) // if (jump == true)
        {
            Jump();
            jump = false;
        }

    }

    void Jump()
    {
        if (isGrounded){
        rb.AddForce(0, jumpForce, 0);
        }
    }

    void Move()
    {
        // Bounce();
        rb.velocity = new Vector3(inputX * speed, rb.velocity.y, inputY * speed);
    }

    // void Bounce()
    // {
        
    // }

  
}

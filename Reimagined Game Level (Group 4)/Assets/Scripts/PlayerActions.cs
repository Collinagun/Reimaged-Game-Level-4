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

    }

        private void FixedUpdate()
    {
        rb.velocity = new Vector3(inputX * speed, rb.velocity.y, inputY * speed);

        if (jump) // if (jump == true)
        {
            Jump();
            jump = false;
        }

    }

    void Jump()
    {
        rb.AddForce(0, jumpForce, 0);
    }

  
}

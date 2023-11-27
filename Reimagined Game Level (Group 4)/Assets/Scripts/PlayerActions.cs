using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    // Variables
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce = 0.0f;
    public PhysicsMaterial2D bounceMaterial, neutralMaterial;
    public bool jump = true;
    float inputX, inputY;
    public bool isGrounded;
    public LayerMask groundMask;

    // Could be used as reference for the bullets that come out of the shotgun
    // public float bulletSpeed;
    // bool shoot = false;
    // public GameObject bullet;
    // public Transform bulletPos;
    

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, -gameObject.transform.position.y),
        new Vector2(0.9f, 0.4f), 0f, groundMask); // Checks if the player is grounded

        // if (jumpForce > 0){
        //         rb.sharedmaterial = rb.bounceMaterial;
        //     }
        //     else {
        //         rb.sharedmaterial = rb.normalMaterial;
        //     }

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
        rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Move()
    {
        // Bounce();
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);
    }

    // void Bounce()
    // {
        
    // }

  
}

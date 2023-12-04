using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    // Variables
    private Rigidbody2D rb;
    public float speed;
    float dSpeed;
    public float forwardForce = 5.0f;
    public float jumpForce = 0.0f;
    public PhysicsMaterial2D bounceMaterial, normalMaterial;
    bool jump = false;
    float inputX, inputY;
    bool isGrounded;
    public LayerMask groundMask, wallMask;
    public bool bottom;
    // bool reflec = false;
    public bool reflect = false;
    float startTime = 3;

    [SerializeField] Bouncy bounce ;
    // reflect = bounce.canBounce;
    

    // Could be used as reference for the bullets that come out of the shotgun
    // public float bulletSpeed;
    // bool shoot = false;
    // public GameObject bullet;
    // public Transform bulletPos;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        dSpeed = speed / 3;
    }

    public void OnCollisionStay2D(Collision2D col){
        
        // if (col.gameObject.tag == "wall"){
        //     reflec = true;
        //     Debug.Log("walled");
        // }
        // else {
        //     reflec = false;
        // }

        // if (isGrounded == false && reflec == true){
        //     Debug.Log("Walled");
        //     while (isGrounded != true){
        //     Bouncy();
        //     }
        // }
        
    }
    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        
        reflect = bounce.canBounce;

        if (isGrounded){
            rb.sharedMaterial = normalMaterial;
        }
        else{
            rb.sharedMaterial = bounceMaterial;
        }
        if (isGrounded == true && jump == false) {
            Move();
        }
        // if (isGrounded == false && reflect == true){
        //     Debug.Log("Walled");
        //     while (isGrounded == false){
        //     Bouncing();
        //     }
        // }

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }

        
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
        new Vector2(0.9f, 0.4f), 0f, groundMask); // Checks if the player is grounded through an invisible collider that can help filter which gameobjects to collide with
        // isGrounded = Physics2D.Raycast(transform.position, -Vector2.up) && bottom == true; // Checks if the player is grounded
        
        // if (isGrounded){
        //     float remainTime = startTime;
        //     StartCoroutine(Writing());
        //     while (remainTime > 0){
        //         remainTime -= Time.deltaTime;
        //     }
        // }
    }

        private void FixedUpdate()
    {
        // if (isGrounded == true || reflec == false) {
        //     Move();
        // }

        if (jump) // if (jump == true)
        {
            Jump();
            jump = false;
        }

    }

    IEnumerator Writing()
    {
        float remainTime = startTime;
        
        while (remainTime > 0){
            remainTime -= Time.deltaTime;
            }
        Debug.Log("grounded");
        
        StopCoroutine(Writing());
        yield return null;
    }

    void Jump()
    {
        if (isGrounded){
        rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Move()
    {
        
            rb.velocity = new Vector2(inputX * speed, rb.velocity.y);
        
    }

    public void Knockback(float amount)
    {
        Rigidbody2D.AddForce(new Vector2(-forwardForce, amount));
    }

    public void Knockback()
    {
        if (Input.GetMouseButtonDown(0))
    {
        if(gameObject.GetComponent<Rigidbody>())
        {
            print("force add");
            gameobject.getcomponent<RigidBody>().AddForce (-transform.forward * 10f * Time.deltaTime); 
        }
    } 
    }

    // void Bounce()
    // {
        
    // }

  
}

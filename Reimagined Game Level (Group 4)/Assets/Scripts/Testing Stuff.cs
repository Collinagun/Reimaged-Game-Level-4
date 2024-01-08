using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TestingStuff : MonoBehaviour
{
    Rigidbody2D Rb;
    public bool isGrounded;
    public bool jump = false;
    float inputX, inputY;
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            isGrounded = true;
            jump = true;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    [SerializeField] PlayerActions playerActions;
    private Rigidbody2D rb;
    public LayerMask wallMask;
    public bool canBounce;

    
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        // canBounce = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
        // new Vector2(0.9f, 0.4f), 0f, wallMask);
    }

    public void OncollisionStay2D(Collision2D col){
        
        if (col.gameObject.tag == "wall"){
            canBounce = true;
            Debug.Log("walled");
        }
        else {
            canBounce = false;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float hit = 4500f;
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;
 
    public bool isKnockback = false;
    private Vector2 knockbackDirection;
    private int damage;
    private float knockbackAmount;

    private PlayerActions ownerPlayer;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(KnockbackCoroutine());
        }
    }
    IEnumerator KnockbackCoroutine()
    {
        isKnockback = true;
        Vector2 difference = (transform.position - Enemy.transform.position).normalized;
        Vector2 force = difference * knockbackForce;
        rb.AddForce(-transform.right * hit);
        rb.AddForce(force, ForceMode2D.Impulse);
 
        yield return new WaitForSeconds(knockbackDuration);
 
        isKnockback = false;
    }
    public Weapon(PlayerActions ownerPlayer)
    {
        damage = 5;
        knockback = 5.0f;

        this.ownerPlayer = ownerPlayer;
    }

    public void Shoot()
    {
        // do the shooting

        ownerPlayer.Knockback(knockback);
    }
}

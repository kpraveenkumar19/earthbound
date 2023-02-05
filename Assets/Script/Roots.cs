using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    Collider2D rootcollider;
    private float damage = 10;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rootcollider = GetComponent<Collider2D>();
    }

    public void damageFrame2()
    {
        damage = 20f;
    }

    public void damageFrame3()
    {
        damage = 30f;
    }

    public void Colliderenable()
    {
        rootcollider.enabled = true;
    }
    public void colliderdisable()
    {
        rootcollider.enabled = false;
    }
    public void dmg()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.health -= damage;
                Debug.Log("Hiiii");
            }
        }
    }
}




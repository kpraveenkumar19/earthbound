using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Helth : MonoBehaviour
{
    public float health = 1;
    Animator animator;
    public float Health
    {
        set
        {
            health = value;
            
        }
        get
        {
            return health;
        }

    }
    public void deleteEnemy()
    {
        Destroy(gameObject);
        Debug.Log("DIEEEEEE");
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Defeated()
    {
        animator.SetTrigger("DeathAnimtaion");
    }
    public void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Defeated");
            Defeated();
        }
    }


}

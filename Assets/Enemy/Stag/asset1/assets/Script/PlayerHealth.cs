using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
    public void Defeated()
    {
        animator.SetTrigger("DeathAnimation");
    }

    private void Update()
    {

        if (health <= 0)
        {
            Debug.Log("Defeadted");
            Defeated();
        }
    }
}

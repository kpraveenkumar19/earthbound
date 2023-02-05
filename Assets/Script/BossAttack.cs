using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float wait = 2f;
    public Transform target;
    private Collider2D rootCollider;
    public GameObject roots;
    private Animator animator;
    public float timeBetweenShots;
    float nextShotTime;


    private void Start()
    {
        rootCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(roots , target.position , Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }
    }


}

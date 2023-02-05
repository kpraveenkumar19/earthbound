using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    Rigidbody2D rb;
    public ContactFilter2D movementFilter;
    public float speed = 1f;
    public float offset = 0.0015f;
    public List<RaycastHit2D> castcollision = new List<RaycastHit2D>();
    private Animator animator;
    private SpriteRenderer sr;
    bool canmove = true;
     public SpearAttack SpearAttack ;
     public bool isFireing = false;
     public GameObject bulletPrefab;
     GameObject arrow;
     public float arrowSpeed = 3f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        
            
        if (canmove)
        {
            if (movementInput != Vector2.zero)
            {
                bool sucess = tryMove(movementInput);
                if (!sucess)
                {
                    sucess = tryMove(new Vector2(movementInput.x, 0));
                }
                if (!sucess)
                {
                    sucess = tryMove(new Vector2(0, movementInput.y));
                }
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
            //animator.SetFloat("SpeedX", movementInput.x);
            //animator.SetFloat("SpeedY", movementInput.y);
            if (movementInput.x < 0)
            {
                sr.flipX = true;

            }
            else if (movementInput.x > 0)
            {
                sr.flipX = false;
            }
        }
    }
    bool tryMove(Vector2 input)
    {
        {
            int count = rb.Cast(
                input,
                movementFilter,
                castcollision,
                speed * Time.fixedDeltaTime + offset
                 );
            {
                if (count == 0)
                {
                    rb.MovePosition(rb.position + speed * input * Time.fixedDeltaTime);
                    animator.SetBool("IsWalking", true);

                    return true;
                }
                animator.SetBool("IsWalking", false);
                return false;

            }
        }

    }
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
    public void LockMovement()
    { 
        canmove = false;
    }
    public void UnlockMovement()
    {
        canmove = true;
    }
    void OnFire2()
    {
       animator.SetTrigger("CrossBow");
        
   }
    void OnFire()
   {
        animator.SetTrigger("SpearAttack");
    }
    public void fire()
    {
        GameObject arrow = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        if (sr.flipX == true)
       { arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * arrowSpeed, 0f); }
        else
        {
           arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed, 0f);
        }
       Debug.Log("Fire!!!");
   }
    public void SpearAttck()
    {
        LockMovement();
        if (sr.flipX == true)
        { SpearAttack.attackLeft(); }
        else
        {
            SpearAttack.attackRight();
        }
    }
    public void des()
    {
        GetComponentInChildren<Collider2D>().enabled = false;
    }
}

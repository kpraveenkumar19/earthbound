using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float Range = 0.1f;
    bool follow = true;
    public float followup = 0.1f;
    bool flip = false;
    



    private void Update()
    {
        {
            if (Vector2.Distance(transform.position, target.position) > Range)
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            else
            {
                GetComponent<Animator>().SetTrigger("Attack");
                if (gameObject.transform.position.x - target.transform.position.x > 0)
                {
                    GetComponentInChildren<Collider2D>().enabled = true;
                    GetComponentInChildren<Transform>().position = GetComponentInChildren<Transform>().position * -1;
                }
               else
                {
                    GetComponentInChildren<Collider2D>().enabled = true;
                }
            }
            if (gameObject.transform.position.x - target.transform.position.x > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                flip = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                flip = true; 
            }
        }

    }

    public void  disableCollider()
    {
        GetComponentInChildren<Collider2D>().enabled = false;
    }



    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunAway : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float Range = 0.1f;
    bool follow = true;
    public float followup = 0.1f;
    public float nextShotTime;
    public GameObject projectile;


    private void Update()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + followup;
        }
        {
            if (Vector2.Distance(transform.position, target.position) < Range)
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            if (gameObject.transform.position.x - target.transform.position.x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Damage Taken");
        }
    }
}

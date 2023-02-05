using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 targetPosititon;
    public float speed;

    private void Start()
    {
        targetPosititon = FindObjectOfType<PlayerMovement>().transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosititon, speed * Time.deltaTime);
        if (transform.position == targetPosititon)
        {
            Destroy(gameObject);
        }
    }
}

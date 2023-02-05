using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttack : MonoBehaviour
{
    Vector2 rightattackoffset;
    public Collider2D SpearCollider;
    public float damage = 20;

    private void Start()
    {
        rightattackoffset = transform.localPosition;
    }
    public void attackRight()
    {
        SpearCollider.enabled = true;
        transform.localPosition = rightattackoffset;
    }
    public void attackLeft()
    {
        SpearCollider.enabled = true;
        transform.localPosition = new Vector2(rightattackoffset.x * -1, rightattackoffset.y);
    }
    public void stopAttack()
    {
        SpearCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.health -= damage;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearClawCollider : MonoBehaviour
{
    Vector2 rightattackoffset;
    public Collider2D SpearCollider;
    public float damage = 1f;

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
        if (other.tag == "Player")
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
               player.health -= damage;
                Debug.Log("Damage taken");
            }
        }
    }

}

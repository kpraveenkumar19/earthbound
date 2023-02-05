using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 1;
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
 
    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
     
        }
    }

}

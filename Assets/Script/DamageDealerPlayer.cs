using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealerPlayer : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public int GetDamage1()
    {
        return damage;
    }

}

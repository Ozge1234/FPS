using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{

    public float health;

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
        Debug.Log(damage);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyCollider : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Health playerHealth = collision.GetComponent<Health>();
            playerHealth.TakeDamage(damage);
        }
    }
}

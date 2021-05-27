using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapArrow : MonoBehaviour
{
    [SerializeField] private int damage;
    
    Rigidbody2D rb;
    
    public Vector2 dir = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Health playerHealth = collision.GetComponent<Health>();
            playerHealth.TakeDamage(damage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Destroy(gameObject);//arrow destroyed after player is hit or after it reaches the end of a trigger zone
    }
}

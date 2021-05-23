using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer = null;

    [SerializeField] protected int projectileID;
    public int ProjectileID { get => projectileID; }

    [SerializeField] protected float projectileSpeed = 4f;
    [SerializeField] protected float projectileLifetime = 4f;
    [SerializeField] protected int projectileDamage = 1;


    private float currentLifetime;
    private float direction = 1;

    private void Update()
    {
        currentLifetime += Time.deltaTime;

        if(currentLifetime > projectileLifetime)
        {
            ProjectilePooler.Instance.AddProjectileToPool(this);           
        }

        transform.position += Vector3.right * direction * projectileSpeed * Time.deltaTime;
    }

    public void SetProjectileDirection(float val)
    {
        direction = val;
        spriteRenderer.flipX = direction != 1;
        spriteRenderer.flipY = spriteRenderer.flipX;

    }

    private void OnEnable()
    {
        currentLifetime = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(projectileDamage);
            ProjectilePooler.Instance.AddProjectileToPool(this);
            
        }

        
    }
}

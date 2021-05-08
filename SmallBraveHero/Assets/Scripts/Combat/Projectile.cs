using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected int projectileID;
    public int ProjectileID { get => projectileID; }

    [SerializeField] protected float projectileSpeed = 4f;
    [SerializeField] protected float projectileLifetime = 4f;


    private float currentLifetime;
    private float direction = 1;

    private void Update()
    {
        currentLifetime += Time.deltaTime;

        if(currentLifetime > projectileLifetime)
        {
            ProjectilePooler.Instance.AddProjectileToUnUsed(this);           
        }

        transform.position += Vector3.right * direction * projectileSpeed * Time.deltaTime;
    }

    public void SetProjectileDirection(float val)
    {
        direction = val;
    }

    private void OnEnable()
    {
        currentLifetime = 0;
    }
}

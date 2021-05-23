using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour
{
    public static ProjectilePooler Instance = null;

    [SerializeField] private Projectile[] projectiles;
    [SerializeField] private int eachProjectileSpawnCount = 5;

    private Dictionary<int, Queue<Projectile>> projectilePool = null;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        PreparePool();
    }

    private void PreparePool()
    {
        projectilePool = new Dictionary<int, Queue<Projectile>>();

        for (int i = 0; i < projectiles.Length; i++)
        {
            projectilePool[projectiles[i].ProjectileID] = new Queue<Projectile>();

            for (int j = 0; j < eachProjectileSpawnCount; j++)
            {
                Projectile projectile = Instantiate(projectiles[i], transform);
                projectile.gameObject.SetActive(false);

                projectilePool[projectiles[i].ProjectileID].Enqueue(projectile);
                
            }
        }
    }

    public void SpawnProjectileFromPool(int id, float direction = 1, Vector3 position = new Vector3())
    {
        Projectile projectile = projectilePool[id].Dequeue();

        projectile.SetProjectileDirection(direction);
        projectile.transform.position = position;
        projectile.gameObject.SetActive(true);
    }

    public void AddProjectileToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);

        projectilePool[projectile.ProjectileID].Enqueue(projectile);
    }
}

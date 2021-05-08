using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour
{
    public static ProjectilePooler Instance = null;

    [SerializeField] private Projectile[] projectiles;
    [SerializeField] private int eachProjectileSpawnCount = 5;

    private List<Projectile> usedProjectiles = null;
    private List<Projectile> unUsedProjectiles = null;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void PreparePool()
    {
        usedProjectiles = new List<Projectile>();
        unUsedProjectiles = new List<Projectile>();

        for(int i = 0; i < projectiles.Length; i++)
        {
            for(int j = 0; j < eachProjectileSpawnCount; j++)
            {
                unUsedProjectiles.Add(Instantiate(projectiles[i]));
            }
        }
    }

    public void SpawnProjectileFromPool(int id, float direction = 1, Vector3 position = new Vector3())
    {
        Projectile projectile = unUsedProjectiles.FirstOrDefault(x => x.ProjectileID == id);

        projectile.SetProjectileDirection(direction);
        projectile.gameObject.SetActive(true);

        unUsedProjectiles.Remove(projectile);
        usedProjectiles.Add(projectile);
    }

    public void AddProjectileToUnUsed(Projectile projectile)
    {
        unUsedProjectiles.Add(projectile);
        projectile.gameObject.SetActive(false);
    }
}

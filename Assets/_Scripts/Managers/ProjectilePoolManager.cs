using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolManager : MonoBehaviour
{

    //singleton
    private static ProjectilePoolManager instance;

    public static ProjectilePoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Projectile Pool Manager");
                instance = go.AddComponent<ProjectilePoolManager>();
            }
            return instance;
        }
    }
    [SerializeField] int _poolSize = 30;
    [SerializeField] GameObject _enemyProjectilePrefab;
    [SerializeField] GameObject _playerProjectilePrefab;

    public Queue<GameObject> EnemyProjectilePool = new Queue<GameObject>();
    public Queue<GameObject> PlayerProjectilePool = new Queue<GameObject>();


    private void Awake()
    {
        instance = this;

       // initialisation des pools
       for(int i = 0; i < _poolSize; i++)
        {
            GameObject enemyProjectile = Instantiate(_enemyProjectilePrefab);
            GameObject playerProjectile = Instantiate(_playerProjectilePrefab);
            enemyProjectile.SetActive(false);
            playerProjectile.SetActive(false);
            EnemyProjectilePool.Enqueue(enemyProjectile);
            PlayerProjectilePool.Enqueue(playerProjectile);
        } 
    }

    public GameObject TakeFromPool(Vector2 spawnPos,Quaternion spawnRot, Vector2 spawnScale, Queue<GameObject> pool)
    {
        if (EnemyProjectilePool.Count == 0) InfoText.Instance.Write("La pool est vide connard", true);
        GameObject projectile = pool.Dequeue();
        projectile.transform.position = spawnPos;
        projectile.transform.rotation = spawnRot;
        projectile.transform.localScale *= spawnScale;
        projectile.SetActive(true);
        return projectile; 
    }

    public void ReturnToPool(GameObject projectile, Queue<GameObject> pool)
    {
        print("back to pool !");
        projectile.SetActive(false);
        pool.Enqueue(projectile);
    }
}

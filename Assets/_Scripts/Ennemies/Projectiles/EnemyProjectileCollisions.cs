using System.Collections;
using UnityEngine;

public class EnemyProjectileCollisions : MonoBehaviour
{
    Projectiles _projectile;

    private void Awake()
    {
        _projectile = GetComponent<Projectiles>();
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    protected virtual IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        _projectile.BackToPool(ProjectilePoolManager.Instance.EnemyProjectilePool);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("sale con enemy");
    //    _projectile.BackToPool(ProjectilePoolManager.Instance.EnemyProjectilePool);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _projectile.BackToPool(ProjectilePoolManager.Instance.EnemyProjectilePool);
        if (collision.gameObject.TryGetComponent<PlayerCollision>(out PlayerCollision playerCollisions)) playerCollisions.Die();
    }
}

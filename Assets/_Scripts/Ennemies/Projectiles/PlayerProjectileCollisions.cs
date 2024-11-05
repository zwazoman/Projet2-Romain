using System.Collections;
using UnityEngine;

public class PlayerProjectileCollisions : MonoBehaviour
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
        _projectile.BackToPool(ProjectilePoolManager.Instance.PlayerProjectilePool);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("sale con player");
    //    _projectile.BackToPool(ProjectilePoolManager.Instance.PlayerProjectilePool);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _projectile.BackToPool(ProjectilePoolManager.Instance.PlayerProjectilePool);
        if (collision.gameObject.TryGetComponent<TurretCollisions>(out TurretCollisions turretCollisions)) turretCollisions.Explode();
    }
}

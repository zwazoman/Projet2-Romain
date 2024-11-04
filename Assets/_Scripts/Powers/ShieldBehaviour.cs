using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.TryGetComponent<Projectiles>(out Projectiles projectile))
    //    {
    //        ProjectilePoolManager.Instance.TakeFromPlayerPool(collision.conta,)
    //        projectile.Speed *= -1;
    //        projectile.ResetLifeTime();
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("ça touche le shield");
        if (collision.gameObject.TryGetComponent<Projectiles>(out Projectiles projectile))
        {
            GameObject projectileObject = projectile.gameObject;
            Vector2 spawnPos = projectileObject.transform.position;
            projectile.BackToPool(ProjectilePoolManager.Instance.EnemyProjectilePool);

            //ProjectilePoolManager.Instance.TakeFromPool(collision.GetContact(0).point, Quaternion.Inverse(projectile.gameObject.transform.rotation), transform.localScale,ProjectilePoolManager.Instance.PlayerProjectilePool);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ça touche le shield");
        if (collision.gameObject.TryGetComponent<Projectiles>(out Projectiles projectile) && collision.gameObject.layer == 7)
        {
            GameObject projectileObject = projectile.gameObject;
            Vector2 spawnPos = projectileObject.transform.position;
            Quaternion spawnRot = Quaternion.Euler(projectileObject.transform.rotation.eulerAngles.x, projectileObject.transform.rotation.eulerAngles.y, projectileObject.transform.rotation.eulerAngles.z - 180);
            projectile.BackToPool(ProjectilePoolManager.Instance.EnemyProjectilePool);
            ProjectilePoolManager.Instance.TakeFromPool(spawnPos, spawnRot, transform.localScale,ProjectilePoolManager.Instance.PlayerProjectilePool);


            //ProjectilePoolManager.Instance.TakeFromPool(collision.GetContact(0).point, Quaternion.Inverse(projectile.gameObject.transform.rotation), transform.localScale,ProjectilePoolManager.Instance.PlayerProjectilePool);
        }
    }
}

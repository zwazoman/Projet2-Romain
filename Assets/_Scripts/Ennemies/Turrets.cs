using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    [SerializeField] public float TurretFireRate;
    [SerializeField] protected GameObject _barrel;

    float _timer = 0f;

    protected void Update()
    {
        if (!ShouldShoot())
        {
            _timer = 0;
            return;
        }

        Aim();

        //tirer tout les x secs
        _timer += Time.deltaTime;
        if (_timer > TurretFireRate)
        {
            Shoot();
            _timer = 0f;
        }
    }

    protected void Aim()
    {
        Vector2 targetPosition = PlayerMain.Instance.transform.position - transform.position;
        transform.up = targetPosition;
    }

    protected virtual bool ShouldShoot()
    {
        return (PlayerMain.Instance.gameObject.transform.position - transform.position).sqrMagnitude < Mathf.Pow(15,2);
    }

    protected virtual void Shoot()
    {
        ProjectilePoolManager.Instance.TakeFromPool(_barrel.transform.position,_barrel.transform.rotation,transform.localScale,ProjectilePoolManager.Instance.EnemyProjectilePool);
    }
}

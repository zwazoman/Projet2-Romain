using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powers
{
    public PowerPickup pickupItem;

    public abstract void Activate();

    public virtual bool IsUsable()
    {
        return true;
    }

    protected void Impulse(Vector2 normalizedDirection, float jumpForce)
    {
        PlayerMain.Instance.Movement.RB.velocity = normalizedDirection * jumpForce;
    }

    protected void ActiveShield(bool state = true)
    {
        if(PlayerMain.Instance != null) PlayerMain.Instance.Shield.SetActive(state);
    }


    protected void SummonProjectile(Vector2 position, Quaternion rotation, Vector2 scaleMultiplier)
    {
        GameObject projectile = ProjectilePoolManager.Instance.TakeFromPool(position, rotation, scaleMultiplier, ProjectilePoolManager.Instance.PlayerProjectilePool);
    }
}

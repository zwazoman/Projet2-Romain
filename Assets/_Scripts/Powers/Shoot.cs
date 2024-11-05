using UnityEngine;

public class Shoot : Powers
{
    public override void Activate()
    {
        PlayerMain player = PlayerMain.Instance;
        float zRotation;
        if (player.Movement.IsFacingRight) zRotation = -90; else zRotation = 90;
        AudioManager.Instance.PlaySFXClip(Sounds.Projectile);
        SummonProjectile(player.gameObject.transform.position /*+ player.gameObject.transform.right*/, Quaternion.Euler(0, 0, zRotation), player.gameObject.transform.localScale);
    }
}

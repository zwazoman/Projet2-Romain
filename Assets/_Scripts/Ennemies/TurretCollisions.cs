using UnityEngine;

public class TurretCollisions : MonoBehaviour
{
    public void Explode()
    {
        AudioManager.Instance.PlaySFXClip(Sounds.EnemyDeath);
        Destroy(gameObject);
    }
}

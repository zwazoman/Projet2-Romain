using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerCollision>(out PlayerCollision playerCollisions)) playerCollisions.Die();
    }
}

using UnityEngine;

[RequireComponent(typeof(PlayerMain))]
[RequireComponent(typeof(Collider2D))]
public class PlayerCollision : MonoBehaviour
{
    //[SerializeField] float _coyoteTime = .3f;

    PlayerMain _main;

    private void Awake()
    {
        _main = GetComponent<PlayerMain>();
    }

    /// <summary>
    /// gestion des collisions du joueur avec l'environnement
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y < transform.position.y && collision.gameObject.layer == 6)
        {
            AudioManager.Instance.PlaySFXClip(Sounds.Fall, 0.5f);
            _main.Movement.IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y < transform.position.y && collision.gameObject.layer == 6)
        {
            _main.Movement.IsGrounded = false;
            //StartCoroutine(CoyoteTime(_coyoteTime));
        }
    }

    public void Die()
    {
        AudioManager.Instance.PlaySFXClip(Sounds.Death);
        GameManager.Instance.RestartLevel("T'es mort, pas ouf.");
    }

    //IEnumerator CoyoteTime(float coyoteTime)
    //{
    //    yield return new WaitForSeconds(coyoteTime);
    //    _main.Movement.IsGrounded = false;
    //}
}

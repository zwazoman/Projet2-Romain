using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.Instance.PlaySFXClip(Sounds.Win);
        if (collision.gameObject.layer == 3) GameManager.Instance.RestartLevel("Bien Joué ! c'est reparti.");
    }
}
